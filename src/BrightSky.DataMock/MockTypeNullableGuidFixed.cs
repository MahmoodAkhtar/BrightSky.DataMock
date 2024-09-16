namespace BrightSky.DataMock;

internal record MockTypeNullableGuidFixed : 
    IMockType<Guid?>,
    IMockTypeNullableProbability<Guid?, MockTypeNullableGuidFixed>
{
    private readonly Guid? _fix;
    
    public MockTypeNullableGuidFixed(Guid fix) => _fix = fix;

    public Guid? Get()
    {
        var chosen = new List<WeightedValue<Func<Guid?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _fix, 100 - NullablePercentage),
        }.Next();
        
        return chosen();
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeNullableGuidFixed NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
}