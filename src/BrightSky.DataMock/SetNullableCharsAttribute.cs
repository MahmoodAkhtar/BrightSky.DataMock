namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetNullableCharsAttribute : SetTypeAttribute<char?>
{
    private readonly MockTypeNullableChar _mt;

    public SetNullableCharsAttribute(char fix) 
        => _mt = new MockTypeNullableChar().From([fix]).NullableProbability(Percentage.MinValue);
    
    public SetNullableCharsAttribute(object? only = null) 
        => _mt = new MockTypeNullableChar().NullableProbability(Percentage.MaxValue);
    
    public SetNullableCharsAttribute(char[] from) 
        => _mt = new MockTypeNullableChar().From(from).NullableProbability(Percentage.MaxValue);

    public SetNullableCharsAttribute(char[] from, char[] excluding)
        => _mt = new MockTypeNullableChar().From(from).Excluding(excluding).NullableProbability(Percentage.MaxValue);
    
    public SetNullableCharsAttribute(char[] from, int nullablePercentage) 
        => _mt = new MockTypeNullableChar().From(from).NullableProbability((Percentage)nullablePercentage);

    public SetNullableCharsAttribute(char[] from, char[] excluding, int nullablePercentage)
        => _mt = new MockTypeNullableChar().From(from).Excluding(excluding).NullableProbability((Percentage)nullablePercentage);

    public override IMockType<char?> GetMockType() => _mt;
}