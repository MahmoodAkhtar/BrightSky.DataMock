namespace BrightSky.DataMock;

public record MockTypeGuid : IMockType<Guid>
{
    private readonly Random _random = new();

    public Percentage NonEmptyPercentage { get; private set; } = (Percentage)50;
    public Percentage EmptyPercentage { get; private set; } = (Percentage)50;
    
    public MockTypeGuid NonEmptyProbability(Percentage nonEmptyPercentage)
    {
        EmptyPercentage = (Percentage)(Percentage.MaxValue - nonEmptyPercentage);
        NonEmptyPercentage = nonEmptyPercentage;
        return this;        
    }

    public MockTypeGuid EmptyProbability(Percentage emptyPercentage)
    {
        NonEmptyPercentage = (Percentage)(Percentage.MaxValue - emptyPercentage);
        EmptyPercentage = emptyPercentage;
        return this;
    }
    
    public Guid Get() => _random.NextDouble() <= NonEmptyPercentage/100.0 ? Guid.NewGuid() : Guid.Empty;
}