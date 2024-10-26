namespace BrightSky.DataMock;

public record MockTypeListOfGuid : 
    IMockType<List<Guid>>,
    IMockTypeEmptyNonEmptyProbability<List<Guid>, MockTypeListOfGuid>
{
    private readonly Guid? _fix;

    public MockTypeListOfGuid()
    {
    }

    public MockTypeListOfGuid(Guid fix) => _fix = fix;
    
    public Percentage NonEmptyPercentage { get; private set; } = (Percentage)50;
    public Percentage EmptyPercentage { get; private set; } = (Percentage)50;
    
    public MockTypeListOfGuid NonEmptyProbability(Percentage nonEmptyPercentage)
    {
        EmptyPercentage = (Percentage)(Percentage.MaxValue - nonEmptyPercentage);
        NonEmptyPercentage = nonEmptyPercentage;
        return this;        
    }

    public MockTypeListOfGuid EmptyProbability(Percentage emptyPercentage)
    {
        NonEmptyPercentage = (Percentage)(Percentage.MaxValue - emptyPercentage);
        EmptyPercentage = emptyPercentage;
        return this;
    }

    public List<Guid> Get()
        => _fix.HasValue 
            ? new MockTypeGuidFixed(_fix.Value)
                .NonEmptyProbability(Percentage.MaxValue)
                .ToList() 
            : Dm.Guids()
                .NonEmptyProbability(NonEmptyPercentage)
                .EmptyProbability(EmptyPercentage)
                .ToList(100);
}