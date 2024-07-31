namespace BrightSky.DataMock;

public interface IMockTypeMinMax<T, TMin, TMax, out TMockType> where TMockType : IMockType<T>
{
    TMin MinValue { get; }
    TMax MaxValue { get; }
    TMockType Min(TMin minValue);
    TMockType Max(TMax maxValue); 
}