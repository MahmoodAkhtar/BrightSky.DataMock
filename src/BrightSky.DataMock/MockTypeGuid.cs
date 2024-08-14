namespace BrightSky.DataMock;

public record MockTypeGuid : IMockType<Guid>
{
    public Guid Get() => Guid.NewGuid();
}