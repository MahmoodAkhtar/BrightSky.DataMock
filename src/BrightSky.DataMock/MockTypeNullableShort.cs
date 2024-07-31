namespace BrightSky.DataMock;

public record MockTypeNullableShort : 
    IMockType<short?>, 
    IMockTypeMinMax<short?, short, short, MockTypeNullableShort>, 
    IMockTypeRange<short?, short, short, MockTypeNullableShort>, 
    IMockTypeNullableProbability<short?, MockTypeNullableShort>
{
    private readonly Random _random = new();
    private short _maxValue = 1000;
    private short _minValue;
    private int _nullablePercentage = 50;

    public short? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(short minValue, short maxValue) if you require negative values.");
        
        var weightedValues = new List<WeightedValue<Func<short?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextShort(MinValue, MaxValue), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<short?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }

    public short MinValue => _minValue;
    public short MaxValue => _maxValue;

    public MockTypeNullableShort Min(short minValue)
    {
        _minValue = minValue;
        return this;
    }

    public MockTypeNullableShort Max(short maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public int NullablePercentage => _nullablePercentage;

    public MockTypeNullableShort NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableShort Range(short minValue, short maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}