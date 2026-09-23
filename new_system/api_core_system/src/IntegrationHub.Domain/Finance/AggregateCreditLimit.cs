namespace IntegrationHub.Domain.Finance;

/// <summary>
/// Aggregate credit-limit information returned by dbo.sp_rptSODTT02_Check.
/// Only report group rows (Bold = 1 and a non-empty ColumnID) are exposed.
/// </summary>
public sealed record AggregateCreditLimit(
    string? PartnerCode,
    string? ContractCode,
    decimal? UnsecuredLimit,
    decimal? GuaranteeLimit,
    decimal? CollateralLimit,
    decimal? TotalLimit,
    decimal? ConsignedGoodsBalance,
    decimal? PendingOrderAmount,
    decimal? WarehouseIssueAmount,
    decimal? ReceiptAmount,
    decimal? UnclosedWarehouseIssueAmount,
    decimal? UnclosedInvoiceAmount,
    decimal? NotDueReceivableAmount,
    decimal? DueAmount,
    decimal? OverdueAmount,
    decimal? RemainingLimit,
    decimal? DailyOrderAmount,
    decimal? CumulativeInvoiceAmount,
    decimal? DailyReceiptAmount,
    decimal? CumulativeReceiptAmount,
    decimal? TotalDebt,
    decimal? UsedUnsecuredLimit,
    decimal? OverdueDays,
    bool Bold,
    string ColumnId,
    string? ColumnName,
    int? Level);
