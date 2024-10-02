using System.Reflection;

namespace BrightSky.DataMock;

public class SetNullableCharsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableCharsAttribute));
        return attribute is not null ? ((SetNullableCharsAttribute)attribute).GetMockType() : null;
    }
}