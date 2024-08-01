namespace BrightSky.DataMock;

public interface IMockTypeIncrement<in T, out TMockType> where TMockType : IMockType<T>
{
    TMockType Increment(T increment);
}