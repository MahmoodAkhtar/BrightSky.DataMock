namespace BrightSky.DataMock;

public interface IMockTypeTrueAndFalseProbability<out TMockType>
{
    int TruePercentage { get; }
    TMockType TrueProbability(int truePercentage);
    int FalsePercentage { get; }
    TMockType FalseProbability(int falsePercentage);
}