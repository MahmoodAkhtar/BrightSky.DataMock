using System.Reflection;

namespace BrightSky.DataMock;

public class SetBoolsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetBoolsAttribute));
        return attribute is not null ? ((SetBoolsAttribute)attribute).GetMockType() : null;
    }
}