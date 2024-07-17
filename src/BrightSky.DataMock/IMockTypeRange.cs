namespace BrightSky.DataMock;

public interface IMockTypeRange<TMin, TMax, out TMockType>
{
    TMin MinValue { get; }
    TMax MaxValue { get; }
    TMockType Min(TMin minValue);
    TMockType Max(TMax maxValue);
    TMockType Range(TMin minValue, TMax maxValue);
}