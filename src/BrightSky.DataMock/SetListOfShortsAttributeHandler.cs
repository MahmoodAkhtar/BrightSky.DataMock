using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfShortsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfShortsAttribute));
        return attribute is not null ? ((SetListOfShortsAttribute)attribute).GetMockType() : null;
    }
}