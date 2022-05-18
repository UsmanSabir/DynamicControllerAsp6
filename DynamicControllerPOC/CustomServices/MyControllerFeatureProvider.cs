using System.Reflection;
using DynamicControllerPOC.Core;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace DynamicControllerPOC.CustomServices;

public class MyControllerFeatureProvider : ControllerFeatureProvider
{
    protected override bool IsController(TypeInfo typeInfo)
    {
        var isController = base.IsController(typeInfo);

        if (!isController)
        {
            var bizService = typeInfo.IsSubclassOf(typeof(IBusinessService));
            if (bizService) return bizService;

            string[] validEndings = new[] { "Foobar", "Controller`1" };

            isController = validEndings.Any(x =>
                typeInfo.Name.EndsWith(x, StringComparison.OrdinalIgnoreCase));
        }

        Console.WriteLine($"{typeInfo.Name} IsController: {isController}.");

        return isController;
    }
}