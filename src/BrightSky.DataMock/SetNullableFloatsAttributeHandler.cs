using System.Reflection;

namespace BrightSky.DataMock;

public class SetNullableFloatsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableFloatsAttribute));
        return attribute is not null ? ((SetNullableFloatsAttribute)attribute).GetMockType() : null;
    }
}