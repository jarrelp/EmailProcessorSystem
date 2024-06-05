namespace EmailApi.Web;

public static class ProgramExtensions
{
    private const string AppName = "EmailApi";

    public static void AddCustomSwagger(this WebApplicationBuilder builder) =>
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = $"{AppName}", Version = "v1" });
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
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
            .AddSqlite(
                builder
                .Configuration.GetConnectionString("DefaultConnection")
                !,
                name: "SqliteDb-check",
                tags: new[] { "sqlitedb" });

    public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEventBus, DaprEventBus>();
    }
}
