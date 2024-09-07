namespace BrightSky.DataMock;

public record MockTypeNullableDouble : 
    IMockType<double?>, 
    IMockTypeMinMax<double?, double, double, MockTypeNullableDouble>,
    IMockTypeRange<double?, double, double, MockTypeNullableDouble>, 
    IMockTypeNullableProbability<double?, MockTypeNullableDouble>
{
    private readonly Random _random = new();

    public double? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(double minValue, double maxValue) if you require negative values.");
        
        var chosen = new List<WeightedValue<Func<double?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextDouble(MinValue, MaxValue), 100 - NullablePercentage),
        }.Next();
        
        return chosen();
    }

    public double MinValue { get; private set; } = double.MinValue;
    public double MaxValue { get; private set; } = double.MaxValue;

    public MockTypeNullableDouble Min(double minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeNullableDouble Max(double maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeNullableDouble NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableDouble Range(double minValue, double maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}