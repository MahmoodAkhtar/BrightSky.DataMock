namespace BrightSky.DataMock;

public interface IMockTypeRange<T, TMin, TMax, out TMockType> where TMockType : IMockType<T>
{
    TMin MinValue { get; }
    TMax MaxValue { get; }
    TMockType Min(TMin minValue);
    TMockType Max(TMax maxValue);
    TMockType Range(TMin minValue, TMax maxValue);
}