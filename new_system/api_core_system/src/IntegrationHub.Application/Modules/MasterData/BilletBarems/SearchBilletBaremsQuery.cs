namespace IntegrationHub.Application.Modules.MasterData.BilletBarems;

public sealed record SearchBilletBaremsQuery(
    string? BilletType,
    DateTime? EffectiveFrom,
    DateTime? EffectiveTo,
    int Page = 1,
    int PageSize = 50)
{
    public const int MaxPageSize = 200;

    public SearchBilletBaremsQuery Normalize() => this with
    {
        BilletType = string.IsNullOrWhiteSpace(BilletType) ? null : BilletType.Trim(),
        Page = Math.Max(1, Page),
        PageSize = Math.Clamp(PageSize, 1, MaxPageSize)
    };
}
