using System.Reflection;

namespace BrightSky.DataMock;

public class ListOfDecimalParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(List<decimal>) ? Dm.ListsOf<decimal>() : null;
}