using IntegrationHub.Application.Abstractions;
using IntegrationHub.Domain.Finance;

namespace IntegrationHub.Application.Modules.Finance.CreditLimits;

public sealed class CreditLimitService(ICreditLimitReadRepository repository)
{
    public Task<IReadOnlyList<CreditLimit>> GetAsync(
        GetCreditLimitsQuery query,
        CancellationToken cancellationToken)
    {
        var partnerCode = query.PartnerCode?.Trim();

        if (string.IsNullOrWhiteSpace(partnerCode))
        {
            throw new ArgumentException("ma_dt is required.");
        }

        if (partnerCode.Length > 20)
        {
            throw new ArgumentException("ma_dt must not exceed 20 characters.");
        }

        if (!query.EffectiveDate.HasValue)
        {
            throw new ArgumentException("ngay_hl is required.");
        }

        var normalized = new GetCreditLimitsQuery(partnerCode, query.EffectiveDate.Value.Date);
        return repository.GetAsync(normalized, cancellationToken);
    }
}
