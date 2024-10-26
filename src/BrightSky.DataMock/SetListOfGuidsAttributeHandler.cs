using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfGuidsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfGuidsAttribute));
        return attribute is not null ? ((SetListOfGuidsAttribute)attribute).GetMockType() : null;
    }
}