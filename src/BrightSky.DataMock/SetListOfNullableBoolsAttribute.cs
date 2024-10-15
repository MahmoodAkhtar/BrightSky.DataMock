namespace BrightSky.DataMock;

public class SetListOfNullableBoolsAttribute : SetTypeAttribute<List<bool?>>
{
    private readonly IMockType<List<bool?>> _mt;

    public SetListOfNullableBoolsAttribute(bool fix)
    {
        var (nullablePercentage, truePercentage, falsePercentage) = fix
            ? (Percentage.MinValue, Percentage.MaxValue, Percentage.MinValue)
            : (Percentage.MinValue, Percentage.MinValue, Percentage.MaxValue);
        
        _mt = new MockTypeListOfNullableBool()
            .NullableProbability(nullablePercentage)
            .TrueProbability(truePercentage)
            .FalseProbability(falsePercentage);
    }
    
    public SetListOfNullableBoolsAttribute(bool fix, int nullablePercentage)
    {
        var (np, tp, fp) = fix
            ? ((Percentage)nullablePercentage, (Percentage)(Percentage.MaxValue - nullablePercentage), Percentage.MinValue)
            : ((Percentage)nullablePercentage, Percentage.MinValue, (Percentage)(Percentage.MaxValue - nullablePercentage));
        
        _mt = new MockTypeListOfNullableBool()
            .NullableProbability(np)
            .TrueProbability(tp)
            .FalseProbability(fp);
    }
    
    public SetListOfNullableBoolsAttribute(object? only = null)
    {
        _mt = new MockTypeListOfNullableBool()
            .NullableProbability(Percentage.MaxValue)
            .TrueProbability(Percentage.MinValue)
            .FalseProbability(Percentage.MinValue);
    }

    public SetListOfNullableBoolsAttribute(int truePercentage, int falsePercentage, int nullablePercentage)
    {
        _ = (Percentage)(truePercentage + truePercentage + falsePercentage);
        _mt = new MockTypeListOfNullableBool()
            .NullableProbability((Percentage)nullablePercentage)
            .TrueProbability((Percentage)truePercentage)
            .FalseProbability((Percentage)falsePercentage);
    }

    public override IMockType<List<bool?>> GetMockType() => _mt;
}