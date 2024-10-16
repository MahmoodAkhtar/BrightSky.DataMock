namespace BrightSky.DataMock;

public class SetListOfNullableDoublesAttribute : SetTypeAttribute<List<double?>>
{
    private readonly IMockType<List<double?>> _mt;
    
    public SetListOfNullableDoublesAttribute(double fix) 
        => _mt = new MockTypeListOfNullableDouble()
            .NullableProbability(Percentage.MinValue)
            .Min(fix)
            .Max(fix);
    
    public SetListOfNullableDoublesAttribute(double fix, int nullablePercentage)
        => _mt = new MockTypeListOfNullableDouble()
            .NullableProbability((Percentage)nullablePercentage)
            .Min(fix)
            .Max(fix);
    
    public SetListOfNullableDoublesAttribute(object? only = null) 
        => _mt = new MockTypeListOfNullableDouble()
            .NullableProbability(Percentage.MaxValue);

    public SetListOfNullableDoublesAttribute(double min, double max)
        => _mt = new MockTypeListOfNullableDouble()
            .NullableProbability(Percentage.MinValue)
            .Range(min, max);   
    
    public SetListOfNullableDoublesAttribute(double min, double max, int nullablePercentage)
        => _mt = new MockTypeListOfNullableDouble()
            .NullableProbability((Percentage)nullablePercentage)
            .Range(min, max);
    
    public override IMockType<List<double?>> GetMockType() => _mt;
}