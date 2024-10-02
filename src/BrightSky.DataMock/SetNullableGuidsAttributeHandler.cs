using System.Reflection;

namespace BrightSky.DataMock;

public class SetNullableGuidsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableGuidsAttribute));
        return attribute is not null ? ((SetNullableGuidsAttribute)attribute).GetMockType() : null;
    }
}