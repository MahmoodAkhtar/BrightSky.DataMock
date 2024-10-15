namespace BrightSky.DataMock;

public class SetListOfNullableIntsAttribute : SetTypeAttribute<List<int?>>
{
    private readonly IMockType<List<int?>> _mt;
    
    public SetListOfNullableIntsAttribute(int fix) 
        => _mt = new MockTypeListOfNullableInt()
            .NullableProbability(Percentage.MinValue)
            .Min(fix)
            .Max(fix);
    
    public SetListOfNullableIntsAttribute(int fix, long nullablePercentage)
        => _mt = new MockTypeListOfNullableInt()
            .NullableProbability((Percentage)nullablePercentage)
            .Min(fix)
            .Max(fix);
    
    public SetListOfNullableIntsAttribute(object? only = null) 
        => _mt = new MockTypeListOfNullableInt()
            .NullableProbability(Percentage.MaxValue);

    public SetListOfNullableIntsAttribute(int min, int max)
        => _mt = new MockTypeListOfNullableInt()
            .NullableProbability(Percentage.MinValue)
            .Range(min, max);   
    
    public SetListOfNullableIntsAttribute(int nullablePercentage, int min, int max)
        => _mt = new MockTypeListOfNullableInt()
            .NullableProbability((Percentage)nullablePercentage)
            .Range(min, max);   
    
    public override IMockType<List<int?>> GetMockType() => _mt;
}