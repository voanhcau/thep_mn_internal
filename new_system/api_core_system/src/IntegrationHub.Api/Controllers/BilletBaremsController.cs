using IntegrationHub.Api.Authentication;
using IntegrationHub.Application.Common;
using IntegrationHub.Application.Modules.MasterData.BilletBarems;
using IntegrationHub.Domain.MasterData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationHub.Api.Controllers;

[ApiController]
[Route("api/v1/master-data/billet-barems")]
[Authorize(Policy = ApiScopes.MasterRead)]
public sealed class BilletBaremsController(BilletBaremService service) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<PagedResult<BilletBarem>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedResult<BilletBarem>>> Search(
        [FromQuery] string? billetType,
        [FromQuery] DateTime? effectiveFrom,
        [FromQuery] DateTime? effectiveTo,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 50,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var query = new SearchBilletBaremsQuery(
                billetType,
                effectiveFrom,
                effectiveTo,
                page,
                pageSize);
            return Ok(await service.SearchAsync(query, cancellationToken));
        }
        catch (ArgumentException exception)
        {
            return ValidationProblem(new ValidationProblemDetails(
                new Dictionary<string, string[]>
                {
                    ["query"] = [exception.Message]
                }));
        }
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType<BilletBarem>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BilletBarem>> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        if (id <= 0)
        {
            return ValidationProblem(new ValidationProblemDetails(
                new Dictionary<string, string[]>
                {
                    ["id"] = ["id must be greater than zero."]
                }));
        }

        var item = await service.GetByIdAsync(id, cancellationToken);
        return item is null ? NotFound() : Ok(item);
    }
}
