namespace BrightSky.DataMock;

public class MockTypeListOfLong : IMockType<List<long>>, 
    IMockTypeMinMax<List<long>, long, long, MockTypeListOfLong>, 
    IMockTypeRange<List<long>, long, long, MockTypeListOfLong>
{
    public List<long> Get()
        => Dm.Longs().Min(MinValue).Max(MaxValue).ToList(100);

    public long MinValue { get; private set; } = long.MinValue;
    public long MaxValue { get; private set; } = long.MaxValue;
    
    public MockTypeListOfLong Min(long minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfLong Max(long maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfLong Range(long minValue, long maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}