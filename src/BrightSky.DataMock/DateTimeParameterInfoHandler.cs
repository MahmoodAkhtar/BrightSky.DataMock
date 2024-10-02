using System.Reflection;

namespace BrightSky.DataMock;

public class DateTimeParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(DateTime) ? Dm.DateTimes() : null;
}