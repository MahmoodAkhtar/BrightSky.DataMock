using System.Reflection;

namespace BrightSky.DataMock;

public class SetDecimalsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetDecimalsAttribute));
        return attribute is not null ? ((SetDecimalsAttribute)attribute).GetMockType() : null;
    }
}