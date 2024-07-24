namespace BrightSky.DataMock;

public interface IMockTypeFromCharacterSet<T, out TMockType> where TMockType : IMockType<T>
{
    IReadOnlyList<char> CharacterSet { get; }
    TMockType FromCharacterSet(char[] characters);
}