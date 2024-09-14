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
        var chain = new SetStringsParameterInfoHandler()
            .Then(new SetNullableStringsParameterInfoHandler())
            .Then(new StringParameterInfoHandler());
        
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
            { () => IsNonNullableType(parameterInfo.ParameterType, typeof(Guid)),     () => GetMockTypeGuid<SetGuidsAttribute>(parameterInfo) },
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
            { () => IsUnderlyingTypeNullable(parameterInfo.ParameterType, typeof(Guid)),     Dm.NullableGuids },
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

internal class StringParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(string) ? Dm.Strings() : null;
}

internal class SetStringsParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetStringsAttribute));
        return attribute is not null ? ((SetStringsAttribute)attribute).GetMockType() : null;
    }
}

internal class SetNullableStringsParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
    {
        var attribute = parameterInfo.GetCustomAttribute(typeof(SetNullableStringsAttribute));
        return attribute is not null ? ((SetNullableStringsAttribute)attribute).GetMockType() : null;
    }
}