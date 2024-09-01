namespace BrightSky.DataMock;

public record MockTypeNullableByte : 
    IMockType<byte?>, 
    IMockTypeMinMax<byte?, byte, byte, MockTypeNullableByte>, 
    IMockTypeRange<byte?, byte, byte, MockTypeNullableByte>, 
    IMockTypeNullableProbability<byte?, MockTypeNullableByte>
{
    private readonly Random _random = new();

    public byte? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(byte minValue, byte maxValue) if you require negative values.");
        
        var weightedValues = new List<WeightedValue<Func<byte?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextByte(MinValue, MaxValue), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<byte?>>(weightedValues);
        var chosen = weighted.Next();
        
        return chosen();
    }

    public byte MinValue { get; private set; } = byte.MinValue;
    public byte MaxValue { get; private set; } = byte.MaxValue;

    public MockTypeNullableByte Min(byte minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeNullableByte Max(byte maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public int NullablePercentage { get; private set; } = 50;

    public MockTypeNullableByte NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        NullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableByte Range(byte minValue, byte maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}