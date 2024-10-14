namespace BrightSky.DataMock;

public class SetListOfIntsAttribute : SetTypeAttribute<List<int>>
{
    private readonly IMockType<List<int>> _mt;

    public SetListOfIntsAttribute(int fix)
        => _mt = new MockTypeListOfInt().Min(fix).Max(fix);

    public SetListOfIntsAttribute(int min, int max)
        => _mt = new MockTypeListOfInt().Range(min, max);

    public override IMockType<List<int>> GetMockType() => _mt;
}