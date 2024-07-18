namespace BrightSky.DataMock;

public interface IMockTypeTrueProbability<out TMockType>
{
    int TruePercentage { get; }
    TMockType TrueProbability(int truePercentage);
    int FalsePercentage { get; }
    TMockType FalseProbability(int falsePercentage);
}