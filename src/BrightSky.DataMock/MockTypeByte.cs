namespace BrightSky.DataMock;

public record MockTypeByte : IMockType<byte>, 
    IMockTypeMinMax<byte, byte, byte, MockTypeByte>, 
    IMockTypeRange<byte, byte, byte, MockTypeByte>
{
    private readonly Random _random = new();

    public byte Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(byte minValue, byte maxValue) if you require negative values.");
        
        return _random.NextByte(MinValue, MaxValue);
    }

    public byte MinValue { get; private set; }
    public byte MaxValue { get; private set; } = 255;

    public MockTypeByte Min(byte minValue)
    {
        MinValue = minValue;
        return this;
    }
    
    public MockTypeByte Max(byte maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeByte Range(byte minValue, byte maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}