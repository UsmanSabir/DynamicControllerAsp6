using System.Reflection;
using DynamicControllerPOC.Services;

namespace DynamicControllerPOC.Core;

public class BusinessServiceDiscovery
{
    public static List<TypeInfo> GetBusinessServices()
    {
        var types = new List<TypeInfo>();

        //todo scan assemblies
        types.Add(typeof(BizService).GetTypeInfo());

        return types;
    }
}