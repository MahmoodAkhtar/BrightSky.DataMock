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
    
    public static List<bool> ToList(this MockTypeBool mockType, int size = 100)
    {
        var list = mockType.ToList<bool>(size);

        var desired =  (int)Math.Round(size * (mockType.Percentage / 100.0m), MidpointRounding.AwayFromZero);
        var count = list.Count(x => x is true);

        if (desired == count) return list;

        if (desired > count)
        {
            var toAdd = desired - count;
            for (var i = 0; i < toAdd; i++)
                list[list.IndexOf(false)] = true;
        }

        if (desired < count)
        {
            var toMinus = count - desired;
            for (var i = 0; i < toMinus; i++)
                list[list.IndexOf(true)] = false;            
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