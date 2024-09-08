namespace BrightSky.DataMock;

public class SetNullableDoublesAttribute : SetTypeAttribute<double?>
{
    private readonly MockTypeNullableDouble _mt;

    public SetNullableDoublesAttribute(double fix) 
        => _mt = new MockTypeNullableDouble().Range(fix, fix).NullableProbability(Percentage.MinValue);
    
    public SetNullableDoublesAttribute(object? only = null) 
        => _mt = new MockTypeNullableDouble().NullableProbability(Percentage.MaxValue);
    
    public SetNullableDoublesAttribute(double min, double max) 
        => _mt = new MockTypeNullableDouble().Range(min, max).NullableProbability(Percentage.MinValue);
    
    public SetNullableDoublesAttribute(double min, double max, int nullablePercentage) 
        => _mt = new MockTypeNullableDouble().Range(min, max).NullableProbability((Percentage)nullablePercentage);

    public override IMockType<double?> GetMockType() => _mt;
}