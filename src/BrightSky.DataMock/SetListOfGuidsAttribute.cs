namespace BrightSky.DataMock;

public class SetListOfGuidsAttribute : SetTypeAttribute<List<Guid>>
{
    private readonly IMockType<List<Guid>> _mt;

    public SetListOfGuidsAttribute(string fix) 
        => _mt = new MockTypeListOfGuid(Guid.Parse(fix))
            .NonEmptyProbability(Percentage.MaxValue);

    public SetListOfGuidsAttribute(int nonEmptyPercentage, int emptyPercentage)
        => _mt = new MockTypeListOfGuid()
            .NonEmptyProbability((Percentage)nonEmptyPercentage)
            .EmptyProbability((Percentage)emptyPercentage);

    public SetListOfGuidsAttribute(string fix, int fixPercentage, int emptyPercentage)
        => _mt = new MockTypeListOfGuid(Guid.Parse(fix))
            .NonEmptyProbability((Percentage)fixPercentage)
            .EmptyProbability((Percentage)emptyPercentage);
    
    public override IMockType<List<Guid>> GetMockType() => _mt;
}