using System.Data;
using Dapper;
using IntegrationHub.Application.Abstractions;
using IntegrationHub.Application.Modules.Orders;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Infrastructure.LegacySqlServer.Orders;

internal sealed class CustomerOrderWriteRepository(
    ILegacyDbConnectionFactory connectionFactory,
    IOptions<LegacyDatabaseOptions> options) : ICustomerOrderWriteRepository
{
    private readonly int _commandTimeout = options.Value.CommandTimeoutSeconds;

    public async Task ReplaceAsync(
        int headerId, IReadOnlyList<R04CtdhRow> rows, CancellationToken cancellationToken)
    {
        await using var connection = await connectionFactory.OpenConnectionAsync(cancellationToken);
        await using var transaction = await connection.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            var lockResult = await connection.ExecuteScalarAsync<int>(new CommandDefinition(
                "DECLARE @lock_result int; EXEC @lock_result = sys.sp_getapplock @Resource, 'Exclusive', 'Transaction', 10000; SELECT @lock_result;",
                new { Resource = $"R04CTDH:WebHeader:{headerId}" },
                transaction, _commandTimeout, cancellationToken: cancellationToken));
            if (lockResult < 0)
            {
                throw new InvalidOperationException("Could not lock R04CTDH for this order.");
            }

            await connection.ExecuteAsync(new CommandDefinition(
                "DELETE FROM dbo.R04CTDH WHERE ID_Web_Header = @HeaderId;",
                new { HeaderId = headerId }, transaction, _commandTimeout,
                cancellationToken: cancellationToken));

            const string insertSql = """
                INSERT INTO dbo.R04CTDH (
                    ID_Web_Header, ID_Web_Detail, Ma_Dt, Ngay_Ct, So_Dh, So_Xe,
                    So_Xa_Lan_Tau, Pt_Vc, Ht_Tt, Ma_Hd, Ma_PLCtrinh, ID_Dt_VC,
                    Ten_Dt_Vc, Dien_Giai, Ma_Vt, Ten_Vt, Dvt, So_Luong_Bo,
                    So_Luong_Cay_Le, So_Luong_Cay, So_Luong, Bo_Be, Bo_Thang,
                    Is_CNXX, So_Luong_CNXX, Ma_KhoN, Create_Log, LastModify_Log)
                VALUES (
                    @IdWebHeader, @IdWebDetail, @MaDt, @NgayCt, @SoDh, @SoXe,
                    @SoXaLanTau, @PtVc, @HtTt, @MaHd, @MaPlCtrinh, @IdDtVc,
                    @TenDtVc, @DienGiai, @MaVt, @TenVt, @Dvt, @SoLuongBo,
                    @SoLuongCayLe, @SoLuongCay, @SoLuong, @BoBe, @BoThang,
                    @IsCnxx, @SoLuongCnxx, @MaKhoN, @CreateLog, @LastModifyLog);
                """;
            foreach (var row in rows)
            {
                await connection.ExecuteAsync(new CommandDefinition(
                    insertSql, row, transaction, _commandTimeout,
                    cancellationToken: cancellationToken));
            }

            await transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await transaction.RollbackAsync(CancellationToken.None);
            throw;
        }
    }
}
