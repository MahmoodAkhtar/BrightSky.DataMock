using System.Reflection;

namespace BrightSky.DataMock;

public class SetNullableBoolsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableBoolsAttribute));
        return attribute is not null ? ((SetNullableBoolsAttribute)attribute).GetMockType() : null;
    }
}