using System.Reflection;
using Xunit.Sdk;

namespace BrightSky.DataMock.Tests;

public class AutoDataMockAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        ArgumentNullException.ThrowIfNull(testMethod);

        var mts = ResolveMockTypesAsObjects(testMethod);
        var values = GenerateValues(mts);
        var data = RearrangeValuesToData(mts, values);

        return data;
    }

    private static List<object> ResolveMockTypesAsObjects(MethodInfo testMethod)
    {
        var mts = new List<object>();

        foreach (var pi in testMethod.GetParameters())
        {
            var mt = Resolve(pi.ParameterType);
            if (mt is null)
                throw new Xunit.Sdk.XunitException($"Parameter type {pi.ParameterType.Name} is not supported");
            mts.Add(mt);
        }

        return mts;
    }

    private static object[][] GenerateValues(List<object> mts)
        => (from dynamic mt in mts select MockTypeExtensions.ToList(mt, 100))
            .Select(x => WhenListOf(x.GetType(), x))
            .Cast<object[]>()
            .ToArray();

    private static object[][] RearrangeValuesToData(List<object> mts, object[][] values)
    {
        var data = new object[100][];
        for (var i = 0; i < 100; i++)
        {
            var row = new object[mts.Count];
            for (var j = 0; j < mts.Count; j++)
                row[j] = values[j][i];
            data[i] = row;
        }

        return data;
    }

    private static object[] WhenListOf<T>(Type type, List<T> value)
    {
        var dict = new Dictionary<Func<bool>, Func<List<T>>>
        {
            { () => type == typeof(List<bool>),     () => value },
            { () => type == typeof(List<byte>),     () => value },
            { () => type == typeof(List<short>),    () => value },
            { () => type == typeof(List<int>),      () => value },
            { () => type == typeof(List<long>),     () => value },
            { () => type == typeof(List<float>),    () => value },
            { () => type == typeof(List<double>),   () => value },
            { () => type == typeof(List<decimal>),  () => value },
            { () => type == typeof(List<char>),     () => value },
            { () => type == typeof(List<string>),   () => value },
            { () => type == typeof(List<Guid>),     () => value },
            { () => type == typeof(List<DateTime>), () => value },
            
            { () => IsUnderlyingTypeNullable(type, typeof(List<bool>)),     () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<byte>)),     () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<short>)),    () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<int>)),      () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<long>)),     () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<float>)),    () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<double>)),   () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<decimal>)),  () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<char>)),     () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<string>)),   () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<Guid>)),     () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<DateTime>)), () => value },
            
            { () => type == typeof(List<List<bool>>),     () => value },
            { () => type == typeof(List<List<byte>>),     () => value },
            { () => type == typeof(List<List<short>>),    () => value },
            { () => type == typeof(List<List<int>>),      () => value },
            { () => type == typeof(List<List<long>>),     () => value },
            { () => type == typeof(List<List<float>>),    () => value },
            { () => type == typeof(List<List<double>>),   () => value },
            { () => type == typeof(List<List<decimal>>),  () => value },
            { () => type == typeof(List<List<char>>),   () => value },
            { () => type == typeof(List<List<string>>),   () => value },
            { () => type == typeof(List<List<Guid>>),     () => value },
            { () => type == typeof(List<List<DateTime>>), () => value },
            
            { () => type == typeof(List<List<bool?>>),     () => value },
            { () => type == typeof(List<List<byte?>>),     () => value },
            { () => type == typeof(List<List<short?>>),    () => value },
            { () => type == typeof(List<List<int?>>),      () => value },
            { () => type == typeof(List<List<long?>>),     () => value },
            { () => type == typeof(List<List<float?>>),    () => value },
            { () => type == typeof(List<List<double?>>),   () => value },
            { () => type == typeof(List<List<decimal?>>),  () => value },
            { () => type == typeof(List<List<char?>>),   () => value },
            { () => type == typeof(List<List<string?>>),   () => value },
            { () => type == typeof(List<List<Guid?>>),     () => value },
            { () => type == typeof(List<List<DateTime?>>), () => value },
        };

        var matched = dict
            .Where(kvp => kvp.Key())
            .Select(kvp => kvp.Value())
            .FirstOrDefault();
        
        return matched is null ? [] : matched.Cast<object>().ToArray();
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
            { () => IsUnderlyingTypeNullable(type, typeof(DateTime)), Dm.NullableDateTimes },
            
            { () => type == typeof(List<bool>),     Dm.ListsOf<bool> },
            { () => type == typeof(List<byte>),     Dm.ListsOf<byte> },
            { () => type == typeof(List<short>),    Dm.ListsOf<short> },
            { () => type == typeof(List<int>),      Dm.ListsOf<int> },
            { () => type == typeof(List<long>),     Dm.ListsOf<long> },
            { () => type == typeof(List<float>),    Dm.ListsOf<float> },
            { () => type == typeof(List<double>),   Dm.ListsOf<double> },
            { () => type == typeof(List<decimal>),  Dm.ListsOf<decimal> },
            { () => type == typeof(List<char>),     Dm.ListsOf<char> },
            { () => type == typeof(List<string>),   Dm.ListsOf<string> },
            { () => type == typeof(List<Guid>),     Dm.ListsOf<Guid> },
            { () => type == typeof(List<DateTime>), Dm.ListsOf<DateTime> },
            
            { () => type == typeof(List<bool?>),     Dm.ListsOf<bool?> },
            { () => type == typeof(List<byte?>),     Dm.ListsOf<byte?> },
            { () => type == typeof(List<short?>),    Dm.ListsOf<short?> },
            { () => type == typeof(List<int?>),      Dm.ListsOf<int?> },
            { () => type == typeof(List<long?>),     Dm.ListsOf<long?> },
            { () => type == typeof(List<float?>),    Dm.ListsOf<float?> },
            { () => type == typeof(List<double?>),   Dm.ListsOf<double?> },
            { () => type == typeof(List<decimal?>),  Dm.ListsOf<decimal?> },
            { () => type == typeof(List<char?>),     Dm.ListsOf<char?> },
            { () => type == typeof(List<string?>),   Dm.ListsOf<string?> },
            { () => type == typeof(List<Guid?>),     Dm.ListsOf<Guid?> },
            { () => type == typeof(List<DateTime?>), Dm.ListsOf<DateTime?> },
        };

        return dict
            .Where(kvp => kvp.Key())
            .Select(kvp => kvp.Value())
            .FirstOrDefault();
    }

    private static bool IsUnderlyingTypeNullable(Type type, Type underlyingType)
        => type.IsGenericType
           && type.GetGenericTypeDefinition() == typeof(Nullable<>)
           && Nullable.GetUnderlyingType(type) == underlyingType;
}