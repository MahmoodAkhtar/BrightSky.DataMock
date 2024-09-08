namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetIntsAttribute : SetTypeAttribute<int>
{
    private readonly MockTypeInt _mt;

    public SetIntsAttribute(int fix) => _mt = new MockTypeInt().Range(fix, fix);
    public SetIntsAttribute(int min, int max) => _mt = new MockTypeInt().Range(min, max);

    public override IMockType<int> GetMockType() => _mt;
}