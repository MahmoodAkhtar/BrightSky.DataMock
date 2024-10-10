namespace BrightSky.DataMock;

public class MockTypeListOfByte : IMockType<List<byte>>, 
    IMockTypeMinMax<List<byte>, byte, byte, MockTypeListOfByte>, 
    IMockTypeRange<List<byte>, byte, byte, MockTypeListOfByte>
{
    public List<byte> Get()
        => Dm.Bytes().Min(MinValue).Max(MaxValue).ToList(100);

    public byte MinValue { get; private set; } = byte.MinValue;
    public byte MaxValue { get; private set; } = byte.MaxValue;
    public MockTypeListOfByte Min(byte minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfByte Max(byte maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfByte Range(byte minValue, byte maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}