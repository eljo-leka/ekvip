using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ekvip.Enums.Helpers;

public static class EnumHelper
{
    public static string[] GetEnumDisplayNames<T>() where T : struct, Enum
    {
        return Enum.GetValues<T>()
            .Where(cmdType => cmdType is not CommandTypeEnum.Unknown)
            .Select(GetDisplayName)
            .ToArray();
    }
    
    private static string GetDisplayName<T>(T enumValue) where T : Enum
    {
        return enumValue.GetType()?
            .GetMember(enumValue.ToString())?
            .FirstOrDefault()?
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName() ?? enumValue.ToString();
    }

    public static CommandTypeEnum TryParseStrict(string value)
    {
        var commandType = CommandTypeEnum.Unknown;
        
        if(!int.TryParse(value, out _)) 
            Enum.TryParse(value, true, out commandType);

        return commandType;
    }
}