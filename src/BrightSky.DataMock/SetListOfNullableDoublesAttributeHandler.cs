using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfNullableDoublesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfNullableDoublesAttribute));
        return attribute is not null ? ((SetListOfNullableDoublesAttribute)attribute).GetMockType() : null;
    }
}