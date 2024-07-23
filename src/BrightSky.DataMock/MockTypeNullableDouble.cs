namespace BrightSky.DataMock;

public record MockTypeNullableDouble : IMockType<double?>, IMockTypeRange<double?, double, double, MockTypeNullableDouble>, IMockTypeNullableProbability<double, MockTypeNullableDouble>
{
    private readonly Random _random = new();
    private double _minValue;
    private double _maxValue = 1000;
    private int _nullablePercentage = 50;

    public int NullablePercentage => _nullablePercentage;
    
    public MockTypeNullableDouble NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }

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

    public double MinValue => _minValue;
    public double MaxValue => _maxValue;

    public MockTypeNullableDouble Min(double minValue)
    {
        _minValue = minValue;
        return this;
    }
    
    public MockTypeNullableDouble Max(double maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public MockTypeNullableDouble Range(double minValue, double maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}