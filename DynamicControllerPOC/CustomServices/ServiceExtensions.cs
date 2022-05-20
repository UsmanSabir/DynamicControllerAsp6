using System.Web.Http.Description;
using DynamicControllerPOC.Core;
using Microsoft.AspNetCore.Mvc.Abstractions;

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
        services.AddSingleton<IApiExplorer, BizApiExplorer>();
        //services.AddSingleton<IActionDescriptorProvider, DynamicActionProvider>();

        return services.AddControllers(opt =>
            {
                opt.Conventions.Add(new ApplicationModelConvention());
            })
    .ConfigureApplicationPartManager(
                manager =>
                {
                    //manager.FeatureProviders.Add(new MyControllerFeatureProvider());
                    //manager.ApplicationParts.Add(new GenericControllerApplicationPart(closedControllerTypes));
                    
                    manager.FeatureProviders.Add(new BusinessControllerFeatureProvider());
                });
    }

}