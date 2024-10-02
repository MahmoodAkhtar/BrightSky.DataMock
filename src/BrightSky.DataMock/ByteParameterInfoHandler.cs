using System.Reflection;

namespace BrightSky.DataMock;

public class ByteParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(byte) ? Dm.Bytes() : null;
}