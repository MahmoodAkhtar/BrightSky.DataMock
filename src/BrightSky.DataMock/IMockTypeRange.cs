namespace BrightSky.DataMock;

public interface IMockTypeRange<T, in TMin, in TMax, out TMockType> where TMockType : IMockType<T>
{
    TMockType Range(TMin minValue, TMax maxValue);
}