using System.Reflection;

namespace BrightSky.DataMock;

public class SetNullableBytesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableBytesAttribute));
        return attribute is not null ? ((SetNullableBytesAttribute)attribute).GetMockType() : null;
    }
}