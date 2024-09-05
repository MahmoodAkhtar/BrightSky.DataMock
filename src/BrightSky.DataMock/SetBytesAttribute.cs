namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetBytesAttribute : SetTypeAttribute<byte>
{
    public byte Fix { get; }
    public bool IsFixed { get; }
    public byte Min { get; } = byte.MinValue;
    public byte Max { get; } = byte.MaxValue;

    public SetBytesAttribute(byte fix) => (Fix, IsFixed) = (fix, true);
    public SetBytesAttribute(byte min, byte max) => (Min, Max) = (min, max);

    public override IMockType<byte> GetMockType()
        => IsFixed ? Dm.Bytes().Range(Fix, Fix) : Dm.Bytes().Range(Min, Max);
}