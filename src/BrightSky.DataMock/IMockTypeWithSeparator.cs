namespace BrightSky.DataMock;

public interface IMockTypeWithSeparator<T, out TMockType> where TMockType : IMockType<T>
{
    string Separator { get; }
    TMockType WithSeparator(string separator);
}