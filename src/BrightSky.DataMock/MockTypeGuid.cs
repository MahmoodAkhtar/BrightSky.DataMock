namespace BrightSky.DataMock;

public class MockTypeGuid : IMockType<Guid>
{
    public Guid Get() => Guid.NewGuid();
}