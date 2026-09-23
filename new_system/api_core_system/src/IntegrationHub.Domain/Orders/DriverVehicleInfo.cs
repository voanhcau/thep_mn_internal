namespace IntegrationHub.Domain.Orders;

/// <summary>
/// Most recent driver and vehicle information returned by dbo.sp_GetTenDtVcsoxe.
/// </summary>
public sealed record DriverVehicleInfo(
    string DriverName,
    string VehicleNumber,
    string BargeNumber);
