using System.Text.Json;
using IntegrationHub.Api.Authentication;
using IntegrationHub.Application;
using IntegrationHub.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

DevelopmentEnvironmentFile.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
builder.Services.AddOpenApi();
builder.Services.AddApiAuthentication(builder.Configuration, builder.Environment);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<TokenIssuerOptions>>()
    .Value.Enabled)
{
    // Fail during startup instead of on the first request when a key is missing,
    // malformed, or the public/private files are not the same RSA key pair.
    app.Services.GetRequiredService<RsaKeyStore>().EnsureLoaded();
}

app.UseExceptionHandler();
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapOpenApi().RequireAuthorization(ApiScopes.SyncAdmin);
app.MapControllers();
app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = _ => false
});
app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = registration => registration.Tags.Contains("ready")
}).RequireAuthorization(ApiScopes.SyncAdmin);

app.Run();

public partial class Program;
