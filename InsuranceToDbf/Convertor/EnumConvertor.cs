using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace InsuranceToDbf.Convertor;
internal static class EnumConvertor
{
    public static string? GetDisplayName(this Enum enumObject)
    {
        try
        {
            var result = enumObject.GetType()
                             .GetMember(enumObject.ToString())
                             .First()
                             ?.GetCustomAttribute<DisplayAttribute>()?.Name;
            return result;
        }
        catch
        {
            return string.Empty;
        }
    }
}

