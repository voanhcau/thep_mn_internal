namespace IntegrationHub.Domain.Finance;

/// <summary>
/// One row returned by dbo.sp_rptSODTC01_Check.
/// Bold rows are report totals; non-bold rows are the drill-down records.
/// </summary>
public sealed record CreditDashboardRow(
    string PartnerCode,
    int Sequence,
    string? Content,
    decimal Amount,
    decimal ForeignAmount,
    DateTime? DocumentDate,
    DateTime? DueDate,
    decimal Quantity,
    decimal DeliveryOrderQuantity,
    string? PaymentMethod,
    string? CustomerOrderNumber,
    string? Description,
    string? WarehouseCode,
    string? VehicleNumber,
    string? BargeNumber,
    string? DeliveryMethod,
    string? ProjectCode,
    string? DecisionNumber,
    DateTime? DecisionDate,
    string? DeliveryOrderNumber,
    bool Bold,
    int? Level,
    string? CustomerName);
