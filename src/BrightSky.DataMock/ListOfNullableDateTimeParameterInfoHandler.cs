using System.Reflection;

namespace BrightSky.DataMock;

public class ListOfNullableDateTimeParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(List<DateTime?>) ? Dm.ListsOf<DateTime?>() : null;
}