namespace BrightSky.DataMock;

public class MockTypeListOfNullableDouble : 
    IMockType<List<double?>>, 
    IMockTypeMinMax<List<double?>, double, double, MockTypeListOfNullableDouble>, 
    IMockTypeRange<List<double?>, double, double, MockTypeListOfNullableDouble>, 
    IMockTypeNullableProbability<List<double?>, MockTypeListOfNullableDouble>
{
    public List<double?> Get()
        => Dm.NullableDoubles()
            .NullableProbability(NullablePercentage)
            .Min(MinValue)
            .Max(MaxValue)
            .ToList(100);

    public double MinValue { get; private set; } = double.MinValue;
    public double MaxValue { get; private set; } = double.MaxValue;

    public MockTypeListOfNullableDouble Min(double minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeListOfNullableDouble Max(double maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public MockTypeListOfNullableDouble Range(double minValue, double maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeListOfNullableDouble NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
}