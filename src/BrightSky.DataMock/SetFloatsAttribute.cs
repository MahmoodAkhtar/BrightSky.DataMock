namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetFloatsAttribute : SetTypeAttribute<float>
{
    private readonly MockTypeFloat _mt;

    public SetFloatsAttribute(float fix) => _mt = new MockTypeFloat().Range(fix, fix);
    public SetFloatsAttribute(float min, float max) => _mt = new MockTypeFloat().Range(min, max);

    public override IMockType<float> GetMockType() => _mt;
}