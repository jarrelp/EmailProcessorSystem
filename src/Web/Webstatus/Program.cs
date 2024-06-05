var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHealthChecksUI(
    //     config =>
    // {
    //     config.AddHealthCheckEndpoint("OracleFetchAPI", "http://localhost:5000/hc");
    //     config.AddHealthCheckEndpoint("EmailApi", "http://localhost:5003/hc");
    // }
    )
    .AddInMemoryStorage();

builder.Logging.AddJsonConsole();

var app = builder.Build();

var pathBase = builder.Configuration["PATH_BASE"];
if (!string.IsNullOrEmpty(pathBase))
{
    app.UsePathBase(pathBase);
}

app.UseHealthChecksUI(config =>
{
    config.ResourcesPath = string.IsNullOrEmpty(pathBase)
        ? "/ui/resources"
        : $"{pathBase}/ui/resources";
});

app.MapGet(string.IsNullOrEmpty(pathBase)
    ? "/"
    : pathBase, () => Results.LocalRedirect("~/healthchecks-ui"));
app.MapHealthChecksUI();

app.Run();
