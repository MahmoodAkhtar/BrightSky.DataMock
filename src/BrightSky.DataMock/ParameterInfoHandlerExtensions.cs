namespace BrightSky.DataMock;

public static class ParameterInfoHandlerExtensions
{
    public static ParameterInfoHandlerChain Then(this IParameterInfoHandler first, IParameterInfoHandler next) 
        => new(first, next);
}