using Serilog;
using TrainTimings.Api.Middlewares;
using TrainTimings.Persistence.Extentions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File($"{Environment.CurrentDirectory}/Logs/{DateTime.UtcNow:yyyy/dd/MM}.txt")
    .CreateLogger();
logger.Information("Starting web host");

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddInfrastructure(builder.Configuration);
services.AddSwaggerGen();
services.AddKeycloakAuthentication(builder.Configuration);
services.AddCustomAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();