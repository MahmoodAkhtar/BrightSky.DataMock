using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfDecimalsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfDecimalsAttribute));
        return attribute is not null ? ((SetListOfDecimalsAttribute)attribute).GetMockType() : null;
    }
}