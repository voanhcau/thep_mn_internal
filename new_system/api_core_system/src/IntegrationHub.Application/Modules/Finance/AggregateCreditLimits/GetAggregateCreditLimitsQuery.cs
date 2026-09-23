namespace IntegrationHub.Application.Modules.Finance.AggregateCreditLimits;

public sealed record GetAggregateCreditLimitsQuery(
    DateTime? DocumentDate,
    string? PartnerCode,
    int IsInMillions,
    int IsAggregate,
    string? LanguageId,
    string? BusinessUnitCode);
