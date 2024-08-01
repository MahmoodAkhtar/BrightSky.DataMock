namespace BrightSky.DataMock;

public interface IMockTypeOrdering<T, out TMockType> where TMockType : IMockType<T>
{
    TMockType Ascending();
    TMockType Descending();
}