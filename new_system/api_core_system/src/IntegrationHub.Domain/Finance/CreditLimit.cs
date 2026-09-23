namespace IntegrationHub.Domain.Finance;

/// <summary>Credit limit exposed by the legacy dbo.vw_Tin_Dung view.</summary>
public sealed record CreditLimit(
    string PartnerCode,
    string ContractCode,
    decimal UnsecuredAmount,
    decimal GuaranteeAmount,
    decimal CollateralAmount,
    decimal UnsecuredForeignCurrencyAmount,
    decimal GuaranteeForeignCurrencyAmount,
    decimal CollateralForeignCurrencyAmount,
    DateTime StartDate,
    DateTime EndDate);
