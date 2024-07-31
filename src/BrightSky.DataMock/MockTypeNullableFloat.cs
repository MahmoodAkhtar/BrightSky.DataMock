namespace BrightSky.DataMock;

public record MockTypeNullableFloat : 
    IMockType<float?>, 
    IMockTypeMinMax<float?, float, float, MockTypeNullableFloat>, 
    IMockTypeRange<float?, float, float, MockTypeNullableFloat>, 
    IMockTypeNullableProbability<float?, MockTypeNullableFloat>
{
    private readonly Random _random = new();
    private float _maxValue = 1000;
    private float _minValue;
    private int _nullablePercentage = 50;

    public float? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(float minValue, float maxValue) if you require negative values.");
        
        var weightedValues = new List<WeightedValue<Func<float?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextFloat(MinValue, MaxValue), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<float?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }

    public float MinValue => _minValue;
    public float MaxValue => _maxValue;

    public MockTypeNullableFloat Min(float minValue)
    {
        _minValue = minValue;
        return this;
    }

    public MockTypeNullableFloat Max(float maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public int NullablePercentage => _nullablePercentage;

    public MockTypeNullableFloat NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableFloat Range(float minValue, float maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}