using IntegrationHub.Api.Authentication;
using IntegrationHub.Application.Modules.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationHub.Api.Controllers;

[ApiController]
[Route("api/v1/orders/driver-vehicle")]
[Authorize(Policy = ApiScopes.MasterRead)]
public sealed class DriverVehiclesController(DriverVehicleLookupService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Find(
        [FromQuery(Name = "identity_number")] string? identityNumber,
        [FromQuery(Name = "document_date")] DateOnly? reportDate,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await service.FindAsync(identityNumber, reportDate, cancellationToken);
            return result is null
                ? NotFound(new { error = "Không tìm thấy thông tin tài xế trong 3 năm gần nhất." })
                : Ok(result);
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new { error = exception.Message });
        }
    }
}
