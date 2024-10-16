namespace BrightSky.DataMock;

public class SetListOfNullableDecimalsAttribute : SetTypeAttribute<List<decimal?>>
{
    private readonly IMockType<List<decimal?>> _mt;
    
    public SetListOfNullableDecimalsAttribute(string fix) 
        => _mt = new MockTypeListOfNullableDecimal()
            .NullableProbability(Percentage.MinValue)
            .Min(fix.ParseAsDecimal())
            .Max(fix.ParseAsDecimal());
    
    public SetListOfNullableDecimalsAttribute(string fix, int nullablePercentage)
        => _mt = new MockTypeListOfNullableDecimal()
            .NullableProbability((Percentage)nullablePercentage)
            .Min(fix.ParseAsDecimal())
            .Max(fix.ParseAsDecimal());
    
    public SetListOfNullableDecimalsAttribute(object? only = null) 
        => _mt = new MockTypeListOfNullableDecimal()
            .NullableProbability(Percentage.MaxValue);

    public SetListOfNullableDecimalsAttribute(string min, string max)
        => _mt = new MockTypeListOfNullableDecimal()
            .NullableProbability(Percentage.MinValue)
            .Range(min.ParseAsDecimal(), max.ParseAsDecimal());   
    
    public SetListOfNullableDecimalsAttribute(string min, string max, int nullablePercentage)
        => _mt = new MockTypeListOfNullableDecimal()
            .NullableProbability((Percentage)nullablePercentage)
            .Range(min.ParseAsDecimal(), max.ParseAsDecimal());
    
    public override IMockType<List<decimal?>> GetMockType() => _mt;
}