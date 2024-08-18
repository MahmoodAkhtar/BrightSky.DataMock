namespace BrightSky.DataMock;

public record MockTypeFloat : 
    IMockType<float>, 
    IMockTypeMinMax<float, float, float, MockTypeFloat>, 
    IMockTypeRange<float, float, float, MockTypeFloat>
{
    private readonly Random _random = new();

    public float Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(float minValue, float maxValue) if you require negative values.");

        return _random.NextFloat(MinValue, MaxValue);
    }

    public float MinValue { get; private set; }
    public float MaxValue { get; private set; } = 1000;

    public MockTypeFloat Min(float minValue)
    {
        MinValue = minValue;
        return this;
    }
    
    public MockTypeFloat Max(float maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeFloat Range(float minValue, float maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}