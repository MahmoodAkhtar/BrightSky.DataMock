using System.Reflection;

namespace BrightSky.DataMock;

public class SetDateTimesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetDateTimesAttribute));
        return attribute is not null ? ((SetDateTimesAttribute)attribute).GetMockType() : null;
    }
}