using System.Reflection;

namespace BrightSky.DataMock;

public class CharParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(char) ? Dm.Chars() : null;
}