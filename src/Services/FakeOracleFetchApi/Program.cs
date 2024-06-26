var appName = "FakeOracleFetchApi";
var builder = WebApplication.CreateBuilder(args);

builder.AddCustomConfiguration();
builder.AddCustomSwagger();
builder.AddCustomHealthChecks();
builder.AddCustomApplicationServices();
builder.AddCustomDatabase();

builder.Services.AddDaprClient();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseCustomSwagger();
}

var pathBase = builder.Configuration["PATH_BASE"];
if (!string.IsNullOrEmpty(pathBase))
{
  app.UsePathBase(pathBase);
}

app.UseCloudEvents();

app.MapGet("/", () => Results.LocalRedirect("~/swagger"));
app.MapControllers();
app.MapSubscribeHandler();
app.MapCustomHealthChecks("/hc", "/liveness", UIResponseWriter.WriteHealthCheckUIResponse);

try
{
  app.Logger.LogInformation("Applying database migration ({ApplicationName})...", appName);
  app.ApplyDatabaseMigration();

  app.Logger.LogInformation("Starting web host ({ApplicationName})...", appName);
  app.Run();
}
catch (Exception ex)
{
  app.Logger.LogCritical(ex, "Host terminated unexpectedly ({ApplicationName})...", appName);
}