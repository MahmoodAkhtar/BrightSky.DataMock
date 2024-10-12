using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfNullableShortsAttributeHandler: IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfNullableShortsAttribute));
        return attribute is not null ? ((SetListOfNullableShortsAttribute)attribute).GetMockType() : null;
    }
}