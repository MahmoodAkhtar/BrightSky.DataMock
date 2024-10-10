namespace BrightSky.DataMock;

public class MockTypeListOfNullableByte : 
    IMockType<List<byte?>>, 
    IMockTypeMinMax<List<byte?>, byte, byte, MockTypeListOfNullableByte>, 
    IMockTypeRange<List<byte?>, byte, byte, MockTypeListOfNullableByte>, 
    IMockTypeNullableProbability<List<byte?>, MockTypeListOfNullableByte>
{
    public List<byte?> Get()
        => Dm.NullableBytes()
            .NullableProbability(NullablePercentage)
            .Min(MinValue)
            .Max(MaxValue)
            .ToList(100);

    public byte MinValue { get; private set; } = byte.MinValue;
    public byte MaxValue { get; private set; } = byte.MaxValue;

    public MockTypeListOfNullableByte Min(byte minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfNullableByte Max(byte maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfNullableByte Range(byte minValue, byte maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeListOfNullableByte NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
}