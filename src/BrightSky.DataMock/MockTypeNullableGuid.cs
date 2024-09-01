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

    public int NullablePercentage { get; private set; } = 50;

    public MockTypeNullableGuid NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        NullablePercentage = nullablePercentage;
        return this;
    }
}