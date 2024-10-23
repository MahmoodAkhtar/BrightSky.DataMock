using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfStringsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfStringsAttribute));
        return attribute is not null ? ((SetListOfStringsAttribute)attribute).GetMockType() : null;
    }
}