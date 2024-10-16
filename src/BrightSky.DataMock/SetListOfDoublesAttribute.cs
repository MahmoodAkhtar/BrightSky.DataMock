namespace BrightSky.DataMock;

public class SetListOfDoublesAttribute : SetTypeAttribute<List<double>>
{
    private readonly IMockType<List<double>> _mt;

    public SetListOfDoublesAttribute(double fix)
        => _mt = new MockTypeListOfDouble().Min(fix).Max(fix);

    public SetListOfDoublesAttribute(double min, double max)
        => _mt = new MockTypeListOfDouble().Range(min, max);

    public override IMockType<List<double>> GetMockType() => _mt;
}