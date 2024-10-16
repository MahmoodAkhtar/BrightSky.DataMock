using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfDoublesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfDoublesAttribute));
        return attribute is not null ? ((SetListOfDoublesAttribute)attribute).GetMockType() : null;
    }
}