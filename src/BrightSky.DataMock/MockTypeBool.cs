namespace BrightSky.DataMock;

public record MockTypeBool : IMockType<bool>, IMockTypeTrueAndFalseProbability<MockTypeBool>
{
    private readonly Random _random = new();

    public int TruePercentage { get; private set; } = 50;
    public int FalsePercentage { get; private set; } = 50;

    public MockTypeBool TrueProbability(int truePercentage)
    {
        (TruePercentage, FalsePercentage) = CalculatePercentages(nameof(truePercentage), truePercentage);
        return this;
    }
    
    public MockTypeBool FalseProbability(int falsePercentage)
    {
        (FalsePercentage, TruePercentage) = CalculatePercentages(nameof(falsePercentage), falsePercentage);
        return this;
    }
    
    private static (int FirstPrecentage, int SecondPrecentage) CalculatePercentages(string paramName, int percentage)
    {
        if (percentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(paramName, $"{paramName} {percentage} must be a value from 0 to 100.");

        return (percentage, 100 - percentage);
    }
    
    public bool Get() => _random.NextDouble() <= TruePercentage/100.0;
}