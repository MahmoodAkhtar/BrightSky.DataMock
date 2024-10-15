using System.Reflection;

namespace BrightSky.DataMock;

public class ListOfNullableFloatParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(List<float?>) ? Dm.ListsOf<float?>() : null;
}