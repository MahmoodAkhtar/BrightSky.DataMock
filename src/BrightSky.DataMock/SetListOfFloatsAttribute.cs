namespace BrightSky.DataMock;

public class SetListOfFloatsAttribute : SetTypeAttribute<List<float>>
{
    private readonly IMockType<List<float>> _mt;

    public SetListOfFloatsAttribute(float fix)
        => _mt = new MockTypeListOfFloat().Min(fix).Max(fix);

    public SetListOfFloatsAttribute(float min, float max)
        => _mt = new MockTypeListOfFloat().Range(min, max);

    public override IMockType<List<float>> GetMockType() => _mt;
}