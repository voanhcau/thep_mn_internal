using IntegrationHub.Api.Authentication;
using IntegrationHub.Application.Modules.Finance.CreditLimits;
using IntegrationHub.Domain.Finance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationHub.Api.Controllers;

[ApiController]
[Route("api/v1/finance/credit-limits")]
[Authorize(Policy = ApiScopes.FinanceRead)]
public sealed class CreditLimitsController(CreditLimitService service) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IReadOnlyList<CreditLimit>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IReadOnlyList<CreditLimit>>> Get(
        [FromQuery(Name = "ma_dt")] string? partnerCode,
        [FromQuery(Name = "ngay_hl")] DateTime? effectiveDate,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var query = new GetCreditLimitsQuery(partnerCode, effectiveDate);
            return Ok(await service.GetAsync(query, cancellationToken));
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
}
