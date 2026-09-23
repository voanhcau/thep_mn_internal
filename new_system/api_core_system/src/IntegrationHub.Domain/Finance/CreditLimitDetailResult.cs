namespace IntegrationHub.Domain.Finance;

/// <summary>
/// Dynamic report rows returned by dbo.sp_rptSODTC01_Check for one allowed detail level.
/// Column names are preserved because the legacy report can add business columns over time.
/// </summary>
public sealed record CreditLimitDetailResult(
    int Level,
    IReadOnlyList<string> Columns,
    IReadOnlyList<IReadOnlyDictionary<string, object?>> Items);
