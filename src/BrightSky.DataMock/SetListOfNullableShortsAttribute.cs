namespace BrightSky.DataMock;

public class SetListOfNullableShortsAttribute : SetTypeAttribute<List<short?>>
{
    private readonly IMockType<List<short?>> _mt;
    
    public SetListOfNullableShortsAttribute(short fix) 
        => _mt = new MockTypeListOfNullableShort()
            .NullableProbability(Percentage.MinValue)
            .Min(fix)
            .Max(fix);
    
    public SetListOfNullableShortsAttribute(short fix, int nullablePercentage)
        => _mt = new MockTypeListOfNullableShort()
            .NullableProbability((Percentage)nullablePercentage)
            .Min(fix)
            .Max(fix);
    
    public SetListOfNullableShortsAttribute(object? only = null) 
        => _mt = new MockTypeListOfNullableShort()
            .NullableProbability(Percentage.MaxValue);

    public SetListOfNullableShortsAttribute(short min, short max)
        => _mt = new MockTypeListOfNullableShort()
            .NullableProbability(Percentage.MinValue)
            .Min(min)
            .Max(max);   
    
    public SetListOfNullableShortsAttribute(int nullablePercentage, short min, short max)
        => _mt = new MockTypeListOfNullableShort()
            .NullableProbability((Percentage)nullablePercentage)
            .Min(min)
            .Max(max);
    
    public override IMockType<List<short?>> GetMockType() => _mt;
}