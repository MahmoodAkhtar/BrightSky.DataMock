namespace BrightSky.DataMock;

public class SetListOfLongsAttribute : SetTypeAttribute<List<long>>
{
    private readonly IMockType<List<long>> _mt;

    public SetListOfLongsAttribute(long fix)
        => _mt = new MockTypeListOfLong().Min(fix).Max(fix);

    public SetListOfLongsAttribute(long min, long max)
        => _mt = new MockTypeListOfLong().Range(min, max);

    public override IMockType<List<long>> GetMockType() => _mt;
}