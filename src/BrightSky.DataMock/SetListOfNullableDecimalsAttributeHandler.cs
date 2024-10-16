using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfNullableDecimalsAttributeHandler: IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfNullableDecimalsAttribute));
        return attribute is not null ? ((SetListOfNullableDecimalsAttribute)attribute).GetMockType() : null;
    }
}