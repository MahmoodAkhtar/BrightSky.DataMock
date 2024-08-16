using System.Text;

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
        var list = Enumerable.Range(0, size).ToList().Select(x => (bool)default!).ToList();
        var weightedValues = new List<WeightedValue<bool>>
        {
            new(true, (int)Math.Ceiling(size * (mockType.TruePercentage / 100.0))),
            new(false, (int)Math.Floor(size * (mockType.FalsePercentage / 100.0))),
        };
        var rangedValues = Weighted<bool>.RangeValues(weightedValues);
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

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
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

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
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

        return list.Shuffle();
    }
    
    public static List<char?> ToList(this MockTypeNullableChar mockType, int size = 100)
    {
        var random = new Random();
        var list = Enumerable.Range(0, size).ToList().Select(x => (char?)default).ToList();
        var weightedValues = new List<WeightedValue<Func<char?>>>
        {
            new(() => null, (int)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(() => mockType.Characters.Count is 0 
                ? random.NextChar(mockType.MinValue, mockType.MaxValue)
                : mockType.Characters[random.Next(mockType.Characters.Count)], 
                (int)Math.Floor(size * ((100 - mockType.NullablePercentage) / 100.0))),
        };
        var rangedValues = Weighted<Func<char?>>.RangeValues(weightedValues);
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

        return list.Shuffle();
    }
    
    public static List<string?> ToList(this MockTypeNullableString mockType, int size = 100)
    {
        var list = Enumerable.Range(0, size).ToList().Select(x => (string?)default).ToList();
        var weightedValues = new List<WeightedValue<Func<string?>>>
        {
            new(() => null, (int)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(() => 
                {
                    var array = Dm.Chars().From(mockType.Characters.ToArray()).ToList(mockType.Length).ToArray();
                    return new string(array);
                }, 
                (int)Math.Floor(size * ((100 - mockType.NullablePercentage) / 100.0))),
        };
        var rangedValues = Weighted<Func<string?>>.RangeValues(weightedValues);
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

        return list.Shuffle();
    }
    
    public static List<short?> ToList(this MockTypeNullableShort mockType, int size = 100)
    {
        var random = new Random();
        var list = Enumerable.Range(0, size).ToList().Select(x => (short?)default).ToList();
        var weightedValues = new List<WeightedValue<Func<short?>>>
        {
            new(() => null, (int)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(() => random.NextShort(mockType.MinValue, mockType.MaxValue), (int)Math.Floor(size * ((100 - mockType.NullablePercentage) / 100.0))),
        };
        var rangedValues = Weighted<Func<short?>>.RangeValues(weightedValues);
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

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
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

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
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

        return list.Shuffle();
    }
    
    public static List<float?> ToList(this MockTypeNullableFloat mockType, int size = 100)
    {
        var random = new Random();
        var list = Enumerable.Range(0, size).ToList().Select(x => (float?)default).ToList();
        var weightedValues = new List<WeightedValue<Func<float?>>>
        {
            new(() => null, (int)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(() => random.NextFloat(mockType.MinValue, mockType.MaxValue), (int)Math.Floor(size * ((100 - mockType.NullablePercentage) / 100.0))),
        };
        var rangedValues = Weighted<Func<float?>>.RangeValues(weightedValues);
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

        return list.Shuffle();
    }
        
    public static List<double?> ToList(this MockTypeNullableDouble mockType, int size = 100)
    {
        var random = new Random();
        var list = Enumerable.Range(0, size).ToList().Select(x => (double?)default).ToList();
        var weightedValues = new List<WeightedValue<Func<double?>>>
        {
            new(() => null, (int)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(() => random.NextDouble(mockType.MinValue, mockType.MaxValue), (int)Math.Floor(size * ((100 - mockType.NullablePercentage) / 100.0))),
        };
        var rangedValues = Weighted<Func<double?>>.RangeValues(weightedValues);
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

        return list.Shuffle();
    }
    
    public static List<decimal?> ToList(this MockTypeNullableDecimal mockType, int size = 100)
    {
        var random = new Random();
        var list = Enumerable.Range(0, size).ToList().Select(x => (decimal?)default).ToList();
        var weightedValues = new List<WeightedValue<Func<decimal?>>>
        {
            new(() => null, (int)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(() => random.NextDecimal(mockType.MinValue, mockType.MaxValue), (int)Math.Floor(size * ((100 - mockType.NullablePercentage) / 100.0))),
        };
        var rangedValues = Weighted<Func<decimal?>>.RangeValues(weightedValues);
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

        return list.Shuffle();
    }
    
    public static List<string> ToList(this MockTypeFormattedString mockType, int size = 100)
    {
        if (size < 0)
            throw new ArgumentOutOfRangeException(nameof(size), $"{nameof(size)} {size} must be greater than or equal to zero.");

        var pt = new MockParamValueTemplate(mockType.Template);
        pt.AddRange(mockType.ParamValues);
        var list = pt.ToList(size);
        
        return list;
    }
    
    public static List<DateTime?> ToList(this MockTypeNullableDateTime mockType, int size = 100)
    {
        var random = new Random();
        var list = Enumerable.Range(0, size).ToList().Select(x => (DateTime?)default).ToList();
        var weightedValues = new List<WeightedValue<Func<DateTime?>>>
        {
            new(() => null, (int)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(() => new DateTime(random.NextInt64(mockType.MinValue.Ticks, mockType.MaxValue.Ticks)), (int)Math.Floor(size * ((100 - mockType.NullablePercentage) / 100.0))),
        };
        var rangedValues = Weighted<Func<DateTime?>>.RangeValues(weightedValues);
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

        return list.Shuffle();
    }
    
    public static List<Guid?> ToList(this MockTypeNullableGuid mockType, int size = 100)
    {
        var random = new Random();
        var list = Enumerable.Range(0, size).ToList().Select(x => (Guid?)default).ToList();
        var weightedValues = new List<WeightedValue<Func<Guid?>>>
        {
            new(() => null, (int)Math.Ceiling(size * (mockType.NullablePercentage / 100.0))),
            new(() => Guid.NewGuid(), (int)Math.Floor(size * ((100 - mockType.NullablePercentage) / 100.0))),
        };
        var rangedValues = Weighted<Func<Guid?>>.RangeValues(weightedValues);
        list = rangedValues.Aggregate(list, (current, rangedValue) => PopulateRange(rangedValue, current));

        return list.Shuffle();
    }
    
    internal static string Paramify(this MockParamValue paramValue) => paramValue.Name.Paramify();
    
    internal static string Paramify(this string name) => $"{{#{name}}}";
    
    internal static string GenerateColumnsRow(this List<MockParamValue> paramValues, string separator, string newLine)
    {
        var list = paramValues.Select(pv => pv.Name).ToList();
        var sb = new StringBuilder();
        sb.Append(string.Join(separator, list));
        sb.Append(newLine);
        
        return sb.ToString();
    }
    
    internal static string GenerateDataRowTemplate(this List<MockParamValue> paramValues, string separator, string newLine)
    {
        var list = paramValues.Select(pv => pv.Paramify()).ToList();
        var sb = new StringBuilder();
        sb.Append(string.Join(separator, list));
        sb.Append(newLine);
        
        return sb.ToString();
    }
}