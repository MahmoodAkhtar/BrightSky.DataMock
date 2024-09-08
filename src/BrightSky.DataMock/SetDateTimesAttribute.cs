namespace BrightSky.DataMock;

public class SetDateTimesAttribute : SetTypeAttribute<DateTime>
{
    private readonly IMockType<DateTime> _mt;

    public SetDateTimesAttribute(string fix) => _mt = new MockTypeDateTimeFixed(DateTime.Parse(fix));

    public SetDateTimesAttribute(string min, string max)
        => _mt = new MockTypeDateTime().Range(DateTime.Parse(min), DateTime.Parse(max));

    public override IMockType<DateTime> GetMockType() => _mt;
}