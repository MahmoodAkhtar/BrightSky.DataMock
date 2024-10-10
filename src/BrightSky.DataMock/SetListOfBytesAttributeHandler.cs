using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfBytesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfBytesAttribute));
        return attribute is not null ? ((SetListOfBytesAttribute)attribute).GetMockType() : null;
    }
}