namespace BrightSky.DataMock;

public record MockTypeInt : 
    IMockType<int>, 
    IMockTypeMinMax<int, int, int, MockTypeInt>,
    IMockTypeRange<int, int, int, MockTypeInt>
{
    private readonly Random _random = new();
    private int _minValue;
    private int _maxValue = 1000;

    public int Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(int minValue, int maxValue) if you require negative values.");
        
        return _random.Next(MinValue, MaxValue);
    }

    public int MinValue => _minValue;
    public int MaxValue => _maxValue;

    public MockTypeInt Min(int minValue)
    {
        _minValue = minValue;
        return this;
    }
    
    public MockTypeInt Max(int maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public MockTypeInt Range(int minValue, int maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}