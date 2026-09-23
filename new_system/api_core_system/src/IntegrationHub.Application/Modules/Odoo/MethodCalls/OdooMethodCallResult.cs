using System.Text.Json;

namespace IntegrationHub.Application.Modules.Odoo.MethodCalls;

public sealed record OdooMethodCallResult(
    bool Success,
    string Model,
    string Method,
    int UserId,
    JsonElement Result);
