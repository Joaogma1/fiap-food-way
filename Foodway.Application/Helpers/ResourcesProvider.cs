namespace Foodway.Application.Helpers;

public static class ResourcesProvider
{
    public static string GetResourcePath(string controllerName, Guid id, string addionalPath = "/")
    {
        return $"{controllerName}{addionalPath}{id}";
    }
}