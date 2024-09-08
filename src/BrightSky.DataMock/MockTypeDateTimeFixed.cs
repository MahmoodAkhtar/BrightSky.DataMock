namespace BrightSky.DataMock;

internal record MockTypeDateTimeFixed : IMockType<DateTime>
{
    private readonly DateTime _fix;

    public MockTypeDateTimeFixed(DateTime fix) => _fix = fix;

    public DateTime Get() => _fix;
}