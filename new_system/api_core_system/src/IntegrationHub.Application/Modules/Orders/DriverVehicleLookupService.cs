using System.Text.RegularExpressions;
using IntegrationHub.Application.Abstractions;
using IntegrationHub.Domain.Orders;

namespace IntegrationHub.Application.Modules.Orders;

public sealed class DriverVehicleLookupService(IDriverVehicleLookupRepository repository)
{
    public Task<DriverVehicleInfo?> FindAsync(
        string? identityNumber,
        DateOnly? reportDate,
        CancellationToken cancellationToken)
    {
        var digits = Regex.Replace(identityNumber ?? string.Empty, "[^0-9]", string.Empty);
        if (digits.Length is not (9 or 12))
        {
            throw new ArgumentException("CCCD/CMT phải gồm 9 hoặc 12 chữ số.");
        }

        var normalizedIdentity = string.Join("-",
            Enumerable.Range(0, digits.Length / 3).Select(index => digits.Substring(index * 3, 3)));
        var effectiveDate = reportDate ?? DateOnly.FromDateTime(DateTime.Today);
        return repository.FindAsync(
            normalizedIdentity,
            effectiveDate.ToDateTime(TimeOnly.MinValue),
            cancellationToken);
    }
}
