namespace BrightSky.DataMock;

internal record MockTypeGuidFixed : IMockType<Guid>
{
    private readonly Guid _fix;
    
    public MockTypeGuidFixed(Guid fix) => _fix = fix;

    public Guid Get() => _fix;
}