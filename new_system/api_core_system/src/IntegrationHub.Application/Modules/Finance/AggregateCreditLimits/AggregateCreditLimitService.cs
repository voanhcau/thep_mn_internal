using IntegrationHub.Application.Abstractions;
using IntegrationHub.Domain.Finance;

namespace IntegrationHub.Application.Modules.Finance.AggregateCreditLimits;

public sealed class AggregateCreditLimitService(IAggregateCreditLimitReadRepository repository)
{
    public Task<IReadOnlyList<CreditDashboardRow>> GetAsync(
        GetAggregateCreditLimitsQuery query,
        CancellationToken cancellationToken)
    {
        if (!query.DocumentDate.HasValue)
        {
            throw new AggregateCreditLimitQueryValidationException("ngay_ct is required.");
        }

        var partnerCode = query.PartnerCode?.Trim();
        if (string.IsNullOrWhiteSpace(partnerCode))
        {
            throw new AggregateCreditLimitQueryValidationException("ma_dt is required.");
        }

        if (partnerCode.Length > 20)
        {
            throw new AggregateCreditLimitQueryValidationException(
                "ma_dt must not exceed 20 characters.");
        }

        if (query.IsInMillions is not (0 or 1))
        {
            throw new AggregateCreditLimitQueryValidationException(
                "is_trieu must be 0 or 1.");
        }

        if (query.IsAggregate is not (0 or 1))
        {
            throw new AggregateCreditLimitQueryValidationException(
                "is_th must be 0 or 1.");
        }

        var languageId = query.LanguageId?.Trim();
        if (string.IsNullOrWhiteSpace(languageId) || languageId.Length > 10)
        {
            throw new AggregateCreditLimitQueryValidationException(
                "language_id is required and must not exceed 10 characters.");
        }

        var businessUnitCode = query.BusinessUnitCode?.Trim();
        if (string.IsNullOrWhiteSpace(businessUnitCode) || businessUnitCode.Length > 10)
        {
            throw new AggregateCreditLimitQueryValidationException(
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
