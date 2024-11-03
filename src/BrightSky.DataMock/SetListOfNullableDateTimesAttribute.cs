namespace BrightSky.DataMock;

public class SetListOfNullableDateTimesAttribute : SetTypeAttribute<List<DateTime?>>
{
    private readonly IMockType<List<DateTime?>> _mt;

    public SetListOfNullableDateTimesAttribute(string fix)
        => _mt = new MockTypeListOfNullableDateTime(DateTime.Parse(fix));
    
    public SetListOfNullableDateTimesAttribute(string fix, int nullablePercentage) 
        => _mt = new MockTypeListOfNullableDateTime(DateTime.Parse(fix)).NullableProbability((Percentage)nullablePercentage);
    
    public SetListOfNullableDateTimesAttribute(object? only = null) 
        => _mt = new MockTypeListOfNullableDateTime().NullableProbability(Percentage.MaxValue);
    
    public SetListOfNullableDateTimesAttribute(string min, string max)
        => _mt = new MockTypeListOfNullableDateTime().Range(DateTime.Parse(min), DateTime.Parse(max)).NullableProbability(Percentage.MinValue);
    
    public SetListOfNullableDateTimesAttribute(string min, string max, int nullablePercentage)
        => _mt = new MockTypeListOfNullableDateTime().Range(DateTime.Parse(min), DateTime.Parse(max)).NullableProbability((Percentage)nullablePercentage);

    public override IMockType<List<DateTime?>> GetMockType() => _mt;
}