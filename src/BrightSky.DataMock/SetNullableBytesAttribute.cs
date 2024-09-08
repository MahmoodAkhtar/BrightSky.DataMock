namespace BrightSky.DataMock;

public class SetNullableBytesAttribute : SetTypeAttribute<byte?>
{
    private readonly MockTypeNullableByte _mt;

    public SetNullableBytesAttribute(byte fix) 
        => _mt = new MockTypeNullableByte().Range(fix, fix).NullableProbability(Percentage.MinValue);
    
    public SetNullableBytesAttribute(object? only = null) 
        => _mt = new MockTypeNullableByte().NullableProbability(Percentage.MaxValue);
    
    public SetNullableBytesAttribute(byte min, byte max) 
        => _mt = new MockTypeNullableByte().Range(min, max).NullableProbability(Percentage.MinValue);
    
    public SetNullableBytesAttribute( byte min, byte max, int nullablePercentage) 
        => _mt = new MockTypeNullableByte().Range(min, max).NullableProbability((Percentage)nullablePercentage);

    public override IMockType<byte?> GetMockType() => _mt;
}