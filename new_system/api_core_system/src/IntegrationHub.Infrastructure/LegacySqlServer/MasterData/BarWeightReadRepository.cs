using System.Data;
using Dapper;
using IntegrationHub.Application.Abstractions;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Infrastructure.LegacySqlServer.MasterData;

internal sealed class BarWeightReadRepository(
    ILegacyDbConnectionFactory connectionFactory,
    IOptions<LegacyDatabaseOptions> options) : IBarWeightReadRepository
{
    private readonly int _commandTimeout = options.Value.CommandTimeoutSeconds;

    public async Task<decimal?> CalculateAsync(string productCode, decimal bundleQuantity,
        decimal looseBarQuantity, CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();
        parameters.Add("MaVt", productCode, DbType.AnsiString, size: 20);
        parameters.Add("SoBo", bundleQuantity, DbType.Decimal, precision: 19, scale: 4);
        parameters.Add("SoCayLe", looseBarQuantity, DbType.Decimal, precision: 19, scale: 4);

        await using var connection = await connectionFactory.OpenConnectionAsync(cancellationToken);
        return await connection.ExecuteScalarAsync<decimal?>(new CommandDefinition(
            "SELECT CAST(dbo.fn_CalBaremBo(@MaVt, @SoBo, @SoCayLe) AS decimal(19, 4));",
            parameters, commandTimeout: _commandTimeout, cancellationToken: cancellationToken));
    }
}
