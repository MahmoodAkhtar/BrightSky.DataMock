using System.Reflection;

namespace BrightSky.DataMock;

public class FloatParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(float) ? Dm.Floats() : null;
}