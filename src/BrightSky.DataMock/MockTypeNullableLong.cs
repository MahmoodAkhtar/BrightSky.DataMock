namespace BrightSky.DataMock;

public record MockTypeNullableLong : IMockType<long?>, IMockTypeRange<long?, long, long, MockTypeNullableLong>, IMockTypeNullableProbability<long?, MockTypeNullableLong>
{
    private readonly Random _random = new();
    private long _minValue;
    private long _maxValue = 1000;
    private int _nullablePercentage = 50;

    public int NullablePercentage => _nullablePercentage;
    
    public MockTypeNullableLong NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }

    public long? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(long minValue, long maxValue) if you require negative values.");
        
        var weightedValues = new List<WeightedValue<Func<long?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextInt64(MinValue, MaxValue), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<long?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }

    public long MinValue => _minValue;
    public long MaxValue => _maxValue;

    public MockTypeNullableLong Min(long minValue)
    {
        _minValue = minValue;
        return this;
    }
    
    public MockTypeNullableLong Max(long maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public MockTypeNullableLong Range(long minValue, long maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}