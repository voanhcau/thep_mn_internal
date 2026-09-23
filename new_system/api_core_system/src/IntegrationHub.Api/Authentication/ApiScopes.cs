namespace IntegrationHub.Api.Authentication;

public static class ApiScopes
{
    public const string MasterRead = "master.read";
    public const string OrdersRead = "orders.read";
    public const string OrdersWrite = "orders.write";
    public const string FinanceRead = "finance.read";
    public const string DeliveryRead = "delivery.read";
    public const string DocumentsRead = "documents.read";
    public const string SyncAdmin = "sync.admin";
    public const string OdooCall = "odoo.call";

    public static readonly string[] All =
    [
        MasterRead,
        OrdersRead,
        OrdersWrite,
        FinanceRead,
        DeliveryRead,
        DocumentsRead,
        SyncAdmin,
        OdooCall
    ];
}
