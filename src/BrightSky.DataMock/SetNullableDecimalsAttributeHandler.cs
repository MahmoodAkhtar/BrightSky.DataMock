using System.Reflection;

namespace BrightSky.DataMock;

public class SetNullableDecimalsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableDecimalsAttribute));
        return attribute is not null ? ((SetNullableDecimalsAttribute)attribute).GetMockType() : null;
    }
}