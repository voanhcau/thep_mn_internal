using IntegrationHub.Application.Modules.Orders;

namespace IntegrationHub.Application.Abstractions;

public interface ICustomerOrderWriteRepository
{
    Task ReplaceAsync(int headerId, IReadOnlyList<R04CtdhRow> rows, CancellationToken cancellationToken);
}
