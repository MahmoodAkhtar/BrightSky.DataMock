namespace BrightSky.DataMock;

public record MockTypeString : 
    IMockType<string>, 
    IMockTypeFromAndExcludingCharacters<string, MockTypeString>, 
    IMockTypeWithLength<string, int, MockTypeString>,
    IMockTypeWithVariableLength<string, int, MockTypeString>
{
    private readonly Random _random = new();
    private List<char> _characters = [];
    private List<string> _oneOfList = [];

    public string Get()
    {
        if (_oneOfList.Count != 0)
            return _oneOfList[_random.Next(_oneOfList.Count)];
        
        var array = Dm.Chars().From(Characters.ToArray())
            .ToList(_random.Next(MinLength, MaxLength))
            .ToArray();
        return new string(array);
    }

    public MockTypeString OneOf(string[] these)
    {
        _oneOfList = these.ToList();
        return this;
    }

    public IReadOnlyList<char> Characters => _characters;
    
    public MockTypeString From(char[] characters)
    {
        _characters.Clear();
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }

    public MockTypeString And(char[] characters)
    {
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }
    
    public MockTypeString Excluding(char[] characters)
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

    public MockTypeString WithLength(int length)
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

    public MockTypeString WithVariableLength(int minLength, int maxLength)
    {
        if (maxLength < minLength) 
            throw new ArgumentOutOfRangeException(nameof(minLength), $"{nameof(minLength)} {minLength} cannot be less than {nameof(maxLength)} {maxLength}.");

        MinLength = minLength;
        MaxLength = maxLength;
        return this;
    }
}