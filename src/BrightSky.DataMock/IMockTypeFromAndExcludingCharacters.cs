namespace BrightSky.DataMock;

public interface IMockTypeFromAndExcludingCharacters<T, out TMockType> where TMockType : IMockType<T>
{
    IReadOnlyList<char> Characters { get; }
    TMockType From(char[] characters);
    TMockType And(char[] characters);
    TMockType Excluding(char[] characters);
}