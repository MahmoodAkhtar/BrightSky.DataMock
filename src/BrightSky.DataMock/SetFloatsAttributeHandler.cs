using System.Reflection;

namespace BrightSky.DataMock;

public class SetFloatsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetFloatsAttribute));
        return attribute is not null ? ((SetFloatsAttribute)attribute).GetMockType() : null;
    }
}