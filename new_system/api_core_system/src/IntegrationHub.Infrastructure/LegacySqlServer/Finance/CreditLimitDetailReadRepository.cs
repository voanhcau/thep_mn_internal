using System.Data;
using System.Globalization;
using Dapper;
using IntegrationHub.Application.Abstractions;
using IntegrationHub.Application.Modules.Finance.CreditLimitDetails;
using IntegrationHub.Domain.Finance;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Infrastructure.LegacySqlServer.Finance;

internal sealed class CreditLimitDetailReadRepository(
    ILegacyDbConnectionFactory connectionFactory,
    IOptions<LegacyDatabaseOptions> options) : ICreditLimitDetailReadRepository
{
    private readonly int _commandTimeout = options.Value.CommandTimeoutSeconds;

    public async Task<CreditLimitDetailResult> GetAsync(
        GetCreditLimitDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Ngay_Ct", query.DocumentDate, DbType.DateTime);
        parameters.Add("Ma_Dt", query.PartnerCode, DbType.AnsiString, size: 20);
        parameters.Add("Language_ID", query.LanguageId, DbType.AnsiString, size: 10);
        parameters.Add("Ma_DvCs", query.BusinessUnitCode, DbType.AnsiString, size: 10);

        var command = new CommandDefinition(
            "dbo.sp_rptSODTC01_Check",
            parameters,
            commandType: CommandType.StoredProcedure,
            commandTimeout: _commandTimeout,
            cancellationToken: cancellationToken);

        await using var connection = await connectionFactory.OpenConnectionAsync(cancellationToken);
        var resultRows = await connection.QueryAsync(command);
        var sourceRows = resultRows
            .Select(row => (IDictionary<string, object>)row)
            .Where(row => ReadLevel(row) == query.Level)
            .ToArray();

        var columns = sourceRows
            .SelectMany(row => row.Keys)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();
        var items = sourceRows
            .Select(row => (IReadOnlyDictionary<string, object?>)columns.ToDictionary(
                column => column,
                column => ReadValue(row, column),
                StringComparer.OrdinalIgnoreCase))
            .ToArray();

        return new CreditLimitDetailResult(query.Level, columns, items);
    }

    private static int? ReadLevel(IDictionary<string, object> row)
    {
        var levelEntry = row.FirstOrDefault(
            entry => string.Equals(entry.Key, "Level", StringComparison.OrdinalIgnoreCase));
        if (levelEntry.Key is null || levelEntry.Value is null || levelEntry.Value is DBNull)
        {
            return null;
        }

        return Convert.ToInt32(levelEntry.Value, CultureInfo.InvariantCulture);
    }

    private static object? ReadValue(IDictionary<string, object> row, string column)
    {
        var entry = row.FirstOrDefault(
            item => string.Equals(item.Key, column, StringComparison.OrdinalIgnoreCase));
        return entry.Value is DBNull ? null : entry.Value;
    }
}
