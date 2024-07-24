namespace BrightSky.DataMock;

public record MockTypeChar : IMockType<char>, IMockTypeFromCharacterSet<char, MockTypeChar>
{
    private readonly Random _random = new();
    private readonly int _minValue = char.MinValue;
    private readonly int _maxValue = char.MaxValue;
    private List<char> _characterSet = [];

    public char Get()
    {
        return _characterSet.Count is 0
            ? _random.NextChar(_minValue, _maxValue)
            : _characterSet[_random.Next(_characterSet.Count)];
    }

    public IReadOnlyList<char> CharacterSet => _characterSet;
    
    public MockTypeChar FromCharacterSet(char[] characters)
    {
        _characterSet.Clear();
        _characterSet.AddRange(characters);

        return this;
    }
}