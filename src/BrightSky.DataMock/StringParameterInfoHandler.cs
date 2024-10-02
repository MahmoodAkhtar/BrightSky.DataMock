using System.Reflection;

namespace BrightSky.DataMock;

public class StringParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(string) ? Dm.Strings() : null;
}