using System.Reflection;

namespace BrightSky.DataMock;

public class SetShortsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetShortsAttribute));
        return attribute is not null ? ((SetShortsAttribute)attribute).GetMockType() : null;
    }
}