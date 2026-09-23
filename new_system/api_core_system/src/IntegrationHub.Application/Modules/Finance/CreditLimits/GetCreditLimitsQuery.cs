namespace IntegrationHub.Application.Modules.Finance.CreditLimits;

public sealed record GetCreditLimitsQuery(string? PartnerCode, DateTime? EffectiveDate);
