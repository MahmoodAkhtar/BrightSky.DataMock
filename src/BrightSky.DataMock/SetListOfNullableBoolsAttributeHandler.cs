using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfNullableBoolsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfNullableBoolsAttribute));
        return attribute is not null ? ((SetListOfNullableBoolsAttribute)attribute).GetMockType() : null;
    }
}