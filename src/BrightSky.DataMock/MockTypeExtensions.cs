﻿namespace BrightSky.DataMock;

public static class MockTypeExtensions
{
    public static List<T> ToList<T>(this IMockType<T> mockType, int size = 100)
    {
        if (size < 0)
            throw new ArgumentOutOfRangeException(nameof(size), $"{nameof(size)} {size} must be greater than or equal to zero.");
        
        var list = new List<T>();
        Enumerable.Range(1, size).ToList().ForEach(_ => list.Add(mockType.Get()));
        
        return list;
    }

    public static List<bool> ToList(this MockTypeBool mockType, int size = 100)
    {
        var list = Enumerable.Range(0, size).ToList().Select(x => (bool)default!).ToList();
        var weightedValues = new List<WeightedValue<bool>>
        {
            new(true, (int)Math.Ceiling(size * (mockType.TruePercentage / 100.0))),
            new(false, (int)Math.Floor(size * (mockType.FalsePercentage / 100.0))),
        };
        var rangedValues = Weighted<bool>.RangeValues(weightedValues);        
        foreach (var rangedValue in rangedValues)
            list = PopulateRange(rangedValue, list);
        
        return list.Shuffle();        
    }
    
    public static List<bool?> ToList(this MockTypeNullableBool mockType, int size = 100)
    {
        var list = Enumerable.Range(0, size).ToList().Select(x => (bool?)default).ToList();
        var weightedValues = new List<WeightedValue<bool?>>
        {
            new(null, (int)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(true, (int)Math.Floor(size * (mockType.TruePercentage / 100.0))),
            new(false, (int)Math.Floor(size * (mockType.FalsePercentage / 100.0))),
        };
        var rangedValues = Weighted<bool?>.RangeValues(weightedValues);
        foreach (var rangedValue in rangedValues)
            list = PopulateRange(rangedValue, list);
        
        return list.Shuffle();
    }

    private static List<T?> PopulateRange<T>(RangedValue<T?> rangedValue, List<T?> list)
    {
        var startIndex = rangedValue.Start -1;
        var endIndex = rangedValue.End -1;
        for (var i = startIndex; i <= endIndex; i++)
            list[i] = rangedValue.Value;
        return list;
    }
    
    private static List<T?> PopulateRange<T>(RangedValue<Func<T?>> rangedValue, List<T?> list)
    {
        var startIndex = rangedValue.Start -1;
        var endIndex = rangedValue.End -1;
        for (var i = startIndex; i <= endIndex; i++)
            list[i] = rangedValue.Value();
        return list;
    }
    
    public static List<byte?> ToList(this MockTypeNullableByte mockType, int size = 100)
    {
        var random = new Random();
        var list = Enumerable.Range(0, size).ToList().Select(x => (byte?)default).ToList();
        var weightedValues = new List<WeightedValue<Func<byte?>>>
        {
            new(() => null, (int)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(() => random.NextByte(mockType.MinValue, mockType.MaxValue), (int)Math.Floor(size * ((100 - mockType.NullablePercentage) / 100.0))),
        };
        var rangedValues = Weighted<Func<byte?>>.RangeValues(weightedValues);
        foreach (var rangedValue in rangedValues)
            list = PopulateRange(rangedValue, list);
        
        return list.Shuffle();
    }
    
    public static List<short?> ToList(this MockTypeNullableShort mockType, int size = 100)
    {
        var random = new Random();
        var list = Enumerable.Range(0, size).ToList().Select(x => (short?)default).ToList();
        var weightedValues = new List<WeightedValue<Func<short?>>>
        {
            new(() => null, (short)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(() => random.NextShort(mockType.MinValue, mockType.MaxValue), (short)Math.Floor(size * ((100 - mockType.NullablePercentage) / 100.0))),
        };
        var rangedValues = Weighted<Func<short?>>.RangeValues(weightedValues);
        foreach (var rangedValue in rangedValues)
            list = PopulateRange(rangedValue, list);
        
        return list.Shuffle();
    }
    
    public static List<int?> ToList(this MockTypeNullableInt mockType, int size = 100)
    {
        var random = new Random();
        var list = Enumerable.Range(0, size).ToList().Select(x => (int?)default).ToList();
        var weightedValues = new List<WeightedValue<Func<int?>>>
        {
            new(() => null, (int)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(() => random.Next(mockType.MinValue, mockType.MaxValue), (int)Math.Floor(size * ((100 - mockType.NullablePercentage) / 100.0))),
        };
        var rangedValues = Weighted<Func<int?>>.RangeValues(weightedValues);
        foreach (var rangedValue in rangedValues)
            list = PopulateRange(rangedValue, list);
        
        return list.Shuffle();
    }
    
    public static List<long?> ToList(this MockTypeNullableLong mockType, int size = 100)
    {
        var random = new Random();
        var list = Enumerable.Range(0, size).ToList().Select(x => (long?)default).ToList();
        var weightedValues = new List<WeightedValue<Func<long?>>>
        {
            new(() => null, (int)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(() => random.NextInt64(mockType.MinValue, mockType.MaxValue), (int)Math.Floor(size * ((100 - mockType.NullablePercentage) / 100.0))),
        };
        var rangedValues = Weighted<Func<long?>>.RangeValues(weightedValues);
        foreach (var rangedValue in rangedValues)
            list = PopulateRange(rangedValue, list);
        
        return list.Shuffle();
    }
}