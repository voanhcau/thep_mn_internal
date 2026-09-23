using System.Text;
using Dapper;
using IntegrationHub.Application.Abstractions;
using IntegrationHub.Application.Common;
using IntegrationHub.Application.Modules.MasterData.BilletBarems;
using IntegrationHub.Domain.MasterData;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Infrastructure.LegacySqlServer.MasterData;

internal sealed class BilletBaremReadRepository(
    ILegacyDbConnectionFactory connectionFactory,
    IOptions<LegacyDatabaseOptions> options) : IBilletBaremReadRepository
{
    private readonly int _commandTimeout = options.Value.CommandTimeoutSeconds;

    public async Task<PagedResult<BilletBarem>> SearchAsync(
        SearchBilletBaremsQuery query,
        CancellationToken cancellationToken)
    {
        var where = new StringBuilder(" WHERE 1 = 1");
        var parameters = new DynamicParameters();

        if (query.BilletType is not null)
        {
            where.Append(" AND Loai_Phoi = @BilletType");
            parameters.Add("BilletType", query.BilletType);
        }

        if (query.EffectiveFrom.HasValue)
        {
            where.Append(" AND Ngay_Ap >= @EffectiveFrom");
            parameters.Add("EffectiveFrom", query.EffectiveFrom.Value);
        }

        if (query.EffectiveTo.HasValue)
        {
            where.Append(" AND Ngay_Ap <= @EffectiveTo");
            parameters.Add("EffectiveTo", query.EffectiveTo.Value);
        }

        parameters.Add("Offset", (query.Page - 1) * query.PageSize);
        parameters.Add("PageSize", query.PageSize);

        var sql = $"""
            SELECT COUNT_BIG(1)
            FROM dbo.R81BAREMPHOI
            {where};

            SELECT
                Ident00 AS Id,
                Loai_Phoi AS BilletType,
                Ngay_Ap AS EffectiveDate,
                CONVERT(decimal(19, 4), Barem) AS Barem
            FROM dbo.R81BAREMPHOI
            {where}
            ORDER BY Ngay_Ap DESC, Ident00 DESC
            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
            """;

        await using var connection = await connectionFactory.OpenConnectionAsync(cancellationToken);
        var command = new CommandDefinition(
            sql,
            parameters,
            commandTimeout: _commandTimeout,
            cancellationToken: cancellationToken);
        using var result = await connection.QueryMultipleAsync(command);
        var totalItems = checked((int)await result.ReadSingleAsync<long>());
        var items = (await result.ReadAsync<BilletBarem>()).AsList();

        return new PagedResult<BilletBarem>(items, query.Page, query.PageSize, totalItems);
    }

    public async Task<BilletBarem?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT
                Ident00 AS Id,
                Loai_Phoi AS BilletType,
                Ngay_Ap AS EffectiveDate,
                CONVERT(decimal(19, 4), Barem) AS Barem
            FROM dbo.R81BAREMPHOI
            WHERE Ident00 = @Id;
            """;

        await using var connection = await connectionFactory.OpenConnectionAsync(cancellationToken);
        var command = new CommandDefinition(
            sql,
            new { Id = id },
            commandTimeout: _commandTimeout,
            cancellationToken: cancellationToken);

        return await connection.QuerySingleOrDefaultAsync<BilletBarem>(command);
    }
}
