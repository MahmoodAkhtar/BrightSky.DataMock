namespace BrightSky.DataMock;

public class MockTypeListOfNullableDecimal : 
    IMockType<List<decimal?>>, 
    IMockTypeMinMax<List<decimal?>, decimal, decimal, MockTypeListOfNullableDecimal>, 
    IMockTypeRange<List<decimal?>, decimal, decimal, MockTypeListOfNullableDecimal>, 
    IMockTypeNullableProbability<List<decimal?>, MockTypeListOfNullableDecimal>
{
    public List<decimal?> Get()
        => Dm.NullableDecimals()
            .NullableProbability(NullablePercentage)
            .Min(MinValue)
            .Max(MaxValue)
            .ToList(100);

    public decimal MinValue { get; private set; } = decimal.MinValue;
    public decimal MaxValue { get; private set; } = decimal.MaxValue;

    public MockTypeListOfNullableDecimal Min(decimal minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfNullableDecimal Max(decimal maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfNullableDecimal Range(decimal minValue, decimal maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeListOfNullableDecimal NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
}