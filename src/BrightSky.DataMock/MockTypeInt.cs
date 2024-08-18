namespace BrightSky.DataMock;

public record MockTypeInt : 
    IMockType<int>, 
    IMockTypeMinMax<int, int, int, MockTypeInt>,
    IMockTypeRange<int, int, int, MockTypeInt>
{
    private readonly Random _random = new();

    public int Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(int minValue, int maxValue) if you require negative values.");
        
        return _random.Next(MinValue, MaxValue);
    }

    public int MinValue { get; private set; }
    public int MaxValue { get; private set; } = 1000;

    public MockTypeInt Min(int minValue)
    {
        MinValue = minValue;
        return this;
    }
    
    public MockTypeInt Max(int maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeInt Range(int minValue, int maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}