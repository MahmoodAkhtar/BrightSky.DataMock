namespace BrightSky.DataMock;

public record MockTypeNullableBool : IMockType<bool?>, IMockTypeTrueProbability<MockTypeNullableBool>, IMockTypeNullableProbability<MockTypeNullableBool>
{
    private readonly Random _random = new();
    private int _nullablePercentage = 50;
    private int _truePercentage = 50;

    public int NullablePercentage => _nullablePercentage;
    
    public MockTypeNullableBool NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }
    
    public int TruePercentage => _truePercentage;
    
    public MockTypeNullableBool TrueProbability(int truePercentage)
    {
        if (truePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(truePercentage), $"{nameof(truePercentage)} {truePercentage} must be a value from 0 to 100.");
        
        _truePercentage = truePercentage;
        return this;
    }
    
    public bool? Get()
    {
        var nullable = _random.NextDouble() <= NullablePercentage / 100.0;
        
        return nullable ? null : _random.NextDouble() <= TruePercentage / 100.0;
    }
}