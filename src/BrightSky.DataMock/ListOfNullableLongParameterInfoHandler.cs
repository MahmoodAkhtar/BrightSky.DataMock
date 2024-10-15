using System.Reflection;

namespace BrightSky.DataMock;

public class ListOfNullableLongParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(List<long?>) ? Dm.ListsOf<long?>() : null;
}