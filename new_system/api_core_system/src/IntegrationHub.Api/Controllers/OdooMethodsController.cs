using System.Text.Json;
using IntegrationHub.Api.Authentication;
using IntegrationHub.Application.Modules.Odoo.MethodCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationHub.Api.Controllers;

[ApiController]
[Route("api/v1/odoo/methods")]
[Authorize(Policy = ApiScopes.OdooCall)]
public sealed class OdooMethodsController(OdooMethodCallService service) : ControllerBase
{
    [HttpPost("call")]
    [ProducesResponseType<OdooMethodCallResult>(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status502BadGateway)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status503ServiceUnavailable)]
    public async Task<ActionResult<OdooMethodCallResult>> Call(
        [FromBody] OdooMethodCallRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new OdooMethodCall(
                request.Model,
                request.Method,
                request.UserId,
                request.RecordIds,
                request.Vals,
                request.Args,
                request.Kwargs,
                request.Context);
            return Ok(await service.CallAsync(command, cancellationToken));
        }
        catch (OdooMethodCallValidationException exception)
        {
            return ValidationProblem(new ValidationProblemDetails(
                new Dictionary<string, string[]>
                {
                    ["request"] = [exception.Message]
                }));
        }
        catch (OdooGatewayException exception)
        {
            var status = exception.UpstreamStatusCode.HasValue
                ? StatusCodes.Status502BadGateway
                : StatusCodes.Status503ServiceUnavailable;
            var problem = new ProblemDetails
            {
                Status = status,
                Title = "Odoo method call failed",
                Detail = exception.Message
            };
            if (exception.UpstreamStatusCode.HasValue)
            {
                problem.Extensions["odooStatusCode"] = exception.UpstreamStatusCode.Value;
            }

            if (!string.IsNullOrWhiteSpace(exception.UpstreamErrorType))
            {
                problem.Extensions["odooErrorType"] = exception.UpstreamErrorType;
            }

            return StatusCode(status, problem);
        }
    }
}

public sealed record OdooMethodCallRequest(
    string Model,
    string Method,
    int UserId,
    IReadOnlyList<int>? RecordIds,
    JsonElement? Vals,
    JsonElement? Args,
    JsonElement? Kwargs,
    JsonElement? Context);
