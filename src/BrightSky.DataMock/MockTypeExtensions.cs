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
    
    // TODO: Need to refactor this to reduce complexity
    public static List<bool?> ToList(this MockTypeNullableBool mockType, int size = 100)
    {
        var list = mockType.ToList<bool?>(size);

        var desiredNullable =  (int)Math.Round(size * (mockType.NullablePercentage / 100.0m), MidpointRounding.AwayFromZero);
        var countNullable = list.Count(x => x is null);
        
        // TODO: bug in below line...Need to rewrite this whole method really!
        var desiredTrue =  (int)Math.Round((size - desiredNullable) * (mockType.TruePercentage / 100.0m), MidpointRounding.AwayFromZero);
        var countTrue = list.Count(x => x is true);

        if (desiredTrue == countTrue && desiredNullable == countNullable 
            || desiredTrue+desiredNullable >= size) return list;

        if (desiredTrue > countTrue)
        {
            var toAdd = desiredTrue - countTrue;
            for (var i = 0; i < toAdd; i++)
                list[list.IndexOf(false)] = true;
        }

        if (desiredTrue < countTrue)
        {
            var toMinus = countTrue - desiredTrue;
            for (var i = 0; i < toMinus; i++)
                list[list.IndexOf(true)] = false;            
        }

        if (desiredNullable > countNullable)
        {
            var toAdd = desiredNullable - countNullable;
            for (var i = 0; i < toAdd; i++)
                list[list.FindIndex(x => x is not null)] = null;
        }

        if (desiredNullable < countNullable)
        {
            var toMinus = countNullable - desiredNullable;
            for (var i = 0; i < toMinus; i++)
                list[list.IndexOf(null)] = new MockTypeBool().TrueProbability(mockType.TruePercentage).Get();            
        }
        
        return list;
    }
    
    public static List<T?> DistributeNullableProbability<TMin, TMax, T, TNullableMockType>(
        this List<T?> source, 
        TNullableMockType nullableMockType, 
        IMockTypeRange<T, TMin, TMax, IMockType<T>> nonNullableMockType) 
        where T : struct
        where TNullableMockType : IMockTypeNullableProbability<T, IMockType<T?>>, IMockTypeRange<T?, TMin, TMax, IMockType<T?>>
    {
        var desired =  (int)Math.Round(source.Count * (nullableMockType.NullablePercentage / 100.0m), MidpointRounding.AwayFromZero);
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