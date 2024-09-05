namespace BrightSky.DataMock;

public class SetBoolsAttribute : SetTypeAttribute<bool>
{
    private readonly MockTypeBool _mt;

    public SetBoolsAttribute(bool fix)
    {
        var (truePercentage, falsePercentage) = fix ? (100, 0) : (0, 100);
        _mt = new MockTypeBool().TrueProbability(truePercentage).FalseProbability(falsePercentage);
    }

    //TODO: Encapsulate this pre-conditional/guard logic into a Percentage type ???
    public SetBoolsAttribute(int truePercentage, int falsePercentage)
    {
        if (truePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(truePercentage), 
                $"{nameof(truePercentage)} {truePercentage} must be a value from 0 to 100.");
        if (falsePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(falsePercentage), 
                $"{nameof(falsePercentage)} {falsePercentage} must be a value from 0 to 100.");
        if ((truePercentage + falsePercentage) < 100)
            throw new ArgumentOutOfRangeException($"{nameof(truePercentage)} + {nameof(falsePercentage)}", 
                $"({nameof(truePercentage)} {truePercentage}) + ({nameof(falsePercentage)} {falsePercentage}) must equal to 100.");
        
        _mt = new MockTypeBool().TrueProbability(truePercentage).FalseProbability(falsePercentage);
    }

    public override IMockType<bool> GetMockType() => _mt;
}