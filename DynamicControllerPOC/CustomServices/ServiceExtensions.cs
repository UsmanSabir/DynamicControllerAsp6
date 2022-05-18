using DynamicControllerPOC.Core;

namespace DynamicControllerPOC.CustomServices;

public static class ServiceExtensions
{
    public static IMvcBuilder RegisterBusinessServices(this IServiceCollection services)
    {
        var businessServices = BusinessServiceDiscovery.GetBusinessServices();
        foreach (var businessService in businessServices)
        {
            services.AddScoped(businessService);
        }
        return services.AddControllers()
            .ConfigureApplicationPartManager(
                manager =>
                {
                    //manager.FeatureProviders.Add(new MyControllerFeatureProvider());
                    //manager.ApplicationParts.Add(new GenericControllerApplicationPart(closedControllerTypes));

                    manager.FeatureProviders.Add(new BusinessControllerFeatureProvider());
                });
    }

}