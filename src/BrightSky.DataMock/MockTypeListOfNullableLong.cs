namespace BrightSky.DataMock;

public class MockTypeListOfNullableLong : 
    IMockType<List<long?>>, 
    IMockTypeMinMax<List<long?>, long, long, MockTypeListOfNullableLong>, 
    IMockTypeRange<List<long?>, long, long, MockTypeListOfNullableLong>, 
    IMockTypeNullableProbability<List<long?>, MockTypeListOfNullableLong>
{
    private readonly Random _random = new();
    
    public List<long?> Get()
        => Dm.NullableLongs()
            .NullableProbability(NullablePercentage)
            .Min(MinValue)
            .Max(MaxValue)
            .ToList(100);

    public long MinValue { get; private set; } = long.MinValue;
    public long MaxValue { get; private set; } = long.MaxValue;

    public MockTypeListOfNullableLong Min(long minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfNullableLong Max(long maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfNullableLong Range(long minValue, long maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeListOfNullableLong NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
}