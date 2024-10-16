namespace BrightSky.DataMock;

public class MockTypeListOfDecimal : IMockType<List<decimal>>, 
    IMockTypeMinMax<List<decimal>, decimal, decimal, MockTypeListOfDecimal>, 
    IMockTypeRange<List<decimal>, decimal, decimal, MockTypeListOfDecimal>
{
    public List<decimal> Get()
        => Dm.Decimals().Min(MinValue).Max(MaxValue).ToList(100);

    public decimal MinValue { get; private set; } = decimal.MinValue;
    public decimal MaxValue { get; private set; } = decimal.MaxValue;
    
    public MockTypeListOfDecimal Min(decimal minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfDecimal Max(decimal maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfDecimal Range(decimal minValue, decimal maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}