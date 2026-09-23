using IntegrationHub.Application.Modules.Finance.AggregateCreditLimits;
using IntegrationHub.Domain.Finance;

namespace IntegrationHub.Application.Abstractions;

public interface IAggregateCreditLimitReadRepository
{
    Task<IReadOnlyList<CreditDashboardRow>> GetAsync(
        GetAggregateCreditLimitsQuery query,
        CancellationToken cancellationToken);
}
