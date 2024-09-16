namespace BrightSky.DataMock;

public interface IMockTypeEmptyNonEmptyProbability<T, out TMockType>
    where TMockType : IMockType<T>
{
    public Percentage EmptyPercentage { get; }
    public Percentage NonEmptyPercentage { get; }
    public TMockType EmptyProbability(Percentage emptyPercentage);
    public TMockType NonEmptyProbability(Percentage nonEmptyPercentage);
}