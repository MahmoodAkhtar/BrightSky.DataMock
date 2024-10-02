using System.Reflection;

namespace BrightSky.DataMock;

public class SetNullableLongsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableLongsAttribute));
        return attribute is not null ? ((SetNullableLongsAttribute)attribute).GetMockType() : null;
    }
}