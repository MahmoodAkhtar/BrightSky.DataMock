namespace BrightSky.DataMock;

public class SetGuidsAttribute: SetTypeAttribute<Guid>
{
    private readonly MockTypeGuid _mt;
    
    // TODO: Thinking to impl. a Decorator Pattern for this ???
    public Guid Fix { get; }
    public bool IsFixed { get; }

    public SetGuidsAttribute(Guid fix)
    {
        Fix = fix;
        IsFixed = true;
        _mt = new MockTypeGuid(); // TODO: This is what will be wrapped by the Decorator ???
    }

    public SetGuidsAttribute(int nonEmptyPercentage, int emptyPercentage)
    {
        _mt = new MockTypeGuid().NonEmptyProbability(nonEmptyPercentage).EmptyProbability(emptyPercentage);
    }

    public override IMockType<Guid> GetMockType() => _mt;
}

