using System.Text.Json;

namespace IntegrationHub.Application.Modules.Odoo.MethodCalls;

public sealed record OdooMethodCall(
    string Model,
    string Method,
    int UserId,
    IReadOnlyList<int>? RecordIds,
    JsonElement? Vals,
    JsonElement? Args,
    JsonElement? Kwargs,
    JsonElement? Context);
