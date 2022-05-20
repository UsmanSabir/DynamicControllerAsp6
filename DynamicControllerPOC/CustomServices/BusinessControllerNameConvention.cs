using DynamicControllerPOC.Core;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DynamicControllerPOC.CustomServices;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class BusinessControllerNameConvention : Attribute, IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        if (controller.ControllerType.GetGenericTypeDefinition() !=
            typeof(BusinessServiceHostController<>))
        {
            return;
        }

        var entityType = controller.ControllerType.GenericTypeArguments[0];
        controller.ControllerName = $"{entityType.Name}Host";

        controller.ApiExplorer.IsVisible = true;
    }
}