using System.Reflection;

namespace BrightSky.DataMock;

public class ListOfNullableShortParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(List<short?>) ? Dm.ListsOf<short?>() : null;
}