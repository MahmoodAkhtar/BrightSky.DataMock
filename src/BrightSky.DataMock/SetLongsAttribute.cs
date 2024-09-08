namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetLongsAttribute : SetTypeAttribute<long>
{
    private readonly MockTypeLong _mt;

    public SetLongsAttribute(long fix) => _mt = new MockTypeLong().Range(fix, fix);
    public SetLongsAttribute(long min, long max) => _mt = new MockTypeLong().Range(min, max);

    public override IMockType<long> GetMockType() => _mt;
}