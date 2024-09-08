namespace BrightSky.DataMock;

public class SetNullableLongsAttribute : SetTypeAttribute<long?>
{
    private readonly MockTypeNullableLong _mt;

    public SetNullableLongsAttribute(long fix) 
        => _mt = new MockTypeNullableLong().Range(fix, fix).NullableProbability(Percentage.MinValue);
    
    public SetNullableLongsAttribute(object? only = null) 
        => _mt = new MockTypeNullableLong().NullableProbability(Percentage.MaxValue);
    
    public SetNullableLongsAttribute(long min, long max) 
        => _mt = new MockTypeNullableLong().Range(min, max).NullableProbability(Percentage.MinValue);
    
    public SetNullableLongsAttribute(long min, long max, int nullablePercentage) 
        => _mt = new MockTypeNullableLong().Range(min, max).NullableProbability((Percentage)nullablePercentage);

    public override IMockType<long?> GetMockType() => _mt;
}