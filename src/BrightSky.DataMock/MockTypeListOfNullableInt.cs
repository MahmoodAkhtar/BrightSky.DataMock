namespace BrightSky.DataMock;

public class MockTypeListOfNullableInt : 
    IMockType<List<int?>>, 
    IMockTypeMinMax<List<int?>, int, int, MockTypeListOfNullableInt>, 
    IMockTypeRange<List<int?>, int, int, MockTypeListOfNullableInt>, 
    IMockTypeNullableProbability<List<int?>, MockTypeListOfNullableInt>
{
    private readonly Random _random = new();
    
    public List<int?> Get()
        => Dm.NullableInts()
            .NullableProbability(NullablePercentage)
            .Min(MinValue)
            .Max(MaxValue)
            .ToList(100);

    public int MinValue { get; private set; } = int.MinValue;
    public int MaxValue { get; private set; } = int.MaxValue;

    public MockTypeListOfNullableInt Min(int minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfNullableInt Max(int maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfNullableInt Range(int minValue, int maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeListOfNullableInt NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
}