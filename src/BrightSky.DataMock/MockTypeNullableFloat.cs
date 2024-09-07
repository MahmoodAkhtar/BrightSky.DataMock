namespace BrightSky.DataMock;

public record MockTypeNullableFloat : 
    IMockType<float?>, 
    IMockTypeMinMax<float?, float, float, MockTypeNullableFloat>, 
    IMockTypeRange<float?, float, float, MockTypeNullableFloat>, 
    IMockTypeNullableProbability<float?, MockTypeNullableFloat>
{
    private readonly Random _random = new();

    public float? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(float minValue, float maxValue) if you require negative values.");
        
        var chosen = new List<WeightedValue<Func<float?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextFloat(MinValue, MaxValue), 100 - NullablePercentage),
        }.Next();
        
        return chosen();
    }

    public float MinValue { get; private set; } = float.MinValue;
    public float MaxValue { get; private set; } = float.MaxValue;

    public MockTypeNullableFloat Min(float minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeNullableFloat Max(float maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeNullableFloat NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableFloat Range(float minValue, float maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}