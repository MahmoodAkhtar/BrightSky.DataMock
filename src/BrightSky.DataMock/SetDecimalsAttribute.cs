namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetDecimalsAttribute : SetTypeAttribute<decimal>
{
    private readonly MockTypeDecimal _mt;
    
    public SetDecimalsAttribute(string fix) 
        => _mt = new MockTypeDecimal().Range(Parse(fix), Parse(fix));
    
    public SetDecimalsAttribute(string min, string max) 
        => _mt = new MockTypeDecimal().Range(Parse(min), Parse(max));

    public override IMockType<decimal> GetMockType() => _mt;
    
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