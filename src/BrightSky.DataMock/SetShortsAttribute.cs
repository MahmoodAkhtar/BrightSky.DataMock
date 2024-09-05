namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetShortsAttribute : SetTypeAttribute<short>
{
    public short Fix { get; }
    public bool IsFixed { get; }
    public short Min { get; } = short.MinValue;
    public short Max { get; } = short.MaxValue;

    public SetShortsAttribute(short fix) => (Fix, IsFixed) = (fix, true);
    public SetShortsAttribute(short min, short max) => (Min, Max) = (min, max);

    public override IMockType<short> GetMockType()
        => IsFixed ? Dm.Shorts().Range(Fix, Fix) : Dm.Shorts().Range(Min, Max);
}