namespace IntegrationHub.Application.Modules.Finance.CreditLimitDetails;

public sealed record GetCreditLimitDetailsQuery(
    DateTime? DocumentDate,
    string? PartnerCode,
    int Level,
    string? LanguageId,
    string? BusinessUnitCode);
