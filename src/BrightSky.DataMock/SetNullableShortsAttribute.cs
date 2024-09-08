namespace BrightSky.DataMock;

public class SetNullableShortsAttribute : SetTypeAttribute<short?>
{
    private readonly MockTypeNullableShort _mt;

    public SetNullableShortsAttribute(short fix) 
        => _mt = new MockTypeNullableShort().Range(fix, fix).NullableProbability(Percentage.MinValue);
    
    public SetNullableShortsAttribute(object? only = null) 
        => _mt = new MockTypeNullableShort().NullableProbability(Percentage.MaxValue);
    
    public SetNullableShortsAttribute(short min, short max) 
        => _mt = new MockTypeNullableShort().Range(min, max).NullableProbability(Percentage.MinValue);
    
    public SetNullableShortsAttribute(short min, short max, int nullablePercentage) 
        => _mt = new MockTypeNullableShort().Range(min, max).NullableProbability((Percentage)nullablePercentage);

    public override IMockType<short?> GetMockType() => _mt;
}