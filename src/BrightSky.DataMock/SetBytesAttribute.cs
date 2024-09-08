namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetBytesAttribute : SetTypeAttribute<byte>
{
    private readonly MockTypeByte _mt;

    public SetBytesAttribute(byte fix) => _mt = new MockTypeByte().Range(fix, fix);
    public SetBytesAttribute(byte min, byte max) => _mt = new MockTypeByte().Range(min, max);

    public override IMockType<byte> GetMockType() => _mt;
}