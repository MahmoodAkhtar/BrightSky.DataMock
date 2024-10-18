using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfCharsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfCharsAttribute));
        return attribute is not null ? ((SetListOfCharsAttribute)attribute).GetMockType() : null;
    }
}