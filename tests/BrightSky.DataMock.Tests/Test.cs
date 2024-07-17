namespace BrightSky.DataMock.Tests;

public static class Test
{
    public static bool IsNullable<T>(T value)
    {
        if (value == null) return true; // obvious
        Type type = typeof(T);
        if (!type.IsValueType) return true; // ref-type
        if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
        return false; // value-type
    }
}