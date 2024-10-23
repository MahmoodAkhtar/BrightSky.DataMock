namespace BrightSky.DataMock;

public class MockTypeNullableString : 
    IMockType<string?>, 
    IMockTypeFromAndExcludingCharacters<string?, MockTypeNullableString>, 
    IMockTypeWithLength<string?, int, MockTypeNullableString>, 
    IMockTypeNullableProbability<string?, MockTypeNullableString>,
    IMockTypeWithVariableLength<string?, int, MockTypeNullableString>,
    IMockTypeOneOf<string?, string, MockTypeNullableString>
{
    private readonly Random _random = new();
    private List<char> _characters = [];
    private string[] _oneOfThese = [];

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeNullableString NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }
    
    public string? Get()
    {
        
        var chosen = new List<WeightedValue<Func<string?>>>
        {
            new(() => null, NullablePercentage),
            new(() =>
                {
                    if (_oneOfThese.Length > 0)
                        return _oneOfThese[_random.Next(_oneOfThese.Length)];
                    
                    var array = Dm.Chars().From(Characters.ToArray()).ToList(_random.Next(MinLength, MaxLength)).ToArray();
                    return new string(array);
                }, 
                Percentage.MaxValue - NullablePercentage),
        }.Next();
        
        return chosen();
    }

    public IReadOnlyList<string> OneOfThese => _oneOfThese;

    public MockTypeNullableString OneOf(string[] these)
    {
        _oneOfThese = these;
        return this;
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

    public int Length { get; private set; } = 10;

    public MockTypeNullableString WithLength(int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), $"{nameof(length)} {length} must be greater than zero");
        
        Length = length;
        MinLength = Length;
        MaxLength = Length;
        return this;
    }

    public int MinLength { get; private set; } = 10;
    public int MaxLength { get; private set; } = 10;

    public MockTypeNullableString WithVariableLength(int minLength, int maxLength)
    {
        if (maxLength < minLength) 
            throw new ArgumentOutOfRangeException(nameof(minLength), $"{nameof(minLength)} {minLength} cannot be less than {nameof(maxLength)} {maxLength}.");

        MinLength = minLength;
        MaxLength = maxLength;
        return this;
    }
}