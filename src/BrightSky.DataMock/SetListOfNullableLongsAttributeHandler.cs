using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfNullableLongsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfNullableLongsAttribute));
        return attribute is not null ? ((SetListOfNullableLongsAttribute)attribute).GetMockType() : null;
    }
}