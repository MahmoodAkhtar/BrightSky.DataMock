namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetListOfNullableStringsAttribute : SetTypeAttribute<List<string?>>
{
    private readonly IMockType<List<string?>> _mt;

    public SetListOfNullableStringsAttribute(string fix)
        => _mt = new MockTypeListOfNullableString()
            .NullableProbability(Percentage.MinValue)
            .OneOf([fix]);
    
    public SetListOfNullableStringsAttribute(string fix, int nullablePercentage) 
        => _mt = new MockTypeListOfNullableString()
            .NullableProbability((Percentage)nullablePercentage)
            .OneOf([fix]);
    
    public SetListOfNullableStringsAttribute(object? only = null) 
        => _mt = new MockTypeListOfNullableString()
            .NullableProbability(Percentage.MaxValue);
    
    public SetListOfNullableStringsAttribute(char[] from) 
        => _mt = new MockTypeListOfNullableString()
            .NullableProbability(Percentage.MaxValue)
            .From(from);

    public SetListOfNullableStringsAttribute(char[] from, char[] excluding)
        => _mt = new MockTypeListOfNullableString()
            .NullableProbability(Percentage.MaxValue)
            .From(from)
            .Excluding(excluding);
    
    public SetListOfNullableStringsAttribute(char[] from, int nullablePercentage) 
        => _mt = new MockTypeListOfNullableString()
            .NullableProbability((Percentage)nullablePercentage)
            .From(from);

    public SetListOfNullableStringsAttribute(char[] from, char[] excluding, int nullablePercentage)
        => _mt = new MockTypeListOfNullableString()
            .NullableProbability((Percentage)nullablePercentage)
            .From(from)
            .Excluding(excluding);

    public override IMockType<List<string?>> GetMockType() => _mt;
}