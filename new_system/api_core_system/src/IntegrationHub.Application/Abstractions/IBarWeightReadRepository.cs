namespace IntegrationHub.Application.Abstractions;

public interface IBarWeightReadRepository
{
    Task<decimal?> CalculateAsync(string productCode, decimal bundleQuantity,
        decimal looseBarQuantity, CancellationToken cancellationToken);
}
