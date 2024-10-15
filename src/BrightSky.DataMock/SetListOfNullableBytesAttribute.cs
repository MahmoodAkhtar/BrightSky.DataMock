namespace BrightSky.DataMock;

public class SetListOfNullableBytesAttribute : SetTypeAttribute<List<byte?>>
{
    private readonly IMockType<List<byte?>> _mt;
    
    public SetListOfNullableBytesAttribute(byte fix) 
        => _mt = new MockTypeListOfNullableByte()
            .NullableProbability(Percentage.MinValue)
            .Min(fix)
            .Max(fix);
    
    public SetListOfNullableBytesAttribute(byte fix, int nullablePercentage)
        => _mt = new MockTypeListOfNullableByte()
            .NullableProbability((Percentage)nullablePercentage)
            .Min(fix)
            .Max(fix);
    
    public SetListOfNullableBytesAttribute(object? only = null) 
        => _mt = new MockTypeListOfNullableByte()
            .NullableProbability(Percentage.MaxValue);

    public SetListOfNullableBytesAttribute(byte min, byte max)
        => _mt = new MockTypeListOfNullableByte()
            .NullableProbability(Percentage.MinValue)
            .Range(min, max);   
    
    public SetListOfNullableBytesAttribute(byte min, byte max, int nullablePercentage)
        => _mt = new MockTypeListOfNullableByte()
            .NullableProbability((Percentage)nullablePercentage)
            .Range(min, max);
    
    public override IMockType<List<byte?>> GetMockType() => _mt;
}