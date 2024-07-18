namespace BrightSky.DataMock;

public interface IMockTypeNullableProbability<T, out TMockType> 
    where T : struct
    where TMockType : IMockType<T?>
{
    int NullablePercentage { get; }
    TMockType NullableProbability(int nullablePercentage);
}