using System.ComponentModel;

namespace Foodway.Shared.Extensions;

public static class EnumExtensions
{
    /// <summary>
    ///     Retrieves the description attribute value of an enum value.
    /// </summary>
    /// <param name="value">The enum value.</param>
    /// <returns>The description attribute value if it exists; otherwise, null. </returns>
    public static string? Description(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());

        if (field is not null)
            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr
                ? attr.Description
                : null;

        return null;
    }
}