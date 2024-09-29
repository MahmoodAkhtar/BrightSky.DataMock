namespace BrightSky.DataMock;

public class SetNullableDateTimesAttribute : SetTypeAttribute<DateTime?>
{
    private readonly IMockType<DateTime?> _mt;

    public SetNullableDateTimesAttribute(string fix)
        => _mt = new MockTypeNullableDateTimeFixed(DateTime.Parse(fix));
    
    public SetNullableDateTimesAttribute(string fix, int nullablePercentage) 
        => _mt = new MockTypeNullableDateTimeFixed(DateTime.Parse(fix)).NullableProbability((Percentage)nullablePercentage);
    
    public SetNullableDateTimesAttribute(object? only = null) 
        => _mt = new MockTypeNullableDateTime().NullableProbability(Percentage.MaxValue);
    
    public SetNullableDateTimesAttribute(string min, string max)
        => _mt = new MockTypeNullableDateTime().Range(DateTime.Parse(min), DateTime.Parse(min)).NullableProbability(Percentage.MinValue);
    
    public SetNullableDateTimesAttribute(string min, string max, int nullablePercentage)
        => _mt = new MockTypeNullableDateTime().Range(DateTime.Parse(min), DateTime.Parse(min)).NullableProbability((Percentage)nullablePercentage);

    public override IMockType<DateTime?> GetMockType() => _mt;
}