using IntegrationHub.Application.Modules.Finance.CreditLimits;
using IntegrationHub.Domain.Finance;

namespace IntegrationHub.Application.Abstractions;

public interface ICreditLimitReadRepository
{
    Task<IReadOnlyList<CreditLimit>> GetAsync(
        GetCreditLimitsQuery query,
        CancellationToken cancellationToken);
}
