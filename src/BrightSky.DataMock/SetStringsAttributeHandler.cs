using System.Reflection;

namespace BrightSky.DataMock;

public class SetStringsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetStringsAttribute));
        return attribute is not null ? ((SetStringsAttribute)attribute).GetMockType() : null;
    }
}