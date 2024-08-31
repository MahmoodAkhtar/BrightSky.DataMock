namespace BrightSky.DataMock;

public class MockTypeListOf<T> : IMockType<List<List<T>>>
{
    public List<List<T>> Get()
    {
        var mt = Resolve(typeof(T));
        if (mt is null)
            throw new InvalidCastException($"Parameter type {typeof(T).Name} is not supported");
        var list = Enumerable.Range(0, 100).Select(_ => (List<T>)MockTypeExtensions.ToList((dynamic)mt, 100)).ToList();
        return list;
    }
 
    private static object? Resolve(Type type)
    {
        var dict = new Dictionary<Func<bool>, Func<object>>
        {
            { () => type == typeof(bool),     Dm.Bools },
            { () => type == typeof(byte),     Dm.Bytes },
            { () => type == typeof(short),    Dm.Shorts },
            { () => type == typeof(int),      Dm.Ints },
            { () => type == typeof(long),     Dm.Longs },
            { () => type == typeof(float),    Dm.Floats },
            { () => type == typeof(double),   Dm.Doubles },
            { () => type == typeof(decimal),  Dm.Decimals },
            { () => type == typeof(char),     Dm.Chars },
            { () => type == typeof(string),   Dm.Strings },
            { () => type == typeof(Guid),     Dm.Guids },
            { () => type == typeof(DateTime), Dm.DateTimes },
            { () => IsUnderlyingTypeNullable(type, typeof(bool)),     Dm.NullableBools },
            { () => IsUnderlyingTypeNullable(type, typeof(byte)),     Dm.NullableBytes },
            { () => IsUnderlyingTypeNullable(type, typeof(short)),    Dm.NullableShorts },
            { () => IsUnderlyingTypeNullable(type, typeof(int)),      Dm.NullableInts },
            { () => IsUnderlyingTypeNullable(type, typeof(long)),     Dm.NullableLongs },
            { () => IsUnderlyingTypeNullable(type, typeof(float)),    Dm.NullableFloats },
            { () => IsUnderlyingTypeNullable(type, typeof(double)),   Dm.NullableDoubles },
            { () => IsUnderlyingTypeNullable(type, typeof(decimal)),  Dm.NullableDecimals },
            { () => IsUnderlyingTypeNullable(type, typeof(char)),     Dm.NullableChars },
            { () => IsUnderlyingTypeNullable(type, typeof(string)),   Dm.NullableStrings },
            { () => IsUnderlyingTypeNullable(type, typeof(Guid)),     Dm.NullableGuids },
            { () => IsUnderlyingTypeNullable(type, typeof(DateTime)), Dm.NullableDateTimes }
        };

        return dict
            .Where(kvp => kvp.Key())
            .Select(kvp => kvp.Value())
            .FirstOrDefault();
    }

    private static bool IsUnderlyingTypeNullable(Type type, Type underlyingType)
        => type.IsGenericType 
           && type.GetGenericTypeDefinition() == typeof(Nullable<>) 
           && Nullable.GetUnderlyingType(underlyingType) == underlyingType;
}