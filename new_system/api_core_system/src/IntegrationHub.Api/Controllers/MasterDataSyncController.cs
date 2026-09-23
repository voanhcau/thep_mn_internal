using IntegrationHub.Api.Authentication;
using IntegrationHub.Application.Modules.MasterData.Sync;
using IntegrationHub.Domain.MasterData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationHub.Api.Controllers;

[ApiController]
[Route("api/v1/master-data/sync")]
[Authorize(Policy = ApiScopes.MasterRead)]
public sealed class MasterDataSyncController(MasterDataSyncService service) : ControllerBase
{
    [HttpGet("catalog")]
    [ProducesResponseType<IReadOnlyList<string>>(StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyList<string>> GetCatalog() => Ok(service.GetCatalog());

    [HttpGet("{entity}")]
    [ProducesResponseType<MasterDataSyncPage>(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MasterDataSyncPage>> GetPage(
        string entity,
        [FromQuery] int page = 1,
        [FromQuery(Name = "page_size")] int pageSize = 500,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return Ok(await service.GetPageAsync(
                new GetMasterDataSyncPageQuery(entity, page, pageSize),
                cancellationToken));
        }
        catch (MasterDataSyncQueryValidationException exception)
        {
            return ValidationProblem(new ValidationProblemDetails(
                new Dictionary<string, string[]>
                {
                    ["query"] = [exception.Message]
                }));
        }
    }
}
