namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetDoublesAttribute : SetTypeAttribute<double>
{
    private readonly MockTypeDouble _mt;

    public SetDoublesAttribute(double fix) => _mt = new MockTypeDouble().Range(fix, fix);
    public SetDoublesAttribute(double min, double max) => _mt = new MockTypeDouble().Range(min, max);

    public override IMockType<double> GetMockType() => _mt;
}