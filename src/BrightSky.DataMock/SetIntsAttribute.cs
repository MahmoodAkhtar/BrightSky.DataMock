namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetIntsAttribute : SetTypeAttribute<int>
{
    public int Fix { get; }
    public bool IsFixed { get; }
    public int Min { get; } = int.MinValue;
    public int Max { get; } = int.MaxValue;

    public SetIntsAttribute(int fix) => (Fix, IsFixed) = (fix, true);
    public SetIntsAttribute(int min, int max) => (Min, Max) = (min, max);

    public override IMockType<int> GetMockType()
        => IsFixed ? Dm.Ints().Range(Fix, Fix) : Dm.Ints().Range(Min, Max);
}