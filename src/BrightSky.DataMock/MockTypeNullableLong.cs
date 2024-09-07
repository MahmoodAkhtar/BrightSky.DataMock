namespace BrightSky.DataMock;

public record MockTypeNullableLong : 
    IMockType<long?>, 
    IMockTypeMinMax<long?, long, long, MockTypeNullableLong>, 
    IMockTypeRange<long?, long, long, MockTypeNullableLong>, 
    IMockTypeNullableProbability<long?, MockTypeNullableLong>
{
    private readonly Random _random = new();

    public long? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(long minValue, long maxValue) if you require negative values.");
        
        var chosen = new List<WeightedValue<Func<long?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextInt64(MinValue, MaxValue), 100 - NullablePercentage),
        }.Next();
        
        return chosen();
    }

    public long MinValue { get; private set; } = long.MinValue;
    public long MaxValue { get; private set; } = long.MaxValue;

    public MockTypeNullableLong Min(long minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeNullableLong Max(long maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeNullableLong NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableLong Range(long minValue, long maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}