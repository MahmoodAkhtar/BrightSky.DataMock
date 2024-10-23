using System.Reflection;

namespace BrightSky.DataMock;

public class ListOfStringParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(List<string>) ? Dm.ListsOf<string>() : null;
}