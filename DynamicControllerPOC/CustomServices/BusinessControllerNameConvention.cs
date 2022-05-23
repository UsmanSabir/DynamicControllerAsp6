using System.Diagnostics;
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
        var baseType = typeof(IBusinessService);
        var derivedType = entityType;
        
        var contract = entityType.GetInterfaces().FirstOrDefault();
        if (contract != null) derivedType = contract;

        controller.ControllerName = $"{derivedType.Name.TrimStart('I')}Host";
    }
}