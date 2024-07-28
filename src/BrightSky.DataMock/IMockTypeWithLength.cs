namespace BrightSky.DataMock;

public interface IMockTypeWithLength<T, TLength, out TMockType> where TMockType : IMockType<T>
{
    TLength Length { get; }
    TMockType WithLength(TLength length);
}