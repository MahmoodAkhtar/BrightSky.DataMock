namespace BrightSky.DataMock;

public interface IMockTypeProbability<out TMockType>
{
    int Percentage { get; }
    TMockType Probability(int percentage);
}