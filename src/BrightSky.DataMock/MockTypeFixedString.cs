namespace BrightSky.DataMock;

internal record MockTypeFixedString : IMockType<string>
{
    private readonly string _fix;

    public MockTypeFixedString(string fix) => _fix = fix;

    public string Get() => _fix;
}