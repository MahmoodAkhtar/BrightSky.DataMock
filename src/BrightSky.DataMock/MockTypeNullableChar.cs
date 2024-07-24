namespace BrightSky.DataMock;

public record MockTypeNullableChar : IMockType<char?>, IMockTypeNullableProbability<char, MockTypeNullableChar>
{
    private readonly Random _random = new();
    private int _minValue = char.MinValue;
    private int _maxValue = char.MaxValue;
    private int _nullablePercentage = 50;

    internal int MinValue => _minValue;
    internal int MaxValue => _maxValue;

    public int NullablePercentage => _nullablePercentage;
    
    public MockTypeNullableChar NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }

    public char? Get()
    {
        var weightedValues = new List<WeightedValue<Func<char?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextChar(_minValue, _maxValue), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<char?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }
}