using System.Reflection;

namespace BrightSky.DataMock;

public class SetBytesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetBytesAttribute));
        return attribute is not null ? ((SetBytesAttribute)attribute).GetMockType() : null;
    }
}