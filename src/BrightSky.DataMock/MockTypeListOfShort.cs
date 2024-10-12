namespace BrightSky.DataMock;

public class MockTypeListOfShort : IMockType<List<short>>, 
    IMockTypeMinMax<List<short>, short, short, MockTypeListOfShort>, 
    IMockTypeRange<List<short>, short, short, MockTypeListOfShort>
{
    public List<short> Get()
        => Dm.Shorts().Min(MinValue).Max(MaxValue).ToList(100);

    public short MinValue { get; private set; } = short.MinValue;
    public short MaxValue { get; private set; } = short.MaxValue;
    
    public MockTypeListOfShort Min(short minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfShort Max(short maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfShort Range(short minValue, short maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}