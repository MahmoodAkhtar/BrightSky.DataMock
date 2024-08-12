namespace BrightSky.DataMock;

public class MockTypeNullableString : 
    IMockType<string?>, 
    IMockTypeFromAndExcludingCharacters<string?, MockTypeNullableString>, 
    IMockTypeWithLength<string?, int, MockTypeNullableString>, 
    IMockTypeNullableProbability<string?, MockTypeNullableString>,
    IMockTypeWithVariableLength<string?, int, MockTypeNullableString>
{
    private readonly Random _random = new();
    private List<char> _characters = [];
    private int _length = 10;
    private int _minLength = 10;
    private int _maxLength = 10;
    private int _nullablePercentage = 50;
    
    
    public int NullablePercentage => _nullablePercentage;
    
    public MockTypeNullableString NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }
    
    public string? Get()
    {
        var weightedValues = new List<WeightedValue<Func<string?>>>
        {
            new(() => null, NullablePercentage),
            new(() =>
                {
                    var array = Dm.Chars().From(Characters.ToArray()).ToList(_random.Next(MinLength, MaxLength)).ToArray();
                    return new string(array);
                }, 
                100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<string?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }

    public IReadOnlyList<char> Characters => _characters;
    
    public MockTypeNullableString From(char[] characters)
    {
        _characters.Clear();
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }

    public MockTypeNullableString And(char[] characters)
    {
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }
    
    public MockTypeNullableString Excluding(char[] characters)
    {
        _characters = _characters.Except(characters).ToList();
        return this;
    }
    
    private void AddRangeAndRemoveDuplicates(char[] characters)
    {
        _characters.AddRange(characters);
        _characters = _characters.Distinct().ToList();
    }

    public int Length => _length;
    
    public MockTypeNullableString WithLength(int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), $"{nameof(length)} {length} must be greater than zero");
        
        _length = length;
        _minLength = _length;
        _maxLength = _length;
        return this;
    }

    public int MinLength => _minLength;
    public int MaxLength => _maxLength;
    
    public MockTypeNullableString WithVariableLength(int minLength, int maxLength)
    {
        if (maxLength < minLength) 
            throw new ArgumentOutOfRangeException(nameof(minLength), $"{nameof(minLength)} {minLength} cannot be less than {nameof(maxLength)} {maxLength}.");

        _minLength = minLength;
        _maxLength = maxLength;
        return this;
    }
}