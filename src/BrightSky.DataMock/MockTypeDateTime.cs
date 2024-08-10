namespace BrightSky.DataMock;

public class MockTypeDateTime: 
    IMockType<DateTime>,
    IMockTypeMinMax<DateTime, DateTime, DateTime, MockTypeDateTime>,
    IMockTypeRange<DateTime, DateTime, DateTime, MockTypeDateTime>
{
    private readonly Random _random = new();
    private long _minValue; // 1st Jan 0001
    private long _maxValue = DateTime.MaxValue.Ticks;
    
    public DateTime Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue}.");

        return new DateTime(_random.NextInt64(_minValue, _maxValue));
    }

    public MockTypeDateTime Range(DateTime minValue, DateTime maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue.Ticks;
        _maxValue = maxValue.Ticks;
        return this;
    }

    public DateTime MinValue => new(_minValue);
    public DateTime MaxValue => new(_maxValue);
    
    public MockTypeDateTime Min(DateTime minValue)
    {
        _minValue = minValue.Ticks;
        return this;
    }

    public MockTypeDateTime Max(DateTime maxValue)
    {
        _maxValue = maxValue.Ticks;
        return this;
    }
}