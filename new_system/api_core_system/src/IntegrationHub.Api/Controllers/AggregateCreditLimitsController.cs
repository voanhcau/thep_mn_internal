using IntegrationHub.Api.Authentication;
using IntegrationHub.Application.Modules.Finance.AggregateCreditLimits;
using IntegrationHub.Domain.Finance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationHub.Api.Controllers;

[ApiController]
[Route("api/v1/finance/credit-limit-summaries")]
[Authorize(Policy = ApiScopes.FinanceRead)]
public sealed class AggregateCreditLimitsController(AggregateCreditLimitService service)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IReadOnlyList<CreditDashboardRow>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IReadOnlyList<CreditDashboardRow>>> Get(
        [FromQuery(Name = "ngay_ct")] DateTime? documentDate,
        [FromQuery(Name = "ma_dt")] string? partnerCode,
        [FromQuery(Name = "is_trieu")] int isInMillions = 1,
        [FromQuery(Name = "is_th")] int isAggregate = 0,
        [FromQuery(Name = "language_id")] string? languageId = "V",
        [FromQuery(Name = "ma_dvcs")] string? businessUnitCode = "A01",
        CancellationToken cancellationToken = default)
    {
        try
        {
            var query = new GetAggregateCreditLimitsQuery(
                documentDate,
                partnerCode,
                isInMillions,
                isAggregate,
                languageId,
                businessUnitCode);

            return Ok(await service.GetAsync(query, cancellationToken));
        }
        catch (AggregateCreditLimitQueryValidationException exception)
        {
            return ValidationProblem(new ValidationProblemDetails(
                new Dictionary<string, string[]>
                {
                    ["query"] = [exception.Message]
                }));
        }
    }
}
