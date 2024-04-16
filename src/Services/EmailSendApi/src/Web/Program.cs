using EmailSendApi;
using EmailSendApi.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;

// var appName = "OracleFetchApi";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

builder.AddCustomSwagger();
builder.AddCustomHealthChecks();
builder.AddCustomApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

var pathBase = builder.Configuration["PATH_BASE"];
if (!string.IsNullOrEmpty(pathBase))
{
    app.UsePathBase(pathBase);
}
else
{
    app.UseHsts();
}

app.UseCloudEvents();

app.UseCustomSwagger();

app.UseRouting();

app.MapControllers();
// app.MapSwagger("/swagger/{documentName}/swagger.json"); // De plaatsaanduiding {documentName} is vereist
app.MapSubscribeHandler();
app.MapCustomHealthChecks("/hc", "/liveness", UIResponseWriter.WriteHealthCheckUIResponse);
app.UseExceptionHandler(options => { });

app.Run();






// using EmailSendApi;
// using EmailSendApi.Infrastructure.Data;
// using Microsoft.AspNetCore.Builder;

// var appName = "OracleFetchApi";

// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddApplicationServices();
// builder.Services.AddInfrastructureServices(builder.Configuration);
// builder.Services.AddWebServices();

// // builder.AddCustomSwagger();
// builder.AddCustomHealthChecks();
// builder.AddCustomApplicationServices();

// builder.Services.AddDaprClient();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     await app.InitialiseDatabaseAsync();
// }

// var pathBase = builder.Configuration["PATH_BASE"];
// if (!string.IsNullOrEmpty(pathBase))
// {
//     app.UsePathBase(pathBase);
// }
// else
// {
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// app.UseCloudEvents();

// // app.UseHttpsRedirection();

// app.UseSwagger();
// app.UseSwaggerUI(c =>
// {
//     c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{appName} API V1");
// });

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
//     endpoints.MapSwagger("/swagger/v1/swagger.json");
// });

// // app.MapControllerRoute(
// //     name: "default",
// //     pattern: "{controller}/{action=Index}/{id?}");

// // app.MapRazorPages();

// // app.MapGet("/", () => Results.LocalRedirect("~/swagger"));
// app.MapSubscribeHandler();
// app.MapCustomHealthChecks("/hc", "/liveness", UIResponseWriter.WriteHealthCheckUIResponse);

// // app.MapFallbackToFile("index.html");

// app.UseExceptionHandler(options => { });


// // app.MapEndpoints();

// app.Run();

// public partial class Program { }








// using EmailSendApi;
// using EmailSendApi.Infrastructure.Data;

// var appName = "OracleFetchApi";

// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddApplicationServices();
// builder.Services.AddInfrastructureServices(builder.Configuration);
// builder.Services.AddWebServices();

// builder.AddCustomSwagger();
// builder.AddCustomHealthChecks();
// builder.AddCustomApplicationServices();

// builder.Services.AddDaprClient();
// builder.Services.AddControllers();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseDeveloperExceptionPage();

//     app.UseSwagger();
//     app.UseSwaggerUI(c =>
//     {
//         c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{appName} V1");
//     });
// }

// var pathBase = builder.Configuration["PATH_BASE"];
// if (!string.IsNullOrEmpty(pathBase))
// {
//     app.UsePathBase(pathBase);
// }

// app.UseCloudEvents();

// app.MapGet("/", () => Results.LocalRedirect("~/swagger"));
// app.MapControllers();
// app.MapSubscribeHandler();
// app.MapCustomHealthChecks("/hc", "/liveness", UIResponseWriter.WriteHealthCheckUIResponse);

// try
// {
//     app.Logger.LogInformation("Applying database migration ({ApplicationName})...", appName);
//     await app.InitialiseDatabaseAsync();

//     app.Logger.LogInformation("Starting web host ({ApplicationName})...", appName);
//     app.Run();
// }
// catch (Exception ex)
// {
//     app.Logger.LogCritical(ex, "Host terminated unexpectedly ({ApplicationName})...", appName);
// }