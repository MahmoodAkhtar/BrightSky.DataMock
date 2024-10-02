using System.Reflection;

namespace BrightSky.DataMock;

public class BoolParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(bool) ? Dm.Bools() : null;
}