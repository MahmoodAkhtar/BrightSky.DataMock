namespace BrightSky.DataMock;

public class MockTypeListOfChar : IMockType<List<char>>, 
    IMockTypeFromAndExcludingCharacters<List<char>, MockTypeListOfChar>
{
    private List<char> _characters = [];
    
    public List<char> Get()
        => Dm.Chars().From(Characters.ToArray()).ToList(100);

    public IReadOnlyList<char> Characters => _characters;
    
    public MockTypeListOfChar From(char[] characters)
    {
        _characters.Clear();
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }

    public MockTypeListOfChar And(char[] characters)
    {
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }
    
    public MockTypeListOfChar Excluding(char[] characters)
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