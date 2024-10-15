namespace BrightSky.DataMock;

public class MockTypeListOfFloat : IMockType<List<float>>, 
    IMockTypeMinMax<List<float>, float, float, MockTypeListOfFloat>, 
    IMockTypeRange<List<float>, float, float, MockTypeListOfFloat>
{
    public List<float> Get()
        => Dm.Floats().Min(MinValue).Max(MaxValue).ToList(100);

    public float MinValue { get; private set; } = float.MinValue;
    public float MaxValue { get; private set; } = float.MaxValue;
    
    public MockTypeListOfFloat Min(float minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfFloat Max(float maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfFloat Range(float minValue, float maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}