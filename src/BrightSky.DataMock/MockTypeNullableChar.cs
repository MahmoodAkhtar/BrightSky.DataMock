namespace BrightSky.DataMock;

public record MockTypeNullableChar : IMockType<char?>, IMockTypeNullableProbability<char, MockTypeNullableChar>, IMockTypeFromAndExcludingCharacters<char?, MockTypeNullableChar>
{
    private readonly Random _random = new();
    private int _minValue = char.MinValue;
    private int _maxValue = char.MaxValue;
    private int _nullablePercentage = 50;
    private List<char> _characters = [];

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
            new(() => _characters.Count is 0 
                ? _random.NextChar(_minValue, _maxValue)
                : _characters[_random.Next(_characters.Count)], 
                100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<char?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }
    
    public IReadOnlyList<char> Characters => _characters;
    
    public MockTypeNullableChar From(char[] characters)
    {
        _characters.Clear();
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }

    public MockTypeNullableChar And(char[] characters)
    {
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }
    
    public MockTypeNullableChar Excluding(char[] characters)
    {
        _characters = _characters.Except(characters).ToList();
        return this;
    }
    
    private void AddRangeAndRemoveDuplicates(char[] characters)
    {
        _characters.AddRange(characters);
        _characters = _characters.Distinct().ToList();
    }
}