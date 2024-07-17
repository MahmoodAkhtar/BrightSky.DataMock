namespace BrightSky.DataMock;

public record MockTypeBool : IMockType<bool>, IMockTypeTrueProbability<MockTypeBool>
{
    private readonly Random _random = new();
    private int _truePercentage = 50;

    public int TruePercentage => _truePercentage;
    
    public MockTypeBool TrueProbability(int truePercentage)
    {
        if (truePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(truePercentage), $"{nameof(truePercentage)} {truePercentage} must be a value from 0 to 100.");
        
        _truePercentage = truePercentage;
        return this;
    }
    
    public bool Get()
    {
        return _random.NextDouble() <= TruePercentage/100.0;
    }
}