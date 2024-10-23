using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfNullableStringsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfNullableStringsAttribute));
        return attribute is not null ? ((SetListOfNullableStringsAttribute)attribute).GetMockType() : null;
    }
}