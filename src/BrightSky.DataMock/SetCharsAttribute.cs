namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetCharsAttribute : SetTypeAttribute<char>
{
    public char Fix { get; }
    public bool IsFixed { get; }
    public char[] From { get; } = [];
    public char[] Excluding { get; } = [];

    public SetCharsAttribute(char fix) => (Fix, IsFixed) = (fix, true);
    public SetCharsAttribute(char[] from) => From = from;
    public SetCharsAttribute(char[] from, char[] excluding) => (From, Excluding) = (from, excluding);

    public override IMockType<char> GetMockType()
        => IsFixed ? Dm.Chars().From([Fix]) : Dm.Chars().From(From).Excluding(Excluding);
}