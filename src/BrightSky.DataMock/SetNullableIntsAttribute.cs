namespace BrightSky.DataMock;

public enum PercentageOf
{
    Minimum = 0,
    _1 = 1,
    _2 = 2,
    _3 = 3,
    Maximum = 100,
}

public class SetNullableIntsAttribute : SetTypeAttribute<int?>
{
    private readonly MockTypeNullableInt _mt;

    public SetNullableIntsAttribute(int fix) 
        => _mt = new MockTypeNullableInt().Range(fix, fix).NullableProbability(Percentage.MinValue);
  
    public SetNullableIntsAttribute(int fix, long nullablePercentage) 
        => _mt = new MockTypeNullableInt().Range(fix, fix).NullableProbability((Percentage)nullablePercentage);
    
    public SetNullableIntsAttribute(object? only = null) 
        => _mt = new MockTypeNullableInt().NullableProbability(Percentage.MaxValue);
    
    public SetNullableIntsAttribute(int min, int max) 
        => _mt = new MockTypeNullableInt().Range(min, max).NullableProbability(Percentage.MinValue);
    
    public SetNullableIntsAttribute(int min, int max, int nullablePercentage) 
        => _mt = new MockTypeNullableInt().Range(min, max).NullableProbability((Percentage)nullablePercentage);

    public override IMockType<int?> GetMockType() => _mt;
}