using System.Reflection;

namespace BrightSky.DataMock;

public class SetCharsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetCharsAttribute));
        return attribute is not null ? ((SetCharsAttribute)attribute).GetMockType() : null;
    }
}