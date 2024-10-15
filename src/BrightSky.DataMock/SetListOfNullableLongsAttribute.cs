namespace BrightSky.DataMock;

public class SetListOfNullableLongsAttribute : SetTypeAttribute<List<long?>>
{
    private readonly IMockType<List<long?>> _mt;
    
    public SetListOfNullableLongsAttribute(long fix) 
        => _mt = new MockTypeListOfNullableLong()
            .NullableProbability(Percentage.MinValue)
            .Min(fix)
            .Max(fix);
    
    public SetListOfNullableLongsAttribute(long fix, int nullablePercentage)
        => _mt = new MockTypeListOfNullableLong()
            .NullableProbability((Percentage)nullablePercentage)
            .Min(fix)
            .Max(fix);
    
    public SetListOfNullableLongsAttribute(object? only = null) 
        => _mt = new MockTypeListOfNullableLong()
            .NullableProbability(Percentage.MaxValue);

    public SetListOfNullableLongsAttribute(long min, long max)
        => _mt = new MockTypeListOfNullableLong()
            .NullableProbability(Percentage.MinValue)
            .Min(min)
            .Max(max);   
    
    public SetListOfNullableLongsAttribute(long nullablePercentage, long min, long max)
        => _mt = new MockTypeListOfNullableLong()
            .NullableProbability((Percentage)nullablePercentage)
            .Min(min)
            .Max(max);
    
    public override IMockType<List<long?>> GetMockType() => _mt;
}