using System.Reflection;

namespace BrightSky.DataMock;

public class ParameterInfoHandlerChain : IParameterInfoHandler
{
    private readonly IParameterInfoHandler _current;
    private readonly IParameterInfoHandler _next;

    public ParameterInfoHandlerChain(IParameterInfoHandler current, IParameterInfoHandler next)
        => (_current, _next) = (current, next);

    public object? Handle(ParameterInfo parameterInfo)
    {
        var obj = _current.Handle(parameterInfo);
        return obj ?? _next.Handle(parameterInfo);
    }
}