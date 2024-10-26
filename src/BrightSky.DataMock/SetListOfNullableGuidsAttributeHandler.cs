using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfNullableGuidsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfNullableGuidsAttribute));
        return attribute is not null ? ((SetListOfNullableGuidsAttribute)attribute).GetMockType() : null;
    }
}