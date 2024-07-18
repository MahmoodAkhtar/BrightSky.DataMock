namespace BrightSky.DataMock;

public record MockTypeBool : IMockType<bool>, IMockTypeTrueProbability<MockTypeBool>
{
    private readonly Random _random = new();
    private int _truePercentage = 50;
    private int _falsePercentage = 50;

    public int TruePercentage => _truePercentage;
    public int FalsePercentage => _falsePercentage;
    
    public MockTypeBool TrueProbability(int truePercentage)
    {
        (_truePercentage, _falsePercentage) = CalculatePercentages(nameof(truePercentage), truePercentage);
        return this;
    }
    
    public MockTypeBool FalseProbability(int falsePercentage)
    {
        (_falsePercentage, _truePercentage) = CalculatePercentages(nameof(falsePercentage), falsePercentage);
        return this;
    }
    
    private static (int FirstPrecentage, int SecondPrecentage) CalculatePercentages(string paramName, int percentage)
    {
        if (percentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(paramName, $"{paramName} {percentage} must be a value from 0 to 100.");

        return (percentage, 100 - percentage);
    }
    
    public bool Get()
    {
        return _random.NextDouble() <= TruePercentage/100.0;
    }
}