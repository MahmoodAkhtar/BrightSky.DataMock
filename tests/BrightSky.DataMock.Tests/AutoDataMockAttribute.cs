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
            var mt = Resolve(pi);
            if (mt is null)
                throw new InvalidCastException($"Parameter type {pi.ParameterType.Name} is not supported");
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
            
            { () => type == typeof(List<bool?>),     () => value },
            { () => type == typeof(List<byte?>),     () => value },
            { () => type == typeof(List<short?>),    () => value },
            { () => type == typeof(List<int?>),      () => value },
            { () => type == typeof(List<long?>),     () => value },
            { () => type == typeof(List<float?>),    () => value },
            { () => type == typeof(List<double?>),   () => value },
            { () => type == typeof(List<decimal?>),  () => value },
            { () => type == typeof(List<char?>),     () => value },
            { () => type == typeof(List<string?>),   () => value },
            { () => type == typeof(List<Guid?>),     () => value },
            { () => type == typeof(List<DateTime?>), () => value },
                
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
            
            { () => IsUnderlyingTypeNullable(type, typeof(List<bool?>)),     () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<byte?>)),     () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<short?>)),    () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<int?>)),      () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<long?>)),     () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<float?>)),    () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<double?>)),   () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<decimal?>)),  () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<char?>)),     () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<string?>)),   () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<Guid?>)),     () => value },
            { () => IsUnderlyingTypeNullable(type, typeof(List<DateTime?>)), () => value },
            
            { () => type == typeof(List<List<bool>>),     () => value },
            { () => type == typeof(List<List<byte>>),     () => value },
            { () => type == typeof(List<List<short>>),    () => value },
            { () => type == typeof(List<List<int>>),      () => value },
            { () => type == typeof(List<List<long>>),     () => value },
            { () => type == typeof(List<List<float>>),    () => value },
            { () => type == typeof(List<List<double>>),   () => value },
            { () => type == typeof(List<List<decimal>>),  () => value },
            { () => type == typeof(List<List<char>>),     () => value },
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
            { () => type == typeof(List<List<char?>>),     () => value },
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
    
    private static object? Resolve(ParameterInfo parameterInfo)
    {
        //TODO: Refactor this method to now impl this Chain of Resp. pattern... Note: Order of links in the chain matter at times.
        var chain = new SetStringsAttributeHandler()
            .Then(new SetNullableStringsAttributeHandler())
            .Then(new StringParameterInfoHandler())
            .Then(new SetGuidsAttributeHandler())
            .Then(new SetNullableGuidsAttributeHandler())
            .Then(new GuidParameterInfoHandler());
        
        var result = chain.Handle(parameterInfo);
        if (result is not null) return result;
        
        var dict = new Dictionary<Func<bool>, Func<object>>
        {
            { () => IsNonNullableType(parameterInfo.ParameterType, typeof(bool)),     () => GetMockType<MockTypeBool, SetBoolsAttribute, bool>(parameterInfo) },
            { () => IsNonNullableType(parameterInfo.ParameterType, typeof(byte)),     () => GetMockType<MockTypeByte, SetBytesAttribute, byte>(parameterInfo) },
            { () => IsNonNullableType(parameterInfo.ParameterType, typeof(short)),    () => GetMockType<MockTypeShort, SetShortsAttribute, short>(parameterInfo) },
            { () => IsNonNullableType(parameterInfo.ParameterType, typeof(int)),      () => GetMockType<MockTypeInt, SetIntsAttribute, int>(parameterInfo) },
            { () => IsNonNullableType(parameterInfo.ParameterType, typeof(long)),     () => GetMockType<MockTypeLong, SetLongsAttribute, long>(parameterInfo) },
            { () => IsNonNullableType(parameterInfo.ParameterType, typeof(float)),    () => GetMockType<MockTypeFloat, SetFloatsAttribute, float>(parameterInfo) },
            { () => IsNonNullableType(parameterInfo.ParameterType, typeof(double)),   () => GetMockType<MockTypeDouble, SetDoublesAttribute, double>(parameterInfo) },
            { () => IsNonNullableType(parameterInfo.ParameterType, typeof(decimal)),  () => GetMockType<MockTypeDecimal, SetDecimalsAttribute, decimal>(parameterInfo) },
            { () => IsNonNullableType(parameterInfo.ParameterType, typeof(char)),     () => GetMockType<MockTypeChar, SetCharsAttribute, char>(parameterInfo) },
            //{ () => IsNonNullableType(parameterInfo.ParameterType, typeof(string)),   () => GetMockTypeString<SetStringsAttribute, SetNullableStringsAttribute>(parameterInfo) },
            //{ () => IsNonNullableType(parameterInfo.ParameterType, typeof(Guid)),     () => GetMockTypeGuid<SetGuidsAttribute>(parameterInfo) },
            { () => IsNonNullableType(parameterInfo.ParameterType, typeof(DateTime)), () => GetMockTypeDateTime<SetDateTimesAttribute>(parameterInfo) },
            { () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(bool)),     () => GetMockType<MockTypeNullableBool, SetNullableBoolsAttribute, bool?>(parameterInfo) },
            { () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(byte)),     () => GetMockType<MockTypeNullableByte, SetNullableBytesAttribute, byte?>(parameterInfo) },
            { () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(short)),    () => GetMockType<MockTypeNullableShort, SetNullableShortsAttribute, short?>(parameterInfo) },
            { () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(int)),      () => GetMockType<MockTypeNullableInt, SetNullableIntsAttribute, int?>(parameterInfo) },
            { () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(long)),     () => GetMockType<MockTypeNullableLong, SetNullableLongsAttribute, long?>(parameterInfo) },
            { () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(float)),    () => GetMockType<MockTypeNullableFloat, SetNullableFloatsAttribute, float?>(parameterInfo) },
            { () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(double)),   () => GetMockType<MockTypeNullableDouble, SetNullableDoublesAttribute, double?>(parameterInfo) },
            { () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(decimal)),  () => GetMockType<MockTypeNullableDecimal, SetNullableDecimalsAttribute, decimal?>(parameterInfo) },
            { () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(char)),     () => GetMockType<MockTypeNullableChar, SetNullableCharsAttribute, char?>(parameterInfo) },
            //{ () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(string)),   () => GetMockType<MockTypeNullableString, SetNullableStringsAttribute, string?>(parameterInfo) },
            //{ () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(Guid)),     Dm.NullableGuids },
            { () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(DateTime)), Dm.NullableDateTimes },
            
            { () => parameterInfo.ParameterType == typeof(List<bool>),     Dm.ListsOf<bool> },
            { () => parameterInfo.ParameterType == typeof(List<byte>),     Dm.ListsOf<byte> },
            { () => parameterInfo.ParameterType == typeof(List<short>),    Dm.ListsOf<short> },
            { () => parameterInfo.ParameterType == typeof(List<int>),      Dm.ListsOf<int> },
            { () => parameterInfo.ParameterType == typeof(List<long>),     Dm.ListsOf<long> },
            { () => parameterInfo.ParameterType == typeof(List<float>),    Dm.ListsOf<float> },
            { () => parameterInfo.ParameterType == typeof(List<double>),   Dm.ListsOf<double> },
            { () => parameterInfo.ParameterType == typeof(List<decimal>),  Dm.ListsOf<decimal> },
            { () => parameterInfo.ParameterType == typeof(List<char>),     Dm.ListsOf<char> },
            { () => parameterInfo.ParameterType == typeof(List<string>),   Dm.ListsOf<string> },
            { () => parameterInfo.ParameterType == typeof(List<Guid>),     Dm.ListsOf<Guid> },
            { () => parameterInfo.ParameterType == typeof(List<DateTime>), Dm.ListsOf<DateTime> },
            
            { () => parameterInfo.ParameterType == typeof(List<bool?>),     Dm.ListsOf<bool?> },
            { () => parameterInfo.ParameterType == typeof(List<byte?>),     Dm.ListsOf<byte?> },
            { () => parameterInfo.ParameterType == typeof(List<short?>),    Dm.ListsOf<short?> },
            { () => parameterInfo.ParameterType == typeof(List<int?>),      Dm.ListsOf<int?> },
            { () => parameterInfo.ParameterType == typeof(List<long?>),     Dm.ListsOf<long?> },
            { () => parameterInfo.ParameterType == typeof(List<float?>),    Dm.ListsOf<float?> },
            { () => parameterInfo.ParameterType == typeof(List<double?>),   Dm.ListsOf<double?> },
            { () => parameterInfo.ParameterType == typeof(List<decimal?>),  Dm.ListsOf<decimal?> },
            { () => parameterInfo.ParameterType == typeof(List<char?>),     Dm.ListsOf<char?> },
            { () => parameterInfo.ParameterType == typeof(List<string?>),   Dm.ListsOf<string?> },
            { () => parameterInfo.ParameterType == typeof(List<Guid?>),     Dm.ListsOf<Guid?> },
            { () => parameterInfo.ParameterType == typeof(List<DateTime?>), Dm.ListsOf<DateTime?> },
        };

        return dict
            .Where(kvp => kvp.Key())
            .Select(kvp => kvp.Value())
            .FirstOrDefault();
    }

    private static TMockType GetMockType<TMockType, TAttribute, TType>(ParameterInfo parameterInfo)
        where TAttribute : SetTypeAttribute<TType>
        where TMockType : IMockType<TType>, new()
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(TAttribute));
        if (attribute is null) return new TMockType();
        return (TMockType)((TAttribute)attribute).GetMockType();
    }
    
    private static IMockType<string> GetMockTypeString<TAttribute, TNullableAttribute>(ParameterInfo parameterInfo)
        where TAttribute : SetTypeAttribute<string>
        where TNullableAttribute : SetTypeAttribute<string?>
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(TAttribute));
        if (attribute is not null) return ((TAttribute)attribute).GetMockType();
        var nullableAttribute = parameterInfo.GetCustomAttribute(typeof(TNullableAttribute));
        return nullableAttribute is not null ? ((TNullableAttribute)nullableAttribute).GetMockType() : Dm.Strings();
    }
        
    private static IMockType<Guid> GetMockTypeGuid<TAttribute>(ParameterInfo parameterInfo)
        where TAttribute : SetTypeAttribute<Guid>
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(TAttribute));
        return attribute is null ? Dm.Guids() : ((TAttribute)attribute).GetMockType();
    }
        
    private static IMockType<DateTime> GetMockTypeDateTime<TAttribute>(ParameterInfo parameterInfo)
        where TAttribute : SetTypeAttribute<DateTime>
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(TAttribute));
        return attribute is null ? Dm.DateTimes() : ((TAttribute)attribute).GetMockType();
    }
    
    private static bool IsUnderlyingTypeNullable(Type type, Type underlyingType)
        => type.IsGenericType
           && type.GetGenericTypeDefinition() == typeof(Nullable<>)
           && Nullable.GetUnderlyingType(type) == underlyingType;

    private static bool IsNonNullableType(Type type, Type underlyingType)
        => !type.IsGenericType
           && type == underlyingType;
}

internal class ParameterInfoHandlerChain : IParameterInfoHandler
{
    private readonly IParameterInfoHandler _current;
    private readonly IParameterInfoHandler _next;

    public ParameterInfoHandlerChain(IParameterInfoHandler current, IParameterInfoHandler next)
        => (_current, _next) = (current, next);

    public object? Handle(ParameterInfo parameterInfo)
    {
        var obj = _current.Handle(parameterInfo);
        return obj ?? _next.Handle(parameterInfo);
    }
}

internal static class ParameterInfoHandlerExtensions
{
    public static ParameterInfoHandlerChain Then(this IParameterInfoHandler first, IParameterInfoHandler next) 
        => new(first, next);
}

internal interface IParameterInfoHandler
{
    object? Handle(ParameterInfo parameterInfo);
}


// =====


internal class BoolParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(bool) ? Dm.Bools() : null;
}

internal class ByteParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(byte) ? Dm.Bytes() : null;
}

internal class ShortParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(short) ? Dm.Shorts() : null;
}

internal class IntParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(int) ? Dm.Ints() : null;
}

internal class LongParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(long) ? Dm.Longs() : null;
}

internal class FloatParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(float) ? Dm.Floats() : null;
}

internal class DoubleParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(double) ? Dm.Doubles() : null;
}

internal class DecimalParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(decimal) ? Dm.Decimals() : null;
}
internal class CharParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(char) ? Dm.Chars() : null;
}

internal class StringParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(string) ? Dm.Strings() : null;
}

internal class GuidParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(Guid) ? Dm.Guids() : null;
}

internal class DateTimeParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(DateTime) ? Dm.DateTimes() : null;
}


internal class SetBoolsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetBoolsAttribute));
        return attribute is not null ? ((SetBoolsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetBytesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetBytesAttribute));
        return attribute is not null ? ((SetBytesAttribute)attribute).GetMockType() : null;
    }
}

internal class SetShortsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetShortsAttribute));
        return attribute is not null ? ((SetShortsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetIntsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetIntsAttribute));
        return attribute is not null ? ((SetIntsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetLongsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetLongsAttribute));
        return attribute is not null ? ((SetLongsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetFloatsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetFloatsAttribute));
        return attribute is not null ? ((SetFloatsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetDoublesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetDoublesAttribute));
        return attribute is not null ? ((SetDoublesAttribute)attribute).GetMockType() : null;
    }
}

internal class SetDecimalsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetDecimalsAttribute));
        return attribute is not null ? ((SetDecimalsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetCharsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetCharsAttribute));
        return attribute is not null ? ((SetCharsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetStringsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetStringsAttribute));
        return attribute is not null ? ((SetStringsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetGuidsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetGuidsAttribute));
        return attribute is not null ? ((SetGuidsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetDateTimeAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetDateTimesAttribute));
        return attribute is not null ? ((SetDateTimesAttribute)attribute).GetMockType() : null;
    }
}

// =====

internal class SetNullableBoolsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableBoolsAttribute));
        return attribute is not null ? ((SetNullableBoolsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetNullableBytesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableBytesAttribute));
        return attribute is not null ? ((SetNullableBytesAttribute)attribute).GetMockType() : null;
    }
}

internal class SetNullableShortsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableShortsAttribute));
        return attribute is not null ? ((SetNullableShortsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetNullableIntsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableIntsAttribute));
        return attribute is not null ? ((SetNullableIntsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetNullableLongsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableLongsAttribute));
        return attribute is not null ? ((SetNullableLongsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetNullableFloatsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableFloatsAttribute));
        return attribute is not null ? ((SetNullableFloatsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetNullableDoublesAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableDoublesAttribute));
        return attribute is not null ? ((SetNullableDoublesAttribute)attribute).GetMockType() : null;
    }
}

internal class SetNullableCharsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableCharsAttribute));
        return attribute is not null ? ((SetNullableCharsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetNullableStringsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableStringsAttribute));
        return attribute is not null ? ((SetNullableStringsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetNullableGuidsAttributeHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableGuidsAttribute));
        return attribute is not null ? ((SetNullableGuidsAttribute)attribute).GetMockType() : null;
    }
}

//TODO: Impl. for SetNullableDateTimesAttribute doesn't exist yet
// internal class SetNullableDateTimesAttributeHandler : IParameterInfoHandler
// {
//     public object? Handle(ParameterInfo parameterInfo)
//     {
//         var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableDateTimesAttribute));
//         return attribute is not null ? ((SetNullableDateTimesAttribute)attribute).GetMockType() : null;
//     }
// }

