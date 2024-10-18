namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetListOfCharsAttribute : SetTypeAttribute<List<char>>
{
    private readonly IMockType<List<char>> _mt;

    public SetListOfCharsAttribute(char fix) 
        => _mt = new MockTypeListOfChar().From([fix]);
    
    public SetListOfCharsAttribute(char[] from) 
        => _mt = new MockTypeListOfChar().From(from);
    
    public SetListOfCharsAttribute(char[] from, char[] excluding) 
        => _mt = new MockTypeListOfChar().From(from).Excluding(excluding);

    public override IMockType<List<char>> GetMockType() => _mt;
}