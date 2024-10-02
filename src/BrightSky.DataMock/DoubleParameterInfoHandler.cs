using System.Reflection;

namespace BrightSky.DataMock;

public class DoubleParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(double) ? Dm.Doubles() : null;
}