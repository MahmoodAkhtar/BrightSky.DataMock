namespace BrightSky.DataMock;

public class SetListOfNullableFloatsAttribute : SetTypeAttribute<List<float?>>
{
    private readonly IMockType<List<float?>> _mt;
    
    public SetListOfNullableFloatsAttribute(float fix) 
        => _mt = new MockTypeListOfNullableFloat()
            .NullableProbability(Percentage.MinValue)
            .Min(fix)
            .Max(fix);
    
    public SetListOfNullableFloatsAttribute(float fix, int nullablePercentage)
        => _mt = new MockTypeListOfNullableFloat()
            .NullableProbability((Percentage)nullablePercentage)
            .Min(fix)
            .Max(fix);
    
    public SetListOfNullableFloatsAttribute(object? only = null) 
        => _mt = new MockTypeListOfNullableFloat()
            .NullableProbability(Percentage.MaxValue);

    public SetListOfNullableFloatsAttribute(float min, float max)
        => _mt = new MockTypeListOfNullableFloat()
            .NullableProbability(Percentage.MinValue)
            .Min(min)
            .Max(max);   
    
    public SetListOfNullableFloatsAttribute(int nullablePercentage, float min, float max)
        => _mt = new MockTypeListOfNullableFloat()
            .NullableProbability((Percentage)nullablePercentage)
            .Min(min)
            .Max(max);
    
    public override IMockType<List<float?>> GetMockType() => _mt;
}