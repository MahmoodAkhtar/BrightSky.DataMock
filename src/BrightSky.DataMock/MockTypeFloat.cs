namespace BrightSky.DataMock;

public record MockTypeFloat : 
    IMockType<float>, 
    IMockTypeMinMax<float, float, float, MockTypeFloat>, 
    IMockTypeRange<float, float, float, MockTypeFloat>
{
    private readonly Random _random = new();
    private float _minValue;
    private float _maxValue = 1000;

    public float Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(float minValue, float maxValue) if you require negative values.");

        return _random.NextFloat(MinValue, MaxValue);
    }

    public float MinValue => _minValue;
    public float MaxValue => _maxValue;

    public MockTypeFloat Min(float minValue)
    {
        _minValue = minValue;
        return this;
    }
    
    public MockTypeFloat Max(float maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public MockTypeFloat Range(float minValue, float maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}