namespace BrightSky.DataMock;

public record MockTypeShort : 
    IMockType<short>, 
    IMockTypeMinMax<short, short, short, MockTypeShort>, 
    IMockTypeRange<short, short, short, MockTypeShort>
{
    private readonly Random _random = new();
    private short _minValue;
    private short _maxValue = 1000;

    public short Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(short minValue, short maxValue) if you require negative values.");
        
        return _random.NextShort(MinValue, MaxValue);
    }

    public short MinValue => _minValue;
    public short MaxValue => _maxValue;

    public MockTypeShort Min(short minValue)
    {
        _minValue = minValue;
        return this;
    }
    
    public MockTypeShort Max(short maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public MockTypeShort Range(short minValue, short maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}