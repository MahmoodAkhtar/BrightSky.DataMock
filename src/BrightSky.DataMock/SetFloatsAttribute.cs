namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetFloatsAttribute : SetTypeAttribute<float>
{
    public float Fix { get; }
    public bool IsFixed { get; }
    public float Min { get; } = float.MinValue;
    public float Max { get; } = float.MaxValue;

    public SetFloatsAttribute(float fix) => (Fix, IsFixed) = (fix, true);
    public SetFloatsAttribute(float min, float max) => (Min, Max) = (min, max);

    public override IMockType<float> GetMockType()
        => IsFixed ? Dm.Floats().Range(Fix, Fix) : Dm.Floats().Range(Min, Max);
}