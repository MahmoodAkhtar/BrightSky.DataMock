namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetListOfStringsAttribute : SetTypeAttribute<List<string>>
{
    private readonly IMockType<List<string>> _mt;

    public SetListOfStringsAttribute(string fix) 
        => _mt = new MockTypeListOfStrings().OneOf([fix]);
    
    public SetListOfStringsAttribute(char[] from) 
        => _mt = new MockTypeListOfStrings().From(from);
    
    public SetListOfStringsAttribute(char[] from, int length) 
        => _mt = new MockTypeListOfStrings().From(from).WithLength(length);
    
    public SetListOfStringsAttribute(char[] from, int minLength, int maxLength) 
        => _mt = new MockTypeListOfStrings().From(from).WithVariableLength(minLength, maxLength);
    
    public SetListOfStringsAttribute(char[] from, char[] excluding) 
        => _mt = new MockTypeListOfStrings().From(from).Excluding(excluding);
    
    public SetListOfStringsAttribute(char[] from, char[] excluding, int length) 
        => _mt = new MockTypeListOfStrings().From(from).Excluding(excluding).WithLength(length);
    
    public SetListOfStringsAttribute(char[] from, char[] excluding, int minLength, int maxLength) 
        => _mt = new MockTypeListOfStrings().From(from).Excluding(excluding).WithVariableLength(minLength, maxLength);

    public override IMockType<List<string>> GetMockType() => _mt;
}