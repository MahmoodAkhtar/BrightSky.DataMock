using System.Reflection;

namespace BrightSky.DataMock;

public class SetNullableDoublesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableDoublesAttribute));
        return attribute is not null ? ((SetNullableDoublesAttribute)attribute).GetMockType() : null;
    }
}