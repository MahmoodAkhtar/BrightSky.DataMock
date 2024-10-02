using System.Reflection;

namespace BrightSky.DataMock;

public class SetGuidsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetGuidsAttribute));
        return attribute is not null ? ((SetGuidsAttribute)attribute).GetMockType() : null;
    }
}