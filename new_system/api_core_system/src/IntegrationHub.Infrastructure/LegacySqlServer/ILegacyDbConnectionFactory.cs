using System.Data.Common;

namespace IntegrationHub.Infrastructure.LegacySqlServer;

public interface ILegacyDbConnectionFactory
{
    Task<DbConnection> OpenConnectionAsync(CancellationToken cancellationToken);
}
