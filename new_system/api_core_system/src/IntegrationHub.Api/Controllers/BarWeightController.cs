using IntegrationHub.Api.Authentication;
using IntegrationHub.Application.Modules.MasterData.BarWeight;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationHub.Api.Controllers;

[ApiController]
[Route("api/v1/master-data/bar-weight")]
[Authorize(Policy = ApiScopes.MasterRead)]
public sealed class BarWeightController(BarWeightService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Calculate(
        [FromQuery(Name = "ma_vt")] string? productCode,
        [FromQuery(Name = "so_bo")] decimal bundleQuantity,
        [FromQuery(Name = "so_cay_le")] decimal looseBarQuantity,
        CancellationToken cancellationToken)
    {
        try
        {
            var weight = await service.CalculateAsync(productCode, bundleQuantity,
                looseBarQuantity, cancellationToken);
            return weight is null or <= 0
                ? NotFound(new { error = "Không tìm thấy kết quả barem cho vật tư." })
                : Ok(new { weightKg = weight.Value });
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new { error = exception.Message });
        }
    }
}
