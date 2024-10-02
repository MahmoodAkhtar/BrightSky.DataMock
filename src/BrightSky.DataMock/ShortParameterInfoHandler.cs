using System.Reflection;

namespace BrightSky.DataMock;

public class ShortParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(short) ? Dm.Shorts() : null;
}