namespace BrightSky.DataMock;

public class SetListOfShortsAttribute : SetTypeAttribute<List<short>>
{
    private readonly IMockType<List<short>> _mt;

    public SetListOfShortsAttribute(short fix)
        => _mt = new MockTypeListOfShort().Min(fix).Max(fix);

    public SetListOfShortsAttribute(short min, short max)
        => _mt = new MockTypeListOfShort().Range(min, max);

    public override IMockType<List<short>> GetMockType() => _mt;
}