namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetDoublesAttribute : SetTypeAttribute<double>
{
    //TODO: Refactor away the public properties.
    public double Fix { get; }
    public bool IsFixed { get; }
    public double Min { get; } = double.MinValue;
    public double Max { get; } = double.MaxValue;

    public SetDoublesAttribute(double fix) => (Fix, IsFixed) = (fix, true);
    public SetDoublesAttribute(double min, double max) => (Min, Max) = (min, max);

    public override IMockType<double> GetMockType()
        => IsFixed ? Dm.Doubles().Range(Fix, Fix) : Dm.Doubles().Range(Min, Max);
}