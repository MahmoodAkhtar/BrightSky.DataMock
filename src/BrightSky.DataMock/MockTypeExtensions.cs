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

        if (desired > count)
        {
            var toAdd = desired - count;
            for (var i = 0; i < toAdd; i++)
                source[source.IndexOf(false)] = true;
        }

        if (desired < count)
        {
            var toMinus = count - desired;
            for (var i = 0; i < toMinus; i++)
                source[source.IndexOf(true)] = false;            
        }
        
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
        
        var desiredTrue =  (int)Math.Round((size - desiredNullable) * (mockType.TruePercentage / 100.0m), MidpointRounding.AwayFromZero);
        var countTrue = list.Count(x => x is true);

        if (desiredTrue == countTrue && desiredNullable == countNullable 
            || (desiredTrue+desiredNullable) >= size) return list;

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
    
    public static List<int?> ToList(this MockTypeNullableInt mockType, int size = 100)
    {
        var list = mockType.ToList<int?>(size);

        var desired =  (int)Math.Round(size * (mockType.NullablePercentage / 100.0m), MidpointRounding.AwayFromZero);
        var count = list.Count(x => x is null);

        if (desired == count) return list;

        if (desired > count)
        {
            var toAdd = desired - count;
            for (var i = 0; i < toAdd; i++)
                list[list.FindIndex(x => x is not null)] = null;
        }

        if (desired < count)
        {
            var toMinus = count - desired;
            for (var i = 0; i < toMinus; i++)
                list[list.IndexOf(null)] = new MockTypeInt().Range(mockType.MinValue, mockType.MaxValue).Get();            
        }
        
        return list;
    }
}