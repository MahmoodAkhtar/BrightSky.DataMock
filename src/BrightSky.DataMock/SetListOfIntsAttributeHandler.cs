using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfIntsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfIntsAttribute));
        return attribute is not null ? ((SetListOfIntsAttribute)attribute).GetMockType() : null;
    }
}