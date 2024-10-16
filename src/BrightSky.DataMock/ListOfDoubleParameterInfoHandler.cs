using System.Reflection;

namespace BrightSky.DataMock;

public class ListOfDoubleParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(List<double>) ? Dm.ListsOf<double>() : null;
}