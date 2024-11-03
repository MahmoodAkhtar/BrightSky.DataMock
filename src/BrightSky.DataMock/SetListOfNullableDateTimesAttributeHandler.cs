using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfNullableDateTimesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfNullableDateTimesAttribute));
        return attribute is not null ? ((SetListOfNullableDateTimesAttribute)attribute).GetMockType() : null;
    }
}