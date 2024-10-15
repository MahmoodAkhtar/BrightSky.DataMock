namespace BrightSky.DataMock;

public class MockTypeListOfNullableFloat : 
    IMockType<List<float?>>, 
    IMockTypeMinMax<List<float?>, float, float, MockTypeListOfNullableFloat>, 
    IMockTypeRange<List<float?>, float, float, MockTypeListOfNullableFloat>, 
    IMockTypeNullableProbability<List<float?>, MockTypeListOfNullableFloat>
{
    public List<float?> Get()
        => Dm.NullableFloats()
            .NullableProbability(NullablePercentage)
            .Min(MinValue)
            .Max(MaxValue)
            .ToList(100);

    public float MinValue { get; private set; } = float.MinValue;
    public float MaxValue { get; private set; } = float.MaxValue;

    public MockTypeListOfNullableFloat Min(float minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfNullableFloat Max(float maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfNullableFloat Range(float minValue, float maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeListOfNullableFloat NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
}