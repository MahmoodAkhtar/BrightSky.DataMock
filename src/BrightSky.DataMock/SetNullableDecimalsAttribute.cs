namespace BrightSky.DataMock;

public class SetNullableDecimalsAttribute : SetTypeAttribute<decimal?>
{
    private readonly MockTypeNullableDecimal _mt;

    public SetNullableDecimalsAttribute(string fix) 
        => _mt = new MockTypeNullableDecimal()
            .Range(fix.ParseAsDecimal(), fix.ParseAsDecimal())
            .NullableProbability(Percentage.MinValue);
    
    public SetNullableDecimalsAttribute(string fix, int nullablePercentage) 
        => _mt = new MockTypeNullableDecimal()
            .Range(fix.ParseAsDecimal(), fix.ParseAsDecimal())
            .NullableProbability((Percentage)nullablePercentage);
    
    public SetNullableDecimalsAttribute(object? only = null) 
        => _mt = new MockTypeNullableDecimal()
            .NullableProbability(Percentage.MaxValue);
    
    public SetNullableDecimalsAttribute(string min, string max) 
        => _mt = new MockTypeNullableDecimal()
            .Range(min.ParseAsDecimal(), max.ParseAsDecimal())
            .NullableProbability(Percentage.MinValue);
    
    public SetNullableDecimalsAttribute(string min, string max, int nullablePercentage) 
        => _mt = new MockTypeNullableDecimal()
            .Range(min.ParseAsDecimal(), max.ParseAsDecimal())
            .NullableProbability((Percentage)nullablePercentage);

    public override IMockType<decimal?> GetMockType() => _mt;
}