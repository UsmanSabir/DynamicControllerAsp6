using System.Reflection;

namespace DynamicControllerPOC.CustomServices;

public static class HelperExtensions
{
    public static IEnumerable<Type> GetInheritanceHierarchy
        (this Type type)
    {
        for (var current = type; current != null; current = current.BaseType)
            yield return current;
    }

    public static List<MethodInfo> GetMethodsOfType(Type type)
    {
        var allMethods = new List<MethodInfo>();

        FillMethodsRecursively(type, BindingFlags.Public | BindingFlags.Instance, allMethods);

        return allMethods.Where(
            method => method.DeclaringType != typeof(object) &&
                      //method.DeclaringType != typeof(BaseService) &&
                      !IsPropertyAccessor(method)
        ).ToList();
    }

    public static bool IsMethodOfType(MethodInfo methodInfo, Type type)
    {
        if (type.IsAssignableFrom(methodInfo.DeclaringType))
        {
            return true;
        }

        if (!type.IsInterface)
        {
            return false;
        }

        return type.GetInterfaces().Any(interfaceType => IsMethodOfType(methodInfo, interfaceType));
    }

    private static void FillMethodsRecursively(Type type, BindingFlags flags, List<MethodInfo> members)
    {
        members.AddRange(type.GetMethods(flags));

        foreach (var interfaceType in type.GetInterfaces())
        {
            FillMethodsRecursively(interfaceType, flags, members);
        }
    }

    private static bool IsPropertyAccessor(MethodInfo method)
    {
        return method.IsSpecialName && (method.Attributes & MethodAttributes.HideBySig) != 0;
    }
}