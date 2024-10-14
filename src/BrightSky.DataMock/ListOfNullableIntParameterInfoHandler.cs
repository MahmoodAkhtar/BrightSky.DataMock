using System.Reflection;

namespace BrightSky.DataMock;

public class ListOfNullableIntParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(List<int?>) ? Dm.ListsOf<int?>() : null;
}