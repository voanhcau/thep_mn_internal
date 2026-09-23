using IntegrationHub.Application.Abstractions;
using IntegrationHub.Domain.Finance;

namespace IntegrationHub.Application.Modules.Finance.CreditLimitDetails;

public sealed class CreditLimitDetailService(ICreditLimitDetailReadRepository repository)
{
    private static readonly int[] AllowedLevels = [4, 6, 10, 12];

    public Task<CreditLimitDetailResult> GetAsync(
        GetCreditLimitDetailsQuery query,
        CancellationToken cancellationToken)
    {
        if (!query.DocumentDate.HasValue)
        {
            throw new CreditLimitDetailQueryValidationException("ngay_ct is required.");
        }

        var partnerCode = query.PartnerCode?.Trim();
        if (string.IsNullOrWhiteSpace(partnerCode) || partnerCode.Length > 20)
        {
            throw new CreditLimitDetailQueryValidationException(
                "ma_dt is required and must not exceed 20 characters.");
        }

        if (!AllowedLevels.Contains(query.Level))
        {
            throw new CreditLimitDetailQueryValidationException(
                "level must be one of 4, 6, 10 or 12.");
        }

        var languageId = query.LanguageId?.Trim();
        if (string.IsNullOrWhiteSpace(languageId) || languageId.Length > 10)
        {
            throw new CreditLimitDetailQueryValidationException(
                "language_id is required and must not exceed 10 characters.");
        }

        var businessUnitCode = query.BusinessUnitCode?.Trim();
        if (string.IsNullOrWhiteSpace(businessUnitCode) || businessUnitCode.Length > 10)
        {
            throw new CreditLimitDetailQueryValidationException(
                "ma_dvcs is required and must not exceed 10 characters.");
        }

        var normalized = query with
        {
            DocumentDate = query.DocumentDate.Value.Date,
            PartnerCode = partnerCode,
            LanguageId = languageId,
            BusinessUnitCode = businessUnitCode
        };

        return repository.GetAsync(normalized, cancellationToken);
    }
}
