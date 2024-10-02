using System.Reflection;

namespace BrightSky.DataMock;

public class LongParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(long) ? Dm.Longs() : null;
}