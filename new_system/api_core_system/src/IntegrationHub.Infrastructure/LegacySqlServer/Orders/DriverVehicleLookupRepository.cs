using System.Data;
using Dapper;
using IntegrationHub.Application.Abstractions;
using IntegrationHub.Domain.Orders;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Infrastructure.LegacySqlServer.Orders;

internal sealed class DriverVehicleLookupRepository(
    ILegacyDbConnectionFactory connectionFactory,
    IOptions<LegacyDatabaseOptions> options) : IDriverVehicleLookupRepository
{
    private readonly int _commandTimeout = options.Value.CommandTimeoutSeconds;

    public async Task<DriverVehicleInfo?> FindAsync(
        string identityNumber,
        DateTime reportDate,
        CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();
        parameters.Add("ID_Dt_Vc", identityNumber, DbType.AnsiString, size: 50);
        parameters.Add("Ngay_Ct", reportDate, DbType.DateTime);

        await using var connection = await connectionFactory.OpenConnectionAsync(cancellationToken);
        var row = (await connection.QueryAsync(new CommandDefinition(
            "dbo.sp_GetTenDtVcsoxe",
            parameters,
            commandType: CommandType.StoredProcedure,
            commandTimeout: _commandTimeout,
            cancellationToken: cancellationToken))).FirstOrDefault();
        if (row is not IDictionary<string, object> values)
        {
            return null;
        }

        static string Read(IDictionary<string, object> source, string key)
        {
            var match = source.FirstOrDefault(item =>
                string.Equals(item.Key, key, StringComparison.OrdinalIgnoreCase));
            return Convert.ToString(match.Value)?.Trim() ?? string.Empty;
        }

        return new DriverVehicleInfo(
            Read(values, "Ten_Dt_Vc"),
            Read(values, "So_Xe"),
            Read(values, "SO_XA_LAN_TAU"));
    }
}
