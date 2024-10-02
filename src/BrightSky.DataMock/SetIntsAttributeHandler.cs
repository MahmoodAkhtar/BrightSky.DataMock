using System.Reflection;

namespace BrightSky.DataMock;

public class SetIntsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetIntsAttribute));
        return attribute is not null ? ((SetIntsAttribute)attribute).GetMockType() : null;
    }
}