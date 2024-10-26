using System.Reflection;

namespace BrightSky.DataMock;

public class ListOfGuidParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(List<Guid>) ? Dm.ListsOf<Guid>() : null;
}