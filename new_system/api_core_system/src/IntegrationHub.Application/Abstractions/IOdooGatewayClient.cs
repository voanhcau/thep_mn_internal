using System.Text.Json;
using IntegrationHub.Application.Modules.Odoo.MethodCalls;

namespace IntegrationHub.Application.Abstractions;

public interface IOdooGatewayClient
{
    Task<JsonElement> CallAsync(
        OdooMethodCall command,
        CancellationToken cancellationToken);
}
