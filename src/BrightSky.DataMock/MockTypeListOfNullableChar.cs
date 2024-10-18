namespace BrightSky.DataMock;

public record MockTypeListOfNullableChar : 
    IMockType<List<char?>>, 
    IMockTypeNullableProbability<List<char?>, MockTypeListOfNullableChar>, 
    IMockTypeFromAndExcludingCharacters<List<char?>, MockTypeListOfNullableChar>
{
    private List<char> _characters = [];

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeListOfNullableChar NullableProbability(Percentage nullablePercentage)
    { 
        NullablePercentage = nullablePercentage;
        return this;
    }

    public List<char?> Get()
        => Dm.NullableChars()
            .NullableProbability(NullablePercentage)
            .From(Characters.ToArray())
            .ToList(100);
    
    public IReadOnlyList<char> Characters => _characters;
    
    public MockTypeListOfNullableChar From(char[] characters)
    {
        _characters.Clear();
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }

    public MockTypeListOfNullableChar And(char[] characters)
    {
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }
    
    public MockTypeListOfNullableChar Excluding(char[] characters)
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