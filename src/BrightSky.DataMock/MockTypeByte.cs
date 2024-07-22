namespace BrightSky.DataMock;

public record MockTypeByte : IMockType<byte>, IMockTypeRange<byte, byte, byte, MockTypeByte>
{
    private readonly Random _random = new();
    private byte _minValue;
    private byte _maxValue = 255;

    public byte Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(byte minValue, byte maxValue) if you require negative values.");
        
        return _random.NextByte(MinValue, MaxValue);
    }

    public byte MinValue => _minValue;
    public byte MaxValue => _maxValue;

    public MockTypeByte Min(byte minValue)
    {
        _minValue = minValue;
        return this;
    }
    
    public MockTypeByte Max(byte maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public MockTypeByte Range(byte minValue, byte maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}