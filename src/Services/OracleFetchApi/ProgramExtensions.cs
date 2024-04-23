namespace OracleFetchApi;

public static class ProgramExtensions
{
    private const string AppName = "OracleFetchApi";

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
            .AddDapr();

    public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEventBus, DaprEventBus>();
        builder.Services.AddScoped<IEmailDataRepository, EmailDataRepository>();
        builder.Services.AddScoped<IOracleDCDataProvider>(provider =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            return new OracleDCDataProvider(connectionString);
        });
    }
}
