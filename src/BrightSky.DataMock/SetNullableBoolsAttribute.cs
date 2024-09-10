namespace BrightSky.DataMock;

public class SetNullableBoolsAttribute : SetTypeAttribute<bool?>
{
    private readonly MockTypeNullableBool _mt;

    public SetNullableBoolsAttribute(bool fix)
    {
        var (nullablePercentage, truePercentage, falsePercentage) = fix
            ? (Percentage.MinValue, Percentage.MaxValue, Percentage.MinValue)
            : (Percentage.MinValue, Percentage.MinValue, Percentage.MaxValue);
        
        _mt = new MockTypeNullableBool()
            .NullableProbability(nullablePercentage)
            .TrueProbability(truePercentage)
            .FalseProbability(falsePercentage);
    }
    
    public SetNullableBoolsAttribute(bool fix, int nullablePercentage)
    {
        var (np, tp, fp) = fix
            ? ((Percentage)nullablePercentage, (Percentage)(Percentage.MaxValue - nullablePercentage), Percentage.MinValue)
            : ((Percentage)nullablePercentage, Percentage.MinValue, (Percentage)(Percentage.MaxValue - nullablePercentage));
        
        _mt = new MockTypeNullableBool()
            .NullableProbability(np)
            .TrueProbability(tp)
            .FalseProbability(fp);
    }
    
    public SetNullableBoolsAttribute(object? only = null)
    {
        _mt = new MockTypeNullableBool()
            .NullableProbability(Percentage.MaxValue)
            .TrueProbability(Percentage.MinValue)
            .FalseProbability(Percentage.MinValue);
    }

    public SetNullableBoolsAttribute(int nullablePercentage, int truePercentage, int falsePercentage)
    {
        _ = (Percentage)(truePercentage + truePercentage + falsePercentage);
        _mt = new MockTypeNullableBool()
            .NullableProbability((Percentage)nullablePercentage)
            .TrueProbability((Percentage)truePercentage)
            .FalseProbability((Percentage)falsePercentage);
    }

    public override IMockType<bool?> GetMockType() => _mt;
}