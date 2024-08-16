namespace BrightSky.DataMock;

public interface IMockTypeWithNewLine<T, out TMockType> where TMockType : IMockType<T>
{
    string NewLine { get; }
    TMockType WithNewLine(string newLine);
}