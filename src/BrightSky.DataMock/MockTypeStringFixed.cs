namespace BrightSky.DataMock;

internal record MockTypeStringFixed : IMockType<string>
{
    private readonly string _fix;

    public MockTypeStringFixed(string fix) => _fix = fix;

    public string Get() => _fix;
}