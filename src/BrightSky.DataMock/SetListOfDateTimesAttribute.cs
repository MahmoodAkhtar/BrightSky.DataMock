namespace BrightSky.DataMock;

public class SetListOfDateTimesAttribute : SetTypeAttribute<List<DateTime>>
{
    private readonly IMockType<List<DateTime>> _mt;

    public SetListOfDateTimesAttribute(string fix) => _mt = new MockTypeListOfDateTime(DateTime.Parse(fix));

    public SetListOfDateTimesAttribute(string min, string max)
        => _mt = new MockTypeListOfDateTime().Range(DateTime.Parse(min), DateTime.Parse(max));

    public override IMockType<List<DateTime>> GetMockType() => _mt;
}