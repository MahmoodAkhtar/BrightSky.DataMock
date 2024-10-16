namespace BrightSky.DataMock;

public class MockTypeListOfDouble : IMockType<List<double>>, 
    IMockTypeMinMax<List<double>, double, double, MockTypeListOfDouble>, 
    IMockTypeRange<List<double>, double, double, MockTypeListOfDouble>
{
    public List<double> Get()
        => Dm.Doubles().Min(MinValue).Max(MaxValue).ToList(100);

    public double MinValue { get; private set; } = double.MinValue;
    public double MaxValue { get; private set; } = double.MaxValue;
    
    public MockTypeListOfDouble Min(double minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfDouble Max(double maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfDouble Range(double minValue, double maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}