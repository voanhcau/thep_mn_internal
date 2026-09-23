using System.Data;
using System.Globalization;
using Dapper;
using IntegrationHub.Application.Abstractions;
using IntegrationHub.Application.Modules.Finance.AggregateCreditLimits;
using IntegrationHub.Domain.Finance;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Infrastructure.LegacySqlServer.Finance;

internal sealed class AggregateCreditLimitReadRepository(
    ILegacyDbConnectionFactory connectionFactory,
    IOptions<LegacyDatabaseOptions> options) : IAggregateCreditLimitReadRepository
{
    private readonly int _commandTimeout = options.Value.CommandTimeoutSeconds;

    public async Task<IReadOnlyList<CreditDashboardRow>> GetAsync(
        GetAggregateCreditLimitsQuery query,
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
        var rows = await connection.QueryAsync<CreditDashboardRowData>(command);

        return rows
            .Where(row => AsInt(row.Stt).HasValue && AsBool(row.Bold).HasValue)
            .Select(row => Map(query.PartnerCode!, row))
            .ToArray();
    }

    private static CreditDashboardRow Map(string partnerCode, CreditDashboardRowData row) => new(
        partnerCode,
        AsInt(row.Stt)!.Value,
        AsString(row.Noi_Dung),
        AsDecimal(row.TTien),
        AsDecimal(row.TTien_Nt),
        AsDate(row.Ngay_Ct),
        AsDate(row.NGay_QH),
        AsDecimal(row.So_Luong),
        AsDecimal(row.So_Luong_LXH),
        AsString(row.Ht_Tt),
        AsString(row.So_DH_KH),
        AsString(row.Dien_Giai),
        AsString(row.Ma_Kho),
        AsString(row.So_Xe),
        AsString(row.So_Xa_Lan_Tau),
        AsString(row.Ht_Gn),
        AsString(row.Ma_CTrinh),
        AsString(row.So_Qd),
        AsDate(row.Ngay_Qd),
        AsString(row.So_LXH),
        AsBool(row.Bold)!.Value,
        AsInt(row.Level),
        AsString(row.Ten_Dt));

    private static string? AsString(object? value)
    {
        if (value is null || value is DBNull)
        {
            return null;
        }

        var text = Convert.ToString(value, CultureInfo.InvariantCulture)?.Trim();
        return string.IsNullOrEmpty(text) || string.Equals(text, "NULL", StringComparison.OrdinalIgnoreCase)
            ? null
            : text;
    }

    private static decimal AsDecimal(object? value) =>
        decimal.TryParse(AsString(value), NumberStyles.Any, CultureInfo.InvariantCulture, out var number)
            ? number
            : 0;

    private static int? AsInt(object? value) =>
        int.TryParse(AsString(value), NumberStyles.Integer, CultureInfo.InvariantCulture, out var number)
            ? number
            : null;

    private static bool? AsBool(object? value)
    {
        if (value is bool boolean)
        {
            return boolean;
        }

        return AsInt(value) is int number ? number != 0 : null;
    }

    private static DateTime? AsDate(object? value)
    {
        if (value is DateTime date)
        {
            return date.Year > 1900 ? date : null;
        }

        return DateTime.TryParse(AsString(value), CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed)
            && parsed.Year > 1900
            ? parsed
            : null;
    }

    private sealed class CreditDashboardRowData
    {
        public object? Stt { get; init; }
        public object? Noi_Dung { get; init; }
        public object? TTien { get; init; }
        public object? TTien_Nt { get; init; }
        public object? Ngay_Ct { get; init; }
        public object? NGay_QH { get; init; }
        public object? So_Luong { get; init; }
        public object? So_Luong_LXH { get; init; }
        public object? Ht_Tt { get; init; }
        public object? So_DH_KH { get; init; }
        public object? Dien_Giai { get; init; }
        public object? Ma_Kho { get; init; }
        public object? So_Xe { get; init; }
        public object? So_Xa_Lan_Tau { get; init; }
        public object? Ht_Gn { get; init; }
        public object? Ma_CTrinh { get; init; }
        public object? So_Qd { get; init; }
        public object? Ngay_Qd { get; init; }
        public object? So_LXH { get; init; }
        public object? Bold { get; init; }
        public object? Level { get; init; }
        public object? Ten_Dt { get; init; }
    }
}
