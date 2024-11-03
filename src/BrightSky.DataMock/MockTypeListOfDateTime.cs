namespace BrightSky.DataMock;

public class MockTypeListOfDateTime: 
    IMockType<List<DateTime>>,
    IMockTypeMinMax<List<DateTime>, DateTime, DateTime, MockTypeListOfDateTime>,
    IMockTypeRange<List<DateTime>, DateTime, DateTime, MockTypeListOfDateTime>
{
    private readonly DateTime? _fix;
    
    private long _minValue = DateTime.MinValue.Ticks; // 1st Jan 0001
    private long _maxValue = DateTime.MaxValue.Ticks;

    public MockTypeListOfDateTime() { }
    
    public MockTypeListOfDateTime(DateTime fix) => _fix = fix;
    
    public List<DateTime> Get()
        => _fix.HasValue
            ? new MockTypeDateTimeFixed(_fix.Value).ToList()
            : Dm.DateTimes().Range(MinValue, MaxValue).ToList();

    public MockTypeListOfDateTime Range(DateTime minValue, DateTime maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue.Ticks;
        _maxValue = maxValue.Ticks;
        return this;
    }

    public DateTime MinValue => new(_minValue);
    public DateTime MaxValue => new(_maxValue);
    
    public MockTypeListOfDateTime Min(DateTime minValue)
    {
        _minValue = minValue.Ticks;
        return this;
    }

    public MockTypeListOfDateTime Max(DateTime maxValue)
    {
        _maxValue = maxValue.Ticks;
        return this;
    }
}