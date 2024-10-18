namespace BrightSky.DataMock;

public class SetListOfNullableCharsAttribute : SetTypeAttribute<List<char?>>
{
    private readonly IMockType<List<char?>> _mt;
    
    public SetListOfNullableCharsAttribute(char fix) 
        => _mt = new MockTypeListOfNullableChar()
            .NullableProbability(Percentage.MinValue)
            .From([fix]);
    
    public SetListOfNullableCharsAttribute(char fix, int nullablePercentage)
        => _mt = new MockTypeListOfNullableChar()
            .NullableProbability((Percentage)nullablePercentage)
            .From([fix]);
    
    public SetListOfNullableCharsAttribute(object? only = null) 
        => _mt = new MockTypeListOfNullableChar()
            .NullableProbability(Percentage.MaxValue);

    public SetListOfNullableCharsAttribute(char[] from)
        => _mt = new MockTypeListOfNullableChar()
            .NullableProbability(Percentage.MinValue)
            .From(from);   
    
    public SetListOfNullableCharsAttribute(char[] from, char[] excluding)
        => _mt = new MockTypeListOfNullableChar()
            .NullableProbability(Percentage.MinValue)
            .From(from)
            .Excluding(excluding);   
    
    public SetListOfNullableCharsAttribute(char[] from, int nullablePercentage)
        => _mt = new MockTypeListOfNullableChar()
            .NullableProbability((Percentage)nullablePercentage)
            .From(from);
    
    public SetListOfNullableCharsAttribute(char[] from, char[] excluding, int nullablePercentage)
        => _mt = new MockTypeListOfNullableChar()
            .NullableProbability((Percentage)nullablePercentage)
            .From(from)
            .Excluding(excluding);   
    
    public override IMockType<List<char?>> GetMockType() => _mt;
}