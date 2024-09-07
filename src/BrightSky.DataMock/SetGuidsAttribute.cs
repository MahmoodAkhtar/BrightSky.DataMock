namespace BrightSky.DataMock;

public class SetGuidsAttribute: SetTypeAttribute<Guid>
{
    private readonly IMockType<Guid> _mt;

    public SetGuidsAttribute(Guid fix) => _mt = new MockTypeGuidFixed(fix);

    public SetGuidsAttribute(int nonEmptyPercentage, int emptyPercentage)
        => _mt = new MockTypeGuid().NonEmptyProbability(nonEmptyPercentage).EmptyProbability(emptyPercentage);

    public override IMockType<Guid> GetMockType() => _mt;
}