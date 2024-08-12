namespace BrightSky.DataMock;

public record MockTypeLong : 
    IMockType<long>, 
    IMockTypeMinMax<long, long, long, MockTypeLong>, 
    IMockTypeRange<long, long, long, MockTypeLong>
{
    private readonly Random _random = new();
    private long _minValue;
    private long _maxValue = 1000;

    public long Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(int minValue, int maxValue) if you require negative values.");
        
        return _random.NextInt64(MinValue, MaxValue);
    }

    public long MinValue => _minValue;
    public long MaxValue => _maxValue;

    public MockTypeLong Min(long minValue)
    {
        _minValue = minValue;
        return this;
    }
    
    public MockTypeLong Max(long maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public MockTypeLong Range(long minValue, long maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}