namespace BrightSky.DataMock;

public record MockTypeListOfStrings : 
    IMockType<List<string>>, 
    IMockTypeFromAndExcludingCharacters<List<string>, MockTypeListOfStrings>, 
    IMockTypeWithLength<List<string>, int, MockTypeListOfStrings>,
    IMockTypeWithVariableLength<List<string>, int, MockTypeListOfStrings>,
    IMockTypeOneOf<List<string>, string, MockTypeListOfStrings>
{
    private readonly Random _random = new();
    private List<char> _characters = [];
    private string[] _oneOfThese = [];

    public List<string> Get()
    {
        if (_oneOfThese.Length > 0)
            return Dm.Strings().OneOf(_oneOfThese).ToList();
        
        var array = Dm.Strings().From(Characters.ToArray())
            .ToList(_random.Next(MinLength, MaxLength));
        
        return array;
    }

    public IReadOnlyList<string> OneOfThese => _oneOfThese;

    public MockTypeListOfStrings OneOf(string[] these)
    {
        _oneOfThese = these;
        return this;
    }

    public IReadOnlyList<char> Characters => _characters;
    
    public MockTypeListOfStrings From(char[] characters)
    {
        _characters.Clear();
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }

    public MockTypeListOfStrings And(char[] characters)
    {
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }
    
    public MockTypeListOfStrings Excluding(char[] characters)
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

    public MockTypeListOfStrings WithLength(int length)
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

    public MockTypeListOfStrings WithVariableLength(int minLength, int maxLength)
    {
        if (maxLength < minLength) 
            throw new ArgumentOutOfRangeException(nameof(minLength), $"{nameof(minLength)} {minLength} cannot be less than {nameof(maxLength)} {maxLength}.");

        MinLength = minLength;
        MaxLength = maxLength;
        return this;
    }
}