namespace IntegrationHub.Application.Modules.Odoo.MethodCalls;

public sealed class OdooGatewayException(
    string message,
    int? upstreamStatusCode = null,
    string? upstreamErrorType = null,
    Exception? innerException = null)
    : Exception(message, innerException)
{
    public int? UpstreamStatusCode { get; } = upstreamStatusCode;
    public string? UpstreamErrorType { get; } = upstreamErrorType;
}
