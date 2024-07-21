namespace BrightSky.DataMock;

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

    public static List<bool> DistributeTrueProbability(this List<bool> source, int truePercentage)
    {
        var desired =  (int)Math.Round(source.Count * (truePercentage / 100.0m), MidpointRounding.AwayFromZero);
        var count = source.Count(x => x is true);
        if (desired == count) return source;
        source = AddTrueIfNeeded(source, desired, count);
        source = AddFalseIfNeeded(source, desired, count);
        return source.Shuffle();
    }

    private static List<bool> AddFalseIfNeeded(List<bool> source, int desired, int count)
    {
        if (desired >= count) return source;
        Enumerable.Range(1, count - desired).ToList().ForEach(_ => source[source.IndexOf(true)] = false);
        return source;
    }

    private static List<bool> AddTrueIfNeeded(List<bool> source, int desired, int count)
    {
        if (desired <= count) return source;
        Enumerable.Range(1, desired - count).ToList().ForEach(_ => source[source.IndexOf(false)] = true);
        return source;
    }

    public static List<bool> ToList(this MockTypeBool mockType, int size = 100)
    {
        var list = mockType.ToList<bool>(size).DistributeTrueProbability(mockType.TruePercentage);
        return list;
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

    private static List<bool?> PopulateRange(RangedValue<bool?> rangedValue, List<bool?> list)
    {
        var startIndex = rangedValue.Start -1;
        var endIndex = rangedValue.End -1;
        for (var i = startIndex; i <= endIndex; i++)
            list[i] = rangedValue.Value;
        return list;
    }

    public static List<T?> DistributeNullableProbability<TMin, TMax, T, TNullableMockType>(
        this List<T?> source, 
        TNullableMockType nullableMockType, 
        IMockTypeRange<T, TMin, TMax, IMockType<T>> nonNullableMockType) 
        where T : struct
        where TNullableMockType : IMockTypeNullableProbability<T, IMockType<T?>>, IMockTypeRange<T?, TMin, TMax, IMockType<T?>>
    {
        var desired = (int)Math.Round(source.Count * (nullableMockType.NullablePercentage / 100.0m), MidpointRounding.AwayFromZero);
        var count = source.Count(x => x is null);
        if (desired == count) return source;
        source = AddNullIfNeeded(source, desired, count);
        source = AddNotNullIfNeeded(source, desired, count, nonNullableMockType, nullableMockType.MinValue, nullableMockType.MaxValue);
        return source.Shuffle();
    }

    private static List<T?> AddNullIfNeeded<T>(List<T?> source, int desired, int count) where T : struct
    {
        if (desired <= count) return source;
        Enumerable.Range(1, desired - count).ToList().ForEach(_ => source[source.FindIndex(x => x is not null)] = null);
        return source;
    }

    private static List<T?> AddNotNullIfNeeded<TMin, TMax, T>(
        List<T?> source, int desired, int count, 
        IMockTypeRange<T, TMin, TMax, IMockType<T>> nonNullableMockType, TMin minValue, TMax maxValue) where T : struct
    {
        if (desired >= count) return source;
        Enumerable.Range(1, count - desired).ToList().ForEach(_ => source[source.IndexOf(null)] = nonNullableMockType.Range(minValue, maxValue).Get());
        return source;
    }
    
    public static List<int?> ToList(this MockTypeNullableInt mockType, int size = 100)
    {
        var list = mockType.ToList<int?>(size).DistributeNullableProbability(mockType, new MockTypeInt());
        return list;
    }
}