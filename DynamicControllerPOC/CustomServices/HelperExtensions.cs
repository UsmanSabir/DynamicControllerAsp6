namespace DynamicControllerPOC.CustomServices;

public static class HelperExtensions
{
    public static IEnumerable<Type> GetInheritanceHierarchy
        (this Type type)
    {
        for (var current = type; current != null; current = current.BaseType)
            yield return current;
    }
}