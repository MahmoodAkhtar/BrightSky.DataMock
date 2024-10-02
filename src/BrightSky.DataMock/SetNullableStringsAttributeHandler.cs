using System.Reflection;

namespace BrightSky.DataMock;

public class SetNullableStringsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableStringsAttribute));
        return attribute is not null ? ((SetNullableStringsAttribute)attribute).GetMockType() : null;
    }
}