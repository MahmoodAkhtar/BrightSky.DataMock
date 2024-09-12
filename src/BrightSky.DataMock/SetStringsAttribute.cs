namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetStringsAttribute : SetTypeAttribute<string>
{
    private readonly IMockType<string> _mt;

    public SetStringsAttribute(string fix) 
        => _mt = new MockTypeFixedString(fix);
    
    public SetStringsAttribute(char[] from) 
        => _mt = Dm.Strings().From(from);
    
    public SetStringsAttribute(char[] from, int length) 
        => _mt = Dm.Strings().From(from).WithLength(length);
    
    public SetStringsAttribute(char[] from, int minLength, int maxLength) 
        => _mt = Dm.Strings().From(from).WithVariableLength(minLength, maxLength);
    
    public SetStringsAttribute(char[] from, char[] excluding) 
        => _mt = Dm.Strings().From(from).Excluding(excluding);
    
    public SetStringsAttribute(char[] from, char[] excluding, int length) 
        => _mt = Dm.Strings().From(from).Excluding(excluding).WithLength(length);
    
    public SetStringsAttribute(char[] from, char[] excluding, int minLength, int maxLength) 
        => _mt = Dm.Strings().From(from).Excluding(excluding).WithVariableLength(minLength, maxLength);

    public override IMockType<string> GetMockType() => _mt;
}