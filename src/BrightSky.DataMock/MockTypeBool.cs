namespace BrightSky.DataMock;

public record MockTypeBool : IMockType<bool>, IMockTypeProbability<MockTypeBool>
{
    private readonly Random _random = new();
    private int _percentage = 50;

    public int Percentage => _percentage;
    
    public MockTypeBool Probability(int percentage)
    {
        if (percentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(percentage), $"{nameof(percentage)} {percentage} must be a value from 0 to 100.");
        
        _percentage = percentage;
        return this;
    }
    
    public bool Get()
    {
        return _random.NextDouble() <= Percentage/100.0;
    }
}