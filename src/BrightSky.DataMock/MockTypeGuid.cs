namespace BrightSky.DataMock;

public record MockTypeGuid : IMockType<Guid>
{
    private readonly Random _random = new();

    public int NonEmptyPercentage { get; private set; } = 50;
    public int EmptyPercentage { get; private set; } = 50;
    
    public MockTypeGuid NonEmptyProbability(int nonEmptyPercentage)
    {
        (NonEmptyPercentage, EmptyPercentage) = CalculatePercentages(nameof(nonEmptyPercentage), nonEmptyPercentage);
        return this;        
    }

    public MockTypeGuid EmptyProbability(int emptyPercentage)
    {
        (EmptyPercentage, NonEmptyPercentage) = CalculatePercentages(nameof(emptyPercentage), emptyPercentage);
        return this;
    }

    //TODO: DRY - MockTypeBool also has this type of calculation - More indication the need for a concrete type for Percentage.
    private static (int FirstPrecentage, int SecondPrecentage) CalculatePercentages(string paramName, int percentage)
    {
        if (percentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(paramName, $"{paramName} {percentage} must be a value from 0 to 100.");

        return (percentage, 100 - percentage);
    }
    
    public Guid Get() => _random.NextDouble() <= NonEmptyPercentage/100.0 ? Guid.NewGuid() : Guid.Empty;
}