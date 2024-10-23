namespace BrightSky.DataMock;

public record MockTypeListOfNullableString : 
    IMockType<List<string?>>, 
    IMockTypeNullableProbability<List<string?>, MockTypeListOfNullableString>, 
    IMockTypeFromAndExcludingCharacters<List<string?>, MockTypeListOfNullableString>,
    IMockTypeOneOf<List<string?>, string, MockTypeListOfNullableString>
{
    private List<char> _characters = [];
    private string[] _oneOfThese = [];
    
    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeListOfNullableString NullableProbability(Percentage nullablePercentage)
    { 
        NullablePercentage = nullablePercentage;
        return this;
    }

    public List<string?> Get()
    {
        if (_oneOfThese.Length > 0)
            return Dm.NullableStrings()
                .NullableProbability(NullablePercentage)
                .OneOf(_oneOfThese)
                .ToList();
        
        return Dm.NullableStrings()
            .NullableProbability(NullablePercentage)
            .From(Characters.ToArray())
            .ToList(100);
    }

    public IReadOnlyList<string> OneOfThese => _oneOfThese;

    public MockTypeListOfNullableString OneOf(string[] these)
    {
        _oneOfThese = these;
        return this;
    }
    
    public IReadOnlyList<char> Characters => _characters;
    
    public MockTypeListOfNullableString From(char[] characters)
    {
        _characters.Clear();
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }

    public MockTypeListOfNullableString And(char[] characters)
    {
        AddRangeAndRemoveDuplicates(characters);
        return this;
    }
    
    public MockTypeListOfNullableString Excluding(char[] characters)
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