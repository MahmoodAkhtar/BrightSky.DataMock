namespace BrightSky.DataMock;

public class SetListOfBytesAttribute : SetTypeAttribute<List<byte>>
{
    private readonly IMockType<List<byte>> _mt;

    public SetListOfBytesAttribute(byte fix)
        => _mt = new MockTypeListOfByte().Min(fix).Max(fix);

    public SetListOfBytesAttribute(byte min, byte max)
        => _mt = new MockTypeListOfByte().Range(min, max);

    public override IMockType<List<byte>> GetMockType() => _mt;
}