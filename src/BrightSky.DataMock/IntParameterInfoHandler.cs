using System.Reflection;

namespace BrightSky.DataMock;

public class IntParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(int) ? Dm.Ints() : null;
}