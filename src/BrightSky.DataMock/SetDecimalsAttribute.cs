namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetDecimalsAttribute : SetTypeAttribute<decimal>
{
    //TODO: Refactor away the public properties and also account for client code passing in decimal.MinValue etc.
    public decimal Fix { get; }
    public bool IsFixed { get; }
    public decimal Min { get; } = decimal.MinValue;
    public decimal Max { get; } = decimal.MaxValue;

    public SetDecimalsAttribute(string fix) => (Fix, IsFixed) = (decimal.Parse(fix), true);
    public SetDecimalsAttribute(string min, string max) => (Min, Max) = (decimal.Parse(min), decimal.Parse(max));

    public override IMockType<decimal> GetMockType()
        => IsFixed ? Dm.Decimals().Range(Fix, Fix) : Dm.Decimals().Range(Min, Max);
}