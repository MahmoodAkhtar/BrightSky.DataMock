using System.Reflection;

namespace BrightSky.DataMock;

public class SetNullableShortsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableShortsAttribute));
        return attribute is not null ? ((SetNullableShortsAttribute)attribute).GetMockType() : null;
    }
}