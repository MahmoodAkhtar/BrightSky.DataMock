namespace BrightSky.DataMock;

public class SetBoolsAttribute : SetTypeAttribute<bool>
{
    private readonly MockTypeBool _mt;

    public SetBoolsAttribute(bool fix)
    {
        var (truePercentage, falsePercentage) = fix ? (Percentage.MaxValue, Percentage.MinValue) : (Percentage.MinValue, Percentage.MaxValue);
        _mt = new MockTypeBool().TrueProbability(truePercentage).FalseProbability(falsePercentage);
    }

    public SetBoolsAttribute(int truePercentage, int falsePercentage)
    {
        //TODO: Refactor this away by doing the calculation using Percentage type
        if ((truePercentage + falsePercentage) < Percentage.MaxValue)
            throw new ArgumentOutOfRangeException($"{nameof(truePercentage)} + {nameof(falsePercentage)}", 
                $"({nameof(truePercentage)} {truePercentage}) + ({nameof(falsePercentage)} {falsePercentage}) must equal to 100.");
        
        _mt = new MockTypeBool().TrueProbability((Percentage)truePercentage).FalseProbability((Percentage)falsePercentage);
    }

    public override IMockType<bool> GetMockType() => _mt;
}