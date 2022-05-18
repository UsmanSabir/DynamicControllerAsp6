using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace DynamicControllerPOC.Controllers;

public class GenericControllerApplicationPart : ApplicationPart, IApplicationPartTypeProvider
{
    public GenericControllerApplicationPart(IEnumerable<TypeInfo> typeInfos)
    {
        Types = typeInfos;
    }

    public override string Name => "GenericController";
    public IEnumerable<TypeInfo> Types { get; }
}