using System.Reflection;

namespace BrightSky.DataMock;

public class DecimalParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(decimal) ? Dm.Decimals() : null;
}