namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetLongsAttribute : SetTypeAttribute<long>
{
    //TODO: Refactor away the public properties.
    public long Fix { get; }
    public bool IsFixed { get; }
    public long Min { get; } = long.MinValue;
    public long Max { get; } = long.MaxValue;

    public SetLongsAttribute(long fix) => (Fix, IsFixed) = (fix, true);
    public SetLongsAttribute(long min, long max) => (Min, Max) = (min, max);

    public override IMockType<long> GetMockType()
        => IsFixed ? Dm.Longs().Range(Fix, Fix) : Dm.Longs().Range(Min, Max);
}