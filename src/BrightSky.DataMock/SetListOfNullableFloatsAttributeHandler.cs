using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfNullableFloatsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfNullableFloatsAttribute));
        return attribute is not null ? ((SetListOfNullableFloatsAttribute)attribute).GetMockType() : null;
    }
}