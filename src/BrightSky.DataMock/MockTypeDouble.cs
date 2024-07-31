namespace BrightSky.DataMock;

public record MockTypeDouble : 
    IMockType<double>, 
    IMockTypeMinMax<double, double, double, MockTypeDouble>, 
    IMockTypeRange<double, double, double, MockTypeDouble>
{
    private readonly Random _random = new();
    private double _minValue;
    private double _maxValue = 1000;

    public double Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(double minValue, double maxValue) if you require negative values.");

        return _random.NextDouble(MinValue, MaxValue);
    }

    public double MinValue => _minValue;
    public double MaxValue => _maxValue;

    public MockTypeDouble Min(double minValue)
    {
        _minValue = minValue;
        return this;
    }
    
    public MockTypeDouble Max(double maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public MockTypeDouble Range(double minValue, double maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}