namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetCharsAttribute : SetTypeAttribute<char>
{
    private readonly MockTypeChar _mt;

    public SetCharsAttribute(char fix) => _mt = new MockTypeChar().From([fix]);
    public SetCharsAttribute(char[] from) => _mt = new MockTypeChar().From(from);
    public SetCharsAttribute(char[] from, char[] excluding) => _mt = new MockTypeChar().From(from).Excluding(excluding);

    public override IMockType<char> GetMockType() => _mt;
}