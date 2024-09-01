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

    public int NullablePercentage { get; private set; } = 50;

    public MockTypeNullableString NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
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
                    var array = Dm.Chars().From(Characters.ToArray()).ToList(_random.Next(MinLength, MaxLength)).ToArray();
                    return new string(array);
                }, 
                100 - NullablePercentage),
        }.Next();
        
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