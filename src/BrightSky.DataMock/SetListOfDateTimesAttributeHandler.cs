using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfDateTimesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfDateTimesAttribute));
        return attribute is not null ? ((SetListOfDateTimesAttribute)attribute).GetMockType() : null;
    }
}