using IntegrationHub.Api.Authentication;
using IntegrationHub.Application.Modules.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationHub.Api.Controllers;

[ApiController]
[Route("api/v1/orders/customer-orders")]
[Authorize(Policy = ApiScopes.OrdersWrite)]
public sealed class CustomerOrdersController(CustomerOrderSyncService service) : ControllerBase
{
    [HttpPut("{headerId:int}/r04ctdh")]
    public async Task<IActionResult> Sync(
        int headerId,
        [FromBody] CustomerOrderSyncRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var count = await service.SyncAsync(headerId, request, cancellationToken);
            return Ok(new { headerId, rowCount = count });
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new { error = exception.Message });
        }
    }
}
