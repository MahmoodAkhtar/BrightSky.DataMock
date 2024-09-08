namespace BrightSky.DataMock;

public class SetNullableDecimalsAttribute : SetTypeAttribute<decimal?>
{
    private readonly MockTypeNullableDecimal _mt;

    public SetNullableDecimalsAttribute(string fix) 
        => _mt = new MockTypeNullableDecimal().Range(Parse(fix), Parse(fix)).NullableProbability(Percentage.MinValue);
    
    public SetNullableDecimalsAttribute(object? only = null) 
        => _mt = new MockTypeNullableDecimal().NullableProbability(Percentage.MaxValue);
    
    public SetNullableDecimalsAttribute(string min, string max) 
        => _mt = new MockTypeNullableDecimal().Range(Parse(min), Parse(max)).NullableProbability(Percentage.MinValue);
    
    public SetNullableDecimalsAttribute(string min, string max, int nullablePercentage) 
        => _mt = new MockTypeNullableDecimal().Range(Parse(min), Parse(max)).NullableProbability((Percentage)nullablePercentage);

    public override IMockType<decimal?> GetMockType() => _mt;

    private static decimal Parse(string str)
    {
        var dict = new Dictionary<Func<bool>, Func<decimal>>
        {
            { () => str == "decimal.MinValue", () => decimal.MinValue },
            { () => str == "decimal.MaxValue", () => decimal.MaxValue },
            { () => str == "Decimal.MinValue", () => decimal.MinValue },
            { () => str == "Decimal.MaxValue", () => decimal.MaxValue },
            { () => true, () => decimal.Parse(str) },
        };
        
        return dict.First(kvp => kvp.Key()).Value();
    }
}