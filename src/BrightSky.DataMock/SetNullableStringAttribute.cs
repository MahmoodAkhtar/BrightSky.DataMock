namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetNullableStringAttribute: SetTypeAttribute<string?>
{
    private readonly IMockType<string?> _mt;

    public SetNullableStringAttribute(string fix)
        => _mt = new MockTypeFixedString(fix);
    
    public SetNullableStringAttribute(string fix, int nullablePercentage) 
        => _mt = new MockTypeNullableFixedString(fix).NullableProbability((Percentage)nullablePercentage);
    
    public SetNullableStringAttribute(object? only = null) 
        => _mt = new MockTypeNullableString().NullableProbability(Percentage.MaxValue);
    
    public SetNullableStringAttribute(char[] from) 
        => _mt = new MockTypeNullableString().From(from).NullableProbability(Percentage.MaxValue);

    public SetNullableStringAttribute(char[] from, char[] excluding)
        => _mt = new MockTypeNullableString().From(from).Excluding(excluding).NullableProbability(Percentage.MaxValue);
    
    public SetNullableStringAttribute(char[] from, int nullablePercentage) 
        => _mt = new MockTypeNullableString().From(from).NullableProbability((Percentage)nullablePercentage);

    public SetNullableStringAttribute(char[] from, char[] excluding, int nullablePercentage)
        => _mt = new MockTypeNullableString().From(from).Excluding(excluding).NullableProbability((Percentage)nullablePercentage);

    public override IMockType<string?> GetMockType() => _mt;
}