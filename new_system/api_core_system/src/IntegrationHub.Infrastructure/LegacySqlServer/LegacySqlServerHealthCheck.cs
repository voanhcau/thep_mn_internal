using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace IntegrationHub.Infrastructure.LegacySqlServer;

internal sealed class LegacySqlServerHealthCheck(
    ILegacyDbConnectionFactory connectionFactory) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await using var connection = await connectionFactory.OpenConnectionAsync(cancellationToken);
            return HealthCheckResult.Healthy("Legacy SQL Server is reachable.");
        }
        catch (Exception exception)
        {
            return HealthCheckResult.Unhealthy("Legacy SQL Server is unavailable.", exception);
        }
    }
}
