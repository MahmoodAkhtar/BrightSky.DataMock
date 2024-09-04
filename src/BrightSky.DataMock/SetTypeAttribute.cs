using System.Reflection;

namespace BrightSky.DataMock;

public abstract class SetTypeAttribute<T> : Attribute
{
    public abstract IMockType<T> GetMockType();
}