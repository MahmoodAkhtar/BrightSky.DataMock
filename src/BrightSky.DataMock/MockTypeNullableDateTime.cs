namespace BrightSky.DataMock;

public record MockTypeNullableDateTime : 
    IMockType<DateTime?>, 
    IMockTypeMinMax<DateTime?, DateTime, DateTime, MockTypeNullableDateTime>, 
    IMockTypeRange<DateTime?, DateTime, DateTime, MockTypeNullableDateTime>, 
    IMockTypeNullableProbability<DateTime?, MockTypeNullableDateTime>
{
    private readonly Random _random = new();
    private long _minValue; // 1st Jan 0001
    private long _maxValue = DateTime.MaxValue.Ticks;
    private int _nullablePercentage = 50;

    public DateTime? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue}.");
        
        var weightedValues = new List<WeightedValue<Func<DateTime?>>>
        {
            new(() => null, NullablePercentage),
            new(() => new DateTime(_random.NextInt64(_minValue, _maxValue)), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<DateTime?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }

    public DateTime MinValue => new(_minValue);
    public DateTime MaxValue => new(_maxValue);

    public MockTypeNullableDateTime Min(DateTime minValue)
    {
        _minValue = minValue.Ticks;
        return this;
    }

    public MockTypeNullableDateTime Max(DateTime maxValue)
    {
        _maxValue = maxValue.Ticks;
        return this;
    }

    public int NullablePercentage => _nullablePercentage;

    public MockTypeNullableDateTime NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableDateTime Range(DateTime minValue, DateTime maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue.Ticks;
        _maxValue = maxValue.Ticks;
        return this;
    }
}