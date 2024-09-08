namespace BrightSky.DataMock;

public class SetGuidsAttribute: SetTypeAttribute<Guid>
{
    private readonly IMockType<Guid> _mt;

    public SetGuidsAttribute(string fix) => _mt = new MockTypeGuidFixed(Guid.Parse(fix));

    public SetGuidsAttribute(int nonEmptyPercentage, int emptyPercentage)
        => _mt = new MockTypeGuid().NonEmptyProbability((Percentage)nonEmptyPercentage).EmptyProbability((Percentage)emptyPercentage);

    public override IMockType<Guid> GetMockType() => _mt;
}