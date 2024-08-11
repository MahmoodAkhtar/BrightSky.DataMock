namespace BrightSky.DataMock;

public interface IMockTypeWithVariableLength<T, TLength, out TMockType> where TMockType : IMockType<T>
{
    TLength MinLength { get; }
    TLength MaxLength { get; }
    TMockType WithVariableLength(TLength minLength, TLength maxLength);
}