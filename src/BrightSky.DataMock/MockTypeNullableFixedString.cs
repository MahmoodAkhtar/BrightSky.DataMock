namespace BrightSky.DataMock;

internal record MockTypeNullableFixedString : 
    IMockType<string?>,
    IMockTypeNullableProbability<string?, IMockType<string?>>
{
    private readonly string? _fix;

    public MockTypeNullableFixedString(string fix) => _fix = fix;

    public string? Get()
    {
        var chosen = new List<WeightedValue<Func<string?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _fix, Percentage.MaxValue - NullablePercentage),
        }.Next();
        
        return chosen();
    }    
    public Percentage NullablePercentage { get; private set; } = (Percentage)50;
    
    public IMockType<string?> NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
}