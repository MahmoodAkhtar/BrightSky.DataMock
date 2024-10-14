using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfNullableIntsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfNullableIntsAttribute));
        return attribute is not null ? ((SetListOfNullableIntsAttribute)attribute).GetMockType() : null;
    }
}