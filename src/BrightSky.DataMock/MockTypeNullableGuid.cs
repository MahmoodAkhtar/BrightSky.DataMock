namespace BrightSky.DataMock;

public class MockTypeNullableGuid : 
    IMockType<Guid?>,
    IMockTypeNullableProbability<Guid?, MockTypeNullableGuid>
{
    public Guid? Get()
    {
        var chosen = new List<WeightedValue<Func<Guid?>>>
        {
            new(() => null, NullablePercentage),
            new(() => Guid.NewGuid(), 100 - NullablePercentage),
        }.Next();
        
        return chosen();
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeNullableGuid NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
}