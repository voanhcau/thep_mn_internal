using IntegrationHub.Application.Modules.MasterData.BilletBarems;
using IntegrationHub.Application.Modules.MasterData.Sync;
using IntegrationHub.Application.Modules.MasterData.BarWeight;
using IntegrationHub.Application.Modules.Odoo.MethodCalls;
using IntegrationHub.Application.Modules.Orders;
using IntegrationHub.Application.Modules.Finance.AggregateCreditLimits;
using IntegrationHub.Application.Modules.Finance.CreditLimitDetails;
using IntegrationHub.Application.Modules.Finance.CreditLimits;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationHub.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<BilletBaremService>();
        services.AddScoped<CreditLimitService>();
        services.AddScoped<AggregateCreditLimitService>();
        services.AddScoped<CreditLimitDetailService>();
        services.AddScoped<MasterDataSyncService>();
        services.AddScoped<BarWeightService>();
        services.AddScoped<OdooMethodCallService>();
        services.AddScoped<CustomerOrderSyncService>();
        return services;
    }
}
