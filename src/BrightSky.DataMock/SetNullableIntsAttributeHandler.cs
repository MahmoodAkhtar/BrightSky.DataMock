using System.Reflection;

namespace BrightSky.DataMock;

public class SetNullableIntsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableIntsAttribute));
        return attribute is not null ? ((SetNullableIntsAttribute)attribute).GetMockType() : null;
    }
}