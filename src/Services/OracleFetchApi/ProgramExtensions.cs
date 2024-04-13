using OracleFetchApi.Infrastructure;
using OracleFetchApi.Repositories;
using OracleFetchApi.Services;
using Serilog;

namespace OracleFetchApi;

public static class ProgramExtensions
{
    private const string AppName = "OracleFetchApi";

    public static void AddCustomSerilog(this WebApplicationBuilder builder)
    {
        var seqServerUrl = builder.Configuration["SeqServerUrl"];

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .WriteTo.Console()
            .WriteTo.Seq(seqServerUrl!)
            .Enrich.WithProperty("ApplicationName", AppName)
            .CreateLogger();

        builder.Host.UseSerilog();
    }

    public static void AddCustomSwagger(this WebApplicationBuilder builder) =>
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = $"{AppName}", Version = "v1" });
    });

    public static void UseCustomSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{AppName} V1");
        });
    }

    public static void AddCustomHealthChecks(this WebApplicationBuilder builder) =>
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy())
            .AddDapr()
            .AddSqlServer(
                builder
                // .Configuration["ConnectionStrings:OracleDB"]
                .Configuration.GetConnectionString("DefaultConnection")
                !,
                name: "OracleDB-check",
                tags: new[] { "oracledb" });

    public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEventBus, DaprEventBus>();
        builder.Services.AddScoped<IOracleFetchRepository, OracleFetchRepository>();
        builder.Services.AddScoped<IOracleFetchService, OracleFetchService>();
        // builder.Services.AddScoped<OrderStatusChangedToAwaitingStockValidationIntegrationEventHandler>();
        // builder.Services.AddScoped<OrderStatusChangedToPaidIntegrationEventHandler>();
    }

    public static void AddCustomDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<OracleDbContext>(
            options => options.UseSqlServer(builder
            // .Configuration["ConnectionStrings:OracleDB"]
            .Configuration.GetConnectionString("DefaultConnection")
            !));
    }

    public static void ApplyDatabaseMigration(this WebApplication app)
    {
        // Apply database migration automatically. Note that this approach is not
        // recommended for production scenarios. Consider generating SQL scripts from
        // migrations instead.
        using var scope = app.Services.CreateScope();

        var retryPolicy = CreateRetryPolicy(app.Configuration, Log.Logger);
        var context = scope.ServiceProvider.GetRequiredService<OracleDbContext>();

        retryPolicy.Execute(context.Database.Migrate);
    }

    private static Policy CreateRetryPolicy(IConfiguration configuration, Serilog.ILogger logger)
    {
        // Only use a retry policy if configured to do so.
        // When running in an orchestrator/K8s, it will take care of restarting failed services.
        if (bool.TryParse(configuration["RetryMigrations"], out bool _))
        {
            return Policy.Handle<Exception>().
                WaitAndRetryForever(
                    sleepDurationProvider: _ => TimeSpan.FromSeconds(5),
                    onRetry: (exception, retry, _) =>
                    {
                        logger.Warning(
                            exception,
                            "Exception {ExceptionType} with message {Message} detected during database migration (retry attempt {retry}, connection {connection})",
                            exception.GetType().Name,
                            exception.Message,
                            retry,
                            // configuration["ConnectionStrings:OracleDB"]);
                            configuration.GetConnectionString("DefaultConnection"));
                    }
                );
        }

        return Policy.NoOp();
    }

}
