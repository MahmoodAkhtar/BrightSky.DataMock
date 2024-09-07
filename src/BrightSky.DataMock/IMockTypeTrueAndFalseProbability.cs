namespace BrightSky.DataMock;

public interface IMockTypeTrueAndFalseProbability<out TMockType>
{
    Percentage TruePercentage { get; }
    TMockType TrueProbability(Percentage truePercentage);
    Percentage FalsePercentage { get; }
    TMockType FalseProbability(Percentage falsePercentage);
}