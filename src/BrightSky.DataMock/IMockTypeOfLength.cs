namespace BrightSky.DataMock;

public interface IMockTypeOfLength<T, TLength, out TMockType> where TMockType : IMockType<T>
{
    TLength Length { get; }
    TMockType OfLength(TLength length);
}