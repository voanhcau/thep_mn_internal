using IntegrationHub.Application.Abstractions;

namespace IntegrationHub.Application.Modules.Orders;

public sealed class CustomerOrderSyncService(ICustomerOrderWriteRepository repository)
{
    public async Task<int> SyncAsync(int headerId, CustomerOrderSyncRequest request, CancellationToken cancellationToken)
    {
        if (headerId <= 0 || request is null || request.Rows is null ||
            request.Rows.Count == 0 || request.Rows.Count > 500 ||
            request.Rows.Any(row => row is null) ||
            request.Rows.Any(row => row.IdWebHeader != headerId || row.IdWebDetail <= 0 ||
                row.NgayCt == default || row.SoLuong < 0 || row.SoLuongBo < 0 ||
                row.SoLuongCayLe < 0 || row.SoLuongCay < 0 || row.SoLuongCnxx < 0) ||
            request.Rows.Select(row => row.IdWebDetail).Distinct().Count() != request.Rows.Count)
        {
            throw new ArgumentException("Dữ liệu dòng hàng hoặc mã đơn không hợp lệ.");
        }

        foreach (var row in request.Rows)
        {
            if (new[] { row.MaDt, row.SoDh, row.SoXe, row.SoXaLanTau, row.PtVc,
                    row.HtTt, row.MaHd, row.MaPlCtrinh, row.IdDtVc, row.TenDtVc,
                    row.DienGiai, row.MaVt, row.TenVt, row.Dvt, row.BoBe,
                    row.BoThang, row.MaKhoN, row.CreateLog, row.LastModifyLog }
                    .Any(value => value is null) ||
                row.MaDt.Length > 20 || row.SoDh.Length > 20 || row.SoXe.Length > 20 ||
                row.SoXaLanTau.Length > 20 || row.PtVc.Length > 20 || row.HtTt.Length > 20 ||
                row.MaHd.Length > 20 || row.MaPlCtrinh.Length > 20 || row.IdDtVc.Length > 20 ||
                row.TenDtVc.Length > 100 || row.DienGiai.Length > 500 || row.MaVt.Length > 20 ||
                row.TenVt.Length > 500 || row.Dvt.Length > 500 || row.BoBe.Length > 20 ||
                row.BoThang.Length > 20 || row.MaKhoN.Length > 20 || row.CreateLog.Length > 50 ||
                row.LastModifyLog.Length > 50)
            {
                throw new ArgumentException("Một trường trong đơn hàng vượt quá độ dài cho phép của R04CTDH.");
            }
        }

        await repository.ReplaceAsync(headerId, request.Rows, cancellationToken);
        return request.Rows.Count;
    }
}
