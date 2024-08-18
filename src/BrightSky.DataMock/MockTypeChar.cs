namespace BrightSky.DataMock;

public record MockTypeChar : IMockType<char>, IMockTypeFromAndExcludingCharacters<char, MockTypeChar>
{
    private readonly Random _random = new();
    private List<char> _characters = [];

    public char Get()
    {
        return _characters.Count is 0
            ? _random.NextChar(char.MinValue, char.MaxValue)
            : _characters[_random.Next(_characters.Count)];
    }

    public IReadOnlyList<char> Characters => _characters;
    
    public MockTypeChar From(char[] characters)
    {
        _characters.Clear();
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }

    public MockTypeChar And(char[] characters)
    {
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }
    
    public MockTypeChar Excluding(char[] characters)
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

