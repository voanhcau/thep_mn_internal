using System.Data;
using Dapper;
using IntegrationHub.Application.Abstractions;
using IntegrationHub.Application.Modules.Finance.CreditLimits;
using IntegrationHub.Domain.Finance;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Infrastructure.LegacySqlServer.Finance;

internal sealed class CreditLimitReadRepository(
    ILegacyDbConnectionFactory connectionFactory,
    IOptions<LegacyDatabaseOptions> options) : ICreditLimitReadRepository
{
    private readonly int _commandTimeout = options.Value.CommandTimeoutSeconds;

    public async Task<IReadOnlyList<CreditLimit>> GetAsync(
        GetCreditLimitsQuery query,
        CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT
                Ma_Dt AS PartnerCode,
                Ma_Hd AS ContractCode,
                CONVERT(decimal(19, 4), Tien_Tin_Chap) AS UnsecuredAmount,
                CONVERT(decimal(19, 4), Tien_Bao_Lanh) AS GuaranteeAmount,
                CONVERT(decimal(19, 4), Tien_Cam_Co) AS CollateralAmount,
                CONVERT(decimal(19, 4), Tien_Tin_Chap_Nt) AS UnsecuredForeignCurrencyAmount,
                CONVERT(decimal(19, 4), Tien_Bao_Lanh_Nt) AS GuaranteeForeignCurrencyAmount,
                CONVERT(decimal(19, 4), Tien_Cam_Co_Nt) AS CollateralForeignCurrencyAmount,
                Ngay_Bd AS StartDate,
                Ngay_Kt AS EndDate
            FROM dbo.vw_Tin_Dung
            WHERE Ngay_Bd <= @EffectiveDate
            AND Ma_Dt = @PartnerCode  
            AND Ma_Dt = @PartnerCode
            ORDER BY Ngay_Kt, Ngay_Bd, Ma_Hd;
            """;

        var parameters = new DynamicParameters();
        parameters.Add("PartnerCode", query.PartnerCode, DbType.AnsiString, size: 20);
        parameters.Add("EffectiveDate", query.EffectiveDate, DbType.Date);

        await using var connection = await connectionFactory.OpenConnectionAsync(cancellationToken);
        var command = new CommandDefinition(
            sql,
            parameters,
            commandTimeout: _commandTimeout,
            cancellationToken: cancellationToken);

        return (await connection.QueryAsync<CreditLimit>(command)).AsList();
    }
}
