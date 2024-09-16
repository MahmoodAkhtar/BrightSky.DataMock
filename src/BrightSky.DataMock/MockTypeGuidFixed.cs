namespace BrightSky.DataMock;

internal record MockTypeGuidFixed : IMockType<Guid>
{
    private readonly Guid _fix;
    
    public MockTypeGuidFixed(Guid fix) => _fix = fix;

    private readonly Random _random = new();

    public Percentage NonEmptyPercentage { get; private set; } = (Percentage)50;
    public Percentage EmptyPercentage { get; private set; } = (Percentage)50;
    
    public MockTypeGuidFixed NonEmptyProbability(Percentage nonEmptyPercentage)
    {
        EmptyPercentage = (Percentage)(Percentage.MaxValue - nonEmptyPercentage);
        NonEmptyPercentage = nonEmptyPercentage;
        return this;        
    }

    public MockTypeGuidFixed EmptyProbability(Percentage emptyPercentage)
    {
        NonEmptyPercentage = (Percentage)(Percentage.MaxValue - emptyPercentage);
        EmptyPercentage = emptyPercentage;
        return this;
    }
    
    public Guid Get() => _random.NextDouble() <= NonEmptyPercentage/100.0 ? _fix : Guid.Empty;
}