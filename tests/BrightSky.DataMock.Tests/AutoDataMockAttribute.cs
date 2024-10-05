﻿using System.Reflection;
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
        var chain = new SetBoolsAttributeHandler()
            .Then(new SetNullableBoolsAttributeHandler())
            .Then(new BoolParameterInfoHandler())
            
            .Then(new SetBytesAttributeHandler())
            .Then(new SetNullableBytesAttributeHandler())
            .Then(new ByteParameterInfoHandler())
            
            .Then(new SetShortsAttributeHandler())
            .Then(new SetNullableShortsAttributeHandler())
            .Then(new ShortParameterInfoHandler())
            
            .Then(new SetIntsAttributeHandler())
            .Then(new SetNullableIntsAttributeHandler())
            .Then(new IntParameterInfoHandler())
            
            .Then(new SetLongsAttributeHandler())
            .Then(new SetNullableLongsAttributeHandler())
            .Then(new LongParameterInfoHandler())  
            
            .Then(new SetFloatsAttributeHandler())
            .Then(new SetNullableFloatsAttributeHandler())
            .Then(new FloatParameterInfoHandler())  
            
            .Then(new SetDoublesAttributeHandler())
            .Then(new SetNullableDoublesAttributeHandler())
            .Then(new DoubleParameterInfoHandler())  
            
            .Then(new SetDecimalsAttributeHandler())
            .Then(new SetNullableDecimalsAttributeHandler())
            .Then(new DecimalParameterInfoHandler())  
            
            .Then(new SetCharsAttributeHandler())
            .Then(new SetNullableCharsAttributeHandler())
            .Then(new CharParameterInfoHandler())

            .Then(new SetStringsAttributeHandler())
            .Then(new SetNullableStringsAttributeHandler())
            .Then(new StringParameterInfoHandler())
                        
            .Then(new SetGuidsAttributeHandler())
            .Then(new SetNullableGuidsAttributeHandler())
            .Then(new GuidParameterInfoHandler())    

            .Then(new SetDateTimesAttributeHandler())
            .Then(new SetNullableDateTimesAttributeHandler())
            .Then(new DateTimeParameterInfoHandler())
            
            .Then(new SetListOfBoolsAttributeHandler())
            .Then(new SetListOfNullableBoolsAttributeHandler())
            .Then(new ListOfBoolParameterInfoHandler())
            
            // ...others
            ;
        
        var result = chain.Handle(parameterInfo);
        if (result is not null) return result;
        
        var dict = new Dictionary<Func<bool>, Func<object>>
        {
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