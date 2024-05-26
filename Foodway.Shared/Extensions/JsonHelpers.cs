using System.Text.Json;

namespace Foodway.Shared.Extensions;

public static class JsonHelpers
{
    public static string ToJson<T>(this T obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}