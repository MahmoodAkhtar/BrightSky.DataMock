namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetNullableStringsAttribute : SetTypeAttribute<string?>
{
    private readonly IMockType<string?> _mt;

    public SetNullableStringsAttribute(string fix)
        => _mt = new MockTypeFixedString(fix);
    
    public SetNullableStringsAttribute(string fix, int nullablePercentage) 
        => _mt = new MockTypeNullableFixedString(fix).NullableProbability((Percentage)nullablePercentage);
    
    public SetNullableStringsAttribute(object? only = null) 
        => _mt = new MockTypeNullableString().NullableProbability(Percentage.MaxValue);
    
    public SetNullableStringsAttribute(char[] from) 
        => _mt = new MockTypeNullableString().From(from).NullableProbability(Percentage.MaxValue);

    public SetNullableStringsAttribute(char[] from, char[] excluding)
        => _mt = new MockTypeNullableString().From(from).Excluding(excluding).NullableProbability(Percentage.MaxValue);
    
    public SetNullableStringsAttribute(char[] from, int nullablePercentage) 
        => _mt = new MockTypeNullableString().From(from).NullableProbability((Percentage)nullablePercentage);

    public SetNullableStringsAttribute(char[] from, char[] excluding, int nullablePercentage)
        => _mt = new MockTypeNullableString().From(from).Excluding(excluding).NullableProbability((Percentage)nullablePercentage);

    public override IMockType<string?> GetMockType() => _mt;
}