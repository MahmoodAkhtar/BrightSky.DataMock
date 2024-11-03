namespace BrightSky.DataMock;

public class MockTypeListOfNullableDateTime: 
    IMockType<List<DateTime?>>,
    IMockTypeMinMax<List<DateTime?>, DateTime, DateTime, MockTypeListOfNullableDateTime>,
    IMockTypeRange<List<DateTime?>, DateTime, DateTime, MockTypeListOfNullableDateTime>, 
    IMockTypeNullableProbability<List<DateTime?>, MockTypeListOfNullableDateTime>
{
    private readonly DateTime? _fix;
    
    private long _minValue = DateTime.MinValue.Ticks; // 1st Jan 0001
    private long _maxValue = DateTime.MaxValue.Ticks;

    public MockTypeListOfNullableDateTime() { }
    
    public MockTypeListOfNullableDateTime(DateTime fix) => _fix = fix;
    
    public List<DateTime?> Get()
        => _fix.HasValue
            ? new MockTypeNullableDateTimeFixed(_fix.Value)
                .NullableProbability(Percentage.MinValue)
                .ToList()
            : Dm.NullableDateTimes()
                .NullableProbability(NullablePercentage)
                .Range(MinValue, MaxValue)
                .ToList();

    public MockTypeListOfNullableDateTime Range(DateTime minValue, DateTime maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue.Ticks;
        _maxValue = maxValue.Ticks;
        return this;
    }

    public DateTime MinValue => new(_minValue);
    public DateTime MaxValue => new(_maxValue);
    
    public MockTypeListOfNullableDateTime Min(DateTime minValue)
    {
        _minValue = minValue.Ticks;
        return this;
    }

    public MockTypeListOfNullableDateTime Max(DateTime maxValue)
    {
        _maxValue = maxValue.Ticks;
        return this;
    }
    
    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeListOfNullableDateTime NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
}