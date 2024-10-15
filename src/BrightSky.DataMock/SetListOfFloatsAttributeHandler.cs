using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfFloatsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfFloatsAttribute));
        return attribute is not null ? ((SetListOfFloatsAttribute)attribute).GetMockType() : null;
    }
}