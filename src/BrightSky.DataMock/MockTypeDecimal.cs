namespace BrightSky.DataMock;

public record MockTypeDecimal : 
    IMockType<decimal>, 
    IMockTypeMinMax<decimal, decimal, decimal, MockTypeDecimal>, 
    IMockTypeRange<decimal, decimal, decimal, MockTypeDecimal>
{
    private readonly Random _random = new();
    private decimal _maxValue = 1000;
    private decimal _minValue;

    public decimal Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(decimal minValue, decimal maxValue) if you require negative values.");
        
        return _random.NextDecimal(MinValue, MaxValue);
    }

    public decimal MinValue => _minValue;
    public decimal MaxValue => _maxValue;

    public MockTypeDecimal Min(decimal minValue)
    {
        _minValue = minValue;
        return this;
    }

    public MockTypeDecimal Max(decimal maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public MockTypeDecimal Range(decimal minValue, decimal maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}