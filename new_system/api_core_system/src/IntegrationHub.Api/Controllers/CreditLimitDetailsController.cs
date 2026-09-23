using IntegrationHub.Api.Authentication;
using IntegrationHub.Application.Modules.Finance.CreditLimitDetails;
using IntegrationHub.Domain.Finance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationHub.Api.Controllers;

[ApiController]
[Route("api/v1/finance/credit-limit-details")]
[Authorize(Policy = ApiScopes.FinanceRead)]
public sealed class CreditLimitDetailsController(CreditLimitDetailService service)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<CreditLimitDetailResult>(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreditLimitDetailResult>> Get(
        [FromQuery(Name = "ngay_ct")] DateTime? documentDate,
        [FromQuery(Name = "ma_dt")] string? partnerCode,
        [FromQuery(Name = "level")] int level,
        [FromQuery(Name = "language_id")] string? languageId = "V",
        [FromQuery(Name = "ma_dvcs")] string? businessUnitCode = "A01",
        CancellationToken cancellationToken = default)
    {
        try
        {
            var query = new GetCreditLimitDetailsQuery(
                documentDate,
                partnerCode,
                level,
                languageId,
                businessUnitCode);
            return Ok(await service.GetAsync(query, cancellationToken));
        }
        catch (CreditLimitDetailQueryValidationException exception)
        {
            return ValidationProblem(new ValidationProblemDetails(
                new Dictionary<string, string[]>
                {
                    ["query"] = [exception.Message]
                }));
        }
    }
}
