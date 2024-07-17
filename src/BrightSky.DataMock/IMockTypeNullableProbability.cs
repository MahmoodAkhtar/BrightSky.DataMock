namespace BrightSky.DataMock;

public interface IMockTypeNullableProbability<out TMockType>
{
    int NullablePercentage { get; }
    TMockType NullableProbability(int nullablePercentage);
}