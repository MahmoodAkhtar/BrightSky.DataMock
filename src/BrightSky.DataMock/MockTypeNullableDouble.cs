namespace BrightSky.DataMock;

public record MockTypeNullableDouble : 
    IMockType<double?>, 
    IMockTypeMinMax<double?, double, double, MockTypeNullableDouble>,
    IMockTypeRange<double?, double, double, MockTypeNullableDouble>, 
    IMockTypeNullableProbability<double?, MockTypeNullableDouble>
{
    private readonly Random _random = new();
    private double _maxValue = 1000;

    public double? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(double minValue, double maxValue) if you require negative values.");
        
        var weightedValues = new List<WeightedValue<Func<double?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextDouble(MinValue, MaxValue), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<double?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }

    public double MinValue { get; private set; }
    public double MaxValue => _maxValue;

    public MockTypeNullableDouble Min(double minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeNullableDouble Max(double maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public int NullablePercentage { get; private set; } = 50;

    public MockTypeNullableDouble NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        NullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableDouble Range(double minValue, double maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}