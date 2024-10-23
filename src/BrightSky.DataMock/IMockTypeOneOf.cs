namespace BrightSky.DataMock;

public interface IMockTypeOneOf<T, TThese, out TMockType> where TMockType : IMockType<T>
{
    IReadOnlyList<TThese> OneOfThese { get; }
    TMockType OneOf(TThese[] these);
}