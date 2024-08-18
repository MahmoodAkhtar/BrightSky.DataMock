namespace BrightSky.DataMock;

public record MockTypeDouble : 
    IMockType<double>, 
    IMockTypeMinMax<double, double, double, MockTypeDouble>, 
    IMockTypeRange<double, double, double, MockTypeDouble>
{
    private readonly Random _random = new();

    public double Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(double minValue, double maxValue) if you require negative values.");

        return _random.NextDouble(MinValue, MaxValue);
    }

    public double MinValue { get; private set; }
    public double MaxValue { get; private set; } = 1000;

    public MockTypeDouble Min(double minValue)
    {
        MinValue = minValue;
        return this;
    }
    
    public MockTypeDouble Max(double maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeDouble Range(double minValue, double maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}