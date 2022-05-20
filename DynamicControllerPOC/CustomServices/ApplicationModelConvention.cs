using System.Reflection;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DynamicControllerPOC.CustomServices;

public class ApplicationModelConvention: IApplicationModelConvention
{
    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers)
        {
            //var actionModel = controller.Actions.First();

            //var model = new ActionModel(actionModel);
            //model.ActionName = $"Modified{model.ActionName}";
            
            //controller.Actions.Add(model);

            //controller.Selectors.Add(new SelectorModel()
            //{
            //    AttributeRouteModel = new AttributeRouteModel()
            //    {
            //        Template = "WeatherForecast" //controller.ControllerType.Namespace.Replace('.', '/') + "/[controller]/[action]/{id?}"
            //    }
            //});
        }
    }
}

