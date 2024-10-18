using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfNullableCharsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfNullableCharsAttribute));
        return attribute is not null ? ((SetListOfNullableCharsAttribute)attribute).GetMockType() : null;
    }
}