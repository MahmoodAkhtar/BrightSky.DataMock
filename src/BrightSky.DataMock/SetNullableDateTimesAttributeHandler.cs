using System.Reflection;

namespace BrightSky.DataMock;

public class SetNullableDateTimesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableDateTimesAttribute));
        return attribute is not null ? ((SetNullableDateTimesAttribute)attribute).GetMockType() : null;
    }
}