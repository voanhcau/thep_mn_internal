using IntegrationHub.Domain.Orders;

namespace IntegrationHub.Application.Abstractions;

public interface IDriverVehicleLookupRepository
{
    Task<DriverVehicleInfo?> FindAsync(
        string identityNumber,
        DateTime reportDate,
        CancellationToken cancellationToken);
}
