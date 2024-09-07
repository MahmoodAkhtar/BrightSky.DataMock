namespace BrightSky.DataMock;

public interface IMockTypeNullableProbability<T, out TMockType> 
    where TMockType : IMockType<T?>
{
    Percentage NullablePercentage { get; }
    TMockType NullableProbability(Percentage nullablePercentage);
}