namespace IntegrationHub.Domain.MasterData;

/// <summary>Domain representation of legacy table dbo.R81BAREMPHOI.</summary>
public sealed record BilletBarem(
    int Id,
    string BilletType,
    DateTime EffectiveDate,
    decimal Barem);
