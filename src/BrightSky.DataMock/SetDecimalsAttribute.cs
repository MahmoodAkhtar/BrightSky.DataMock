namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetDecimalsAttribute : SetTypeAttribute<decimal>
{
    private readonly MockTypeDecimal _mt;
    
    public SetDecimalsAttribute(string fix) 
        => _mt = new MockTypeDecimal().Range(fix.ParseAsDecimal(), fix.ParseAsDecimal());
    
    public SetDecimalsAttribute(string min, string max) 
        => _mt = new MockTypeDecimal().Range(min.ParseAsDecimal(), max.ParseAsDecimal());

    public override IMockType<decimal> GetMockType() => _mt;
}