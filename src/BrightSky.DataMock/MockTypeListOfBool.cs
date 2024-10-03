namespace BrightSky.DataMock;

public class MockTypeListOfBool : IMockType<List<bool>>, IMockTypeTrueAndFalseProbability<MockTypeListOfBool>
{
    public Percentage TruePercentage { get; private set; } = (Percentage)50;
    public Percentage FalsePercentage { get; private set; } = (Percentage)50;
    
    public List<bool> Get()
        => Dm.Bools().TrueProbability(TruePercentage).FalseProbability(FalsePercentage).ToList(100);

    public MockTypeListOfBool TrueProbability(Percentage truePercentage)
    {
        TruePercentage = truePercentage;
        FalsePercentage = (Percentage)(Percentage.MaxValue - truePercentage);
        return this;
    }

    public MockTypeListOfBool FalseProbability(Percentage falsePercentage)
    {
        FalsePercentage = falsePercentage;
        TruePercentage = (Percentage)(Percentage.MaxValue - falsePercentage);
        return this;
    }
}