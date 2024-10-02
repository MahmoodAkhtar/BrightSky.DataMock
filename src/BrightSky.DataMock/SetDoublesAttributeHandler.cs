using System.Reflection;

namespace BrightSky.DataMock;

public class SetDoublesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetDoublesAttribute));
        return attribute is not null ? ((SetDoublesAttribute)attribute).GetMockType() : null;
    }
}