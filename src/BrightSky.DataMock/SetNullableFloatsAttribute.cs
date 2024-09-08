namespace BrightSky.DataMock;

public class SetNullableFloatsAttribute : SetTypeAttribute<float?>
{
    private readonly MockTypeNullableFloat _mt;

    public SetNullableFloatsAttribute(float fix) 
        => _mt = new MockTypeNullableFloat().Range(fix, fix).NullableProbability(Percentage.MinValue);
    
    public SetNullableFloatsAttribute(object? only = null) 
        => _mt = new MockTypeNullableFloat().NullableProbability(Percentage.MaxValue);
    
    public SetNullableFloatsAttribute(float min, float max) 
        => _mt = new MockTypeNullableFloat().Range(min, max).NullableProbability(Percentage.MinValue);
    
    public SetNullableFloatsAttribute(float min, float max, int nullablePercentage) 
        => _mt = new MockTypeNullableFloat().Range(min, max).NullableProbability((Percentage)nullablePercentage);

    public override IMockType<float?> GetMockType() => _mt;
}