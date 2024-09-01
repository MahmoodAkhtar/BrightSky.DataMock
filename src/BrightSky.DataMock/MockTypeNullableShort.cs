namespace BrightSky.DataMock;

public record MockTypeNullableShort : 
    IMockType<short?>, 
    IMockTypeMinMax<short?, short, short, MockTypeNullableShort>, 
    IMockTypeRange<short?, short, short, MockTypeNullableShort>, 
    IMockTypeNullableProbability<short?, MockTypeNullableShort>
{
    private readonly Random _random = new();

    public short? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(short minValue, short maxValue) if you require negative values.");
        
        var chosen = new List<WeightedValue<Func<short?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextShort(MinValue, MaxValue), 100 - NullablePercentage),
        }.Next();
        
        return chosen();
    }

    public short MinValue { get; private set; } = short.MinValue;
    public short MaxValue { get; private set; } = short.MaxValue;

    public MockTypeNullableShort Min(short minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeNullableShort Max(short maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public int NullablePercentage { get; private set; } = 50;

    public MockTypeNullableShort NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        NullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableShort Range(short minValue, short maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}