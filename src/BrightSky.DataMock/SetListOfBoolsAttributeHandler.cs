using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfBoolsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfBoolsAttribute));
        return attribute is not null ? ((SetListOfBoolsAttribute)attribute).GetMockType() : null;
    }
}