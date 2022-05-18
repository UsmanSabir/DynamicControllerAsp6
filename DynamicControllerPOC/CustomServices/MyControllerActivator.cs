using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace DynamicControllerPOC.CustomServices;

public class MyControllerActivator : IControllerActivator
{
    private readonly ILogger _logger;

    public MyControllerActivator(ILogger<MyControllerActivator> logger)
    {
        _logger = logger;
    }

    public object Create(ControllerContext context)
    {
        var serviceProvider = context.HttpContext.RequestServices;
        Type type = context.ActionDescriptor.ControllerTypeInfo.AsType();
        //var inst =  Activator.CreateInstance(type);
        var inst2= serviceProvider.GetRequiredService(type); //
        return inst2;
    }

    public void Release(ControllerContext context, object controller)
    {
        if (controller is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}