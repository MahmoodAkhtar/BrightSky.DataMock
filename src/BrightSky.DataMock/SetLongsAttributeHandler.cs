using System.Reflection;

namespace BrightSky.DataMock;

public class SetLongsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetLongsAttribute));
        return attribute is not null ? ((SetLongsAttribute)attribute).GetMockType() : null;
    }
}