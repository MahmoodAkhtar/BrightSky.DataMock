using System.Reflection;

namespace BrightSky.DataMock;

public class GuidParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(Guid) ? Dm.Guids() : null;
}