using System.Reflection;

namespace BrightSky.DataMock;

public interface IParameterInfoHandler
{
    object? Handle(ParameterInfo parameterInfo);
}