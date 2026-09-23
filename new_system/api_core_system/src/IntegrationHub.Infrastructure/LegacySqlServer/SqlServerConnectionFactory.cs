using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Infrastructure.LegacySqlServer;

internal sealed class SqlServerConnectionFactory(
    IOptions<LegacyDatabaseOptions> options) : ILegacyDbConnectionFactory
{
    private readonly string _connectionString = options.Value.ConnectionString;

    public async Task<DbConnection> OpenConnectionAsync(CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(_connectionString))
        {
            throw new InvalidOperationException("LegacyDatabase:ConnectionString is not configured.");
        }

        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);
        return connection;
    }
}
