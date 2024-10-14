namespace BrightSky.DataMock;

public class MockTypeListOfInt : IMockType<List<int>>, 
    IMockTypeMinMax<List<int>, int, int, MockTypeListOfInt>, 
    IMockTypeRange<List<int>, int, int, MockTypeListOfInt>
{
    public List<int> Get()
        => Dm.Ints().Min(MinValue).Max(MaxValue).ToList(100);

    public int MinValue { get; private set; } = int.MinValue;
    public int MaxValue { get; private set; } = int.MaxValue;
    
    public MockTypeListOfInt Min(int minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfInt Max(int maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfInt Range(int minValue, int maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}