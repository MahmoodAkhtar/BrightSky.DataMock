using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfLongsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfLongsAttribute));
        return attribute is not null ? ((SetListOfLongsAttribute)attribute).GetMockType() : null;
    }
}