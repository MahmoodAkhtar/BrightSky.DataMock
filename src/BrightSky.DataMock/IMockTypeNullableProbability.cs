namespace BrightSky.DataMock;

public interface IMockTypeNullableProbability<T, out TMockType> 
    where TMockType : IMockType<T?>
{
    int NullablePercentage { get; }
    TMockType NullableProbability(int nullablePercentage);
}