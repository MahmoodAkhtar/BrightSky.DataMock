namespace BrightSky.DataMock;

public class MockTypeListOfNullableShort : 
    IMockType<List<short?>>, 
    IMockTypeMinMax<List<short?>, short, short, MockTypeListOfNullableShort>, 
    IMockTypeRange<List<short?>, short, short, MockTypeListOfNullableShort>, 
    IMockTypeNullableProbability<List<short?>, MockTypeListOfNullableShort>
{
    public List<short?> Get()
        => Dm.NullableShorts()
            .NullableProbability(NullablePercentage)
            .Min(MinValue)
            .Max(MaxValue)
            .ToList(100);

    public short MinValue { get; private set; } = short.MinValue;
    public short MaxValue { get; private set; } = short.MaxValue;

    public MockTypeListOfNullableShort Min(short minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfNullableShort Max(short maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfNullableShort Range(short minValue, short maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeListOfNullableShort NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
}