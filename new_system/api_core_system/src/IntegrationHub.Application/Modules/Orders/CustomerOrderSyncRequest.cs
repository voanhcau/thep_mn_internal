namespace IntegrationHub.Application.Modules.Orders;

public sealed class CustomerOrderSyncRequest
{
    public List<R04CtdhRow> Rows { get; init; } = [];
}

public sealed class R04CtdhRow
{
    public int IdWebHeader { get; init; }
    public int IdWebDetail { get; init; }
    public string MaDt { get; init; } = "";
    public DateTime NgayCt { get; init; }
    public string SoDh { get; init; } = "";
    public string SoXe { get; init; } = "";
    public string SoXaLanTau { get; init; } = "";
    public string PtVc { get; init; } = "";
    public string HtTt { get; init; } = "";
    public string MaHd { get; init; } = "";
    public string MaPlCtrinh { get; init; } = "";
    public string IdDtVc { get; init; } = "";
    public string TenDtVc { get; init; } = "";
    public string DienGiai { get; init; } = "";
    public string MaVt { get; init; } = "";
    public string TenVt { get; init; } = "";
    public string Dvt { get; init; } = "";
    public decimal SoLuongBo { get; init; }
    public decimal SoLuongCayLe { get; init; }
    public decimal SoLuongCay { get; init; }
    public decimal SoLuong { get; init; }
    public string BoBe { get; init; } = "";
    public string BoThang { get; init; } = "";
    public bool IsCnxx { get; init; }
    public decimal SoLuongCnxx { get; init; }
    public string MaKhoN { get; init; } = "";
    public string CreateLog { get; init; } = "";
    public string LastModifyLog { get; init; } = "";
}
