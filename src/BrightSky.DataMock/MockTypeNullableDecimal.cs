namespace BrightSky.DataMock;

public record MockTypeNullableDecimal : 
    IMockType<decimal?>, 
    IMockTypeMinMax<decimal?, decimal, decimal, MockTypeNullableDecimal>,
    IMockTypeRange<decimal?, decimal, decimal, MockTypeNullableDecimal>, 
    IMockTypeNullableProbability<decimal?, MockTypeNullableDecimal>
{
    private readonly Random _random = new();
    private decimal _maxValue = 1000;
    private decimal _minValue;
    private int _nullablePercentage = 50;

    public decimal? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(decimal minValue, decimal maxValue) if you require negative values.");
        
        var weightedValues = new List<WeightedValue<Func<decimal?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextDecimal(MinValue, MaxValue), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<decimal?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }

    public decimal MinValue => _minValue;
    public decimal MaxValue => _maxValue;

    public MockTypeNullableDecimal Min(decimal minValue)
    {
        _minValue = minValue;
        return this;
    }

    public MockTypeNullableDecimal Max(decimal maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public int NullablePercentage => _nullablePercentage;

    public MockTypeNullableDecimal NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableDecimal Range(decimal minValue, decimal maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}