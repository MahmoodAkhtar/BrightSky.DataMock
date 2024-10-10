using System.Reflection;

namespace BrightSky.DataMock;

public class SetListOfNullableBytesAttributeHandler: IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetListOfNullableBytesAttribute));
        return attribute is not null ? ((SetListOfNullableBytesAttribute)attribute).GetMockType() : null;
    }
}