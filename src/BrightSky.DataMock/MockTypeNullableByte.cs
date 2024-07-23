namespace BrightSky.DataMock;

public record MockTypeNullableByte : IMockType<byte?>, IMockTypeRange<byte?, byte, byte, MockTypeNullableByte>, IMockTypeNullableProbability<byte, MockTypeNullableByte>
{
    private readonly Random _random = new();
    private byte _minValue;
    private byte _maxValue = 255;
    private int _nullablePercentage = 50;

    public int NullablePercentage => _nullablePercentage;
    
    public MockTypeNullableByte NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }

    public byte? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(byte minValue, byte maxValue) if you require negative values.");
        
        var weightedValues = new List<WeightedValue<Func<byte?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextByte(MinValue, MaxValue), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<byte?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }

    public byte MinValue => _minValue;
    public byte MaxValue => _maxValue;

    public MockTypeNullableByte Min(byte minValue)
    {
        _minValue = minValue;
        return this;
    }
    
    public MockTypeNullableByte Max(byte maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public MockTypeNullableByte Range(byte minValue, byte maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}