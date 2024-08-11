﻿namespace BrightSky.DataMock;

public record MockTypeString : 
    IMockType<string>, 
    IMockTypeFromAndExcludingCharacters<string, MockTypeString>, 
    IMockTypeWithLength<string, int, MockTypeString>,
    IMockTypeWithVariableLength<string, int, MockTypeString>
{
    private readonly Random _random = new();
    private List<char> _characters = [];
    private int _length = 10;
    private int _minLength = 10;
    private int _maxLength = 10;
    
    public string Get()
    {
        var array = Dm.Chars().From(Characters.ToArray())
            .ToList(_random.Next(MinLength, MaxLength))
            .ToArray();
        return new string(array);
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

    public int Length => _length;
    
    public MockTypeString WithLength(int length)
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
    
    public MockTypeString WithVariableLength(int minLength, int maxLength)
    {
        if (maxLength < minLength) 
            throw new ArgumentOutOfRangeException(nameof(minLength), $"{nameof(minLength)} {minLength} cannot be less than {nameof(maxLength)} {maxLength}.");

        _minLength = minLength;
        _maxLength = maxLength;
        return this;
    }
}