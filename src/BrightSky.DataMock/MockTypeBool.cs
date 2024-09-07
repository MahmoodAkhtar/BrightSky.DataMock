namespace BrightSky.DataMock;

public record MockTypeBool : IMockType<bool>, IMockTypeTrueAndFalseProbability<MockTypeBool>
{
    private readonly Random _random = new();

    public Percentage TruePercentage { get; private set; } = (Percentage)50;
    public Percentage FalsePercentage { get; private set; } = (Percentage)50;

    public MockTypeBool TrueProbability(Percentage truePercentage)
    {
        TruePercentage = truePercentage;
        FalsePercentage = (Percentage)(Percentage.MaxValue - truePercentage);
        return this;
    }
    
    public MockTypeBool FalseProbability(Percentage falsePercentage)
    {
        FalsePercentage = falsePercentage;
        TruePercentage = (Percentage)(Percentage.MaxValue - falsePercentage);
        return this;
    }
    
    public bool Get() => _random.NextDouble() <= TruePercentage/100.0;
}