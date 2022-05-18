using DynamicControllerPOC.Core;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DynamicControllerPOC.CustomServices;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class GenericControllerNameConvention : Attribute, IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        if (controller.ControllerType.GetGenericTypeDefinition() !=
            typeof(BaseApiController<>))
        {
            // Not a GenericController, ignore.
            return;
        }

        var entityType = controller.ControllerType.GenericTypeArguments[0];
        controller.ControllerName = $"{entityType.Name}Controller";
    }
}