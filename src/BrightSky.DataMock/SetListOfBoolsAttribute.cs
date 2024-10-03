namespace BrightSky.DataMock;

public class SetListOfBoolsAttribute : SetTypeAttribute<List<bool>>
{
    private readonly IMockType<List<bool>> _mt;

    public SetListOfBoolsAttribute(bool fix)
    {
        var (truePercentage, falsePercentage) = fix ? (Percentage.MaxValue, Percentage.MinValue) : (Percentage.MinValue, Percentage.MaxValue);
        _mt = new MockTypeListOfBool().TrueProbability(truePercentage).FalseProbability(falsePercentage);
    }

    public SetListOfBoolsAttribute(int truePercentage, int falsePercentage)
    {
        _ = (Percentage)(truePercentage + falsePercentage);
        _mt = new MockTypeListOfBool().TrueProbability((Percentage)truePercentage).FalseProbability((Percentage)falsePercentage);
    }

    public override IMockType<List<bool>> GetMockType() => _mt;
}