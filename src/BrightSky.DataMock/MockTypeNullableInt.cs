namespace BrightSky.DataMock;

public record MockTypeNullableInt : 
    IMockType<int?>, 
    IMockTypeMinMax<int?, int, int, MockTypeNullableInt>, 
    IMockTypeRange<int?, int, int, MockTypeNullableInt>, 
    IMockTypeNullableProbability<int?, MockTypeNullableInt>
{
    private readonly Random _random = new();

    public int? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(int minValue, int maxValue) if you require negative values.");
        
        var weightedValues = new List<WeightedValue<Func<int?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.Next(MinValue, MaxValue), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<int?>>(weightedValues);
        var chosen = weighted.Next();
        
        return chosen();
    }

    public int MinValue { get; private set; } = int.MinValue;
    public int MaxValue { get; private set; } = int.MaxValue;

    public MockTypeNullableInt Min(int minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeNullableInt Max(int maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public int NullablePercentage { get; private set; } = 50;

    public MockTypeNullableInt NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        NullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableInt Range(int minValue, int maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(maxValue)} {maxValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}