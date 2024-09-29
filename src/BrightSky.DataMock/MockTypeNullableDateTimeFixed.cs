namespace BrightSky.DataMock;

public class MockTypeNullableDateTimeFixed : IMockType<DateTime?>,
    IMockTypeNullableProbability<DateTime?, MockTypeNullableDateTimeFixed>
{
    private readonly DateTime? _fix;

    public MockTypeNullableDateTimeFixed(DateTime? fix) => _fix = fix;

    public DateTime? Get()
    {
        var chosen = new List<WeightedValue<Func<DateTime?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _fix, Percentage.MaxValue - NullablePercentage),
        }.Next();
        
        return chosen();
    }

    public Percentage NullablePercentage { get; private set; }
    public MockTypeNullableDateTimeFixed NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
}