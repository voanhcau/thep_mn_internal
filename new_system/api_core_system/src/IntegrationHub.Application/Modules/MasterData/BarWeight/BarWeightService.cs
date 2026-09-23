using IntegrationHub.Application.Abstractions;

namespace IntegrationHub.Application.Modules.MasterData.BarWeight;

public sealed class BarWeightService(IBarWeightReadRepository repository)
{
    public async Task<decimal?> CalculateAsync(string? productCode, decimal bundleQuantity,
        decimal looseBarQuantity, CancellationToken cancellationToken)
    {
        productCode = productCode?.Trim();
        if (string.IsNullOrWhiteSpace(productCode) || productCode.Length > 20 ||
            !productCode.StartsWith("BD", StringComparison.OrdinalIgnoreCase) ||
            bundleQuantity < 0 || looseBarQuantity < 0 ||
            bundleQuantity != decimal.Truncate(bundleQuantity) ||
            looseBarQuantity != decimal.Truncate(looseBarQuantity) ||
            bundleQuantity + looseBarQuantity <= 0)
        {
            throw new ArgumentException("Mã thép cây hoặc số bó/cây lẻ không hợp lệ.");
        }

        return await repository.CalculateAsync(productCode, bundleQuantity,
            looseBarQuantity, cancellationToken);
    }
}
