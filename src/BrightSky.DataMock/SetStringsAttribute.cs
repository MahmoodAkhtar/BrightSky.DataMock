namespace BrightSky.DataMock;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class SetStringsAttribute : SetTypeAttribute<string>
{
    public string Fix { get; }
    public bool IsFixed { get; }
    public char[] From { get; } = [];
    public char[] Excluding { get; } = [];
    public int Length { get; } = 10;
    public int MinLength { get; } = 10;
    public int MaxLength { get; } = 10;
    public bool IsVariableLength { get; }

    public SetStringsAttribute(string fix) => (Fix, IsFixed) = (fix, true);
    public SetStringsAttribute(char[] from) => From = from;
    public SetStringsAttribute(char[] from, int length) => (From, Length, IsVariableLength) = (from, length, false);
    public SetStringsAttribute(char[] from, int minLength, int maxLength) => (From, MinLength, MaxLength, IsVariableLength) = (from, minLength, maxLength, true);
    public SetStringsAttribute(char[] from, char[] excluding) => (From, Excluding) = (from, excluding);
    public SetStringsAttribute(char[] from, char[] excluding, int length) => (From, Excluding, Length, IsVariableLength) = (from, excluding, length, false);
    public SetStringsAttribute(char[] from, char[] excluding, int minLength, int maxLength) => (From, Excluding, MinLength, MaxLength, IsVariableLength) = (from, excluding, minLength, maxLength, true);

    public override IMockType<string> GetMockType()
        => IsFixed 
            // TODO: Thinking to impl. a Decorator Pattern instead of using a Dm.FormattedStrings().
            ? Dm.FormattedStrings(Fix) 
            : IsVariableLength 
                ? Dm.Strings().From(From).Excluding(Excluding).WithVariableLength(MinLength, MaxLength) 
                : Dm.Strings().From(From).Excluding(Excluding).WithLength(Length);
}