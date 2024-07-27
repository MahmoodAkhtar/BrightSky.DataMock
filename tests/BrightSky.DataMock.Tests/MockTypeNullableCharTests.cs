namespace BrightSky.DataMock.Tests;

public class MockTypeNullableCharTests
{
    [Fact]
    public void When_NullableChars_Returns_ImplOf_IMockTypeOfNullableChar()
    {
        var actual = Dm.NullableChars();

        Assert.IsAssignableFrom<IMockType<char?>>(actual);
    }
    
    [Fact]
    public void When_NullableChars_Returns_MockTypeNullableChar()
    {
        var actual = Dm.NullableChars();

        Assert.IsType<MockTypeNullableChar>(actual);
    }
    
    [Fact]
    public void When_NullableCharsGet_Returns_NullableChar()
    {
        var actual = Dm.NullableChars().Get();

        Assert.True(Test.IsNullable(actual));
    }
    
    [Fact]
    public void When_NullableCharsToList_Default_Size_Returns_ListOfNullableChar()
    {
        var actual = Dm.NullableChars().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<char?>>(actual);
    }
    
    [Fact]
    public void When_NullableCharsToList_Size_0_Returns_EmptyListOfNullableChar()
    {
        var actual = Dm.NullableChars().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<char?>>(actual);
    }
    
    [Fact]
    public void When_NullableCharsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.NullableChars().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableCharsToList_With_Size_Returns_ListOfNullableChar(int size)
    {
        var actual = Dm.NullableChars().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<char?>>(actual);
    }
    
    [Fact]
    public void When_NullableCharsNullableProbability_Returns_MockTypeNullableChar()
    {
        var actual = Dm.NullableChars().NullableProbability(1);

        Assert.IsType<MockTypeNullableChar>(actual);
    }
    
    [Fact]
    public void When_NullableCharsNullableProbability_NullablePercentage_LessThanZero_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableChars().NullableProbability(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableCharsNullableProbability_NullablePercentage_GreaterThanOneHundred_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableChars().NullableProbability(101);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableCharsNullableProbability_With_0_NeverReturns_Null()
    {
        var actual = Dm.NullableChars().NullableProbability(0).ToList();

        Assert.True(actual.All(x => x is not null));
    }
    
    [Fact]
    public void When_NullableCharsNullableProbability_With_100_Returns_AlwaysNull()
    {
        var actual = Dm.NullableChars().NullableProbability(100).ToList();

        Assert.True(actual.All(x => x is null));
    }
    
    [Fact]
    public void When_NullableCharsToList_With_DefaultNullableProbability_Returns_Null_50Percent()
    {
        var actual = Dm.NullableChars().ToList();

        Assert.Equal(50, actual.Count(x => x is null));
    }
    
    [Theory]
    [InlineData(0, 100)]
    [InlineData(1, 100)]
    [InlineData(3, 100)]
    [InlineData(5, 100)]
    [InlineData(10, 100)]
    [InlineData(50, 100)]
    [InlineData(51, 100)]
    [InlineData(63, 100)]
    [InlineData(75, 100)]
    [InlineData(80, 100)]
    [InlineData(95, 100)]
    [InlineData(99, 100)]
    [InlineData(100, 100)]
    
    [InlineData(0, 150)]
    [InlineData(1, 150)]
    [InlineData(3, 150)]
    [InlineData(5, 150)]
    [InlineData(10, 150)]
    [InlineData(50, 150)]
    [InlineData(51, 150)]
    [InlineData(63, 150)]
    [InlineData(75, 150)]
    [InlineData(80, 150)]
    [InlineData(95, 150)]
    [InlineData(99, 150)]
    [InlineData(100, 150)]
    
    [InlineData(0, 99)]
    [InlineData(1, 99)]
    [InlineData(3, 99)]
    [InlineData(5, 99)]
    [InlineData(10, 99)]
    [InlineData(50, 99)]
    [InlineData(51, 99)]
    [InlineData(63, 99)]
    [InlineData(75, 99)]
    [InlineData(80, 99)]
    [InlineData(95, 99)]
    [InlineData(99, 99)]
    [InlineData(100, 99)]
    public void When_NullableCharsNullableProbabilityAndToList_With_NullablePercentage_And_Size_Returns_ExpectedNullCount(int nullablePercentage, int size)
    {
        var expected = (int)Math.Ceiling(size * (nullablePercentage / 100.0m));
        var actual = Dm.NullableChars().NullableProbability(nullablePercentage).ToList(size);

        Assert.Equal(expected, actual.Count(x => x is null));
    }
    
    [Fact]
    public void When_NullableCharsFromAndAnd_With_DuplicateCharacters_Returns_Expected_Characters()
    {
        var expected = new[] { 'a', 'b', 'c' };
        var characters = new[] { 'a', 'b', 'c' };
            
        var actual = Dm.NullableChars().From(characters).And(characters).Characters;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_NullableCharsFromAndAnd_BothWith_Characters_Returns_Expected_Characters()
    {
        var expected = new[] { 'a', 'b', 'c', 'd', 'e', 'f' };
        var abc = new[] { 'a', 'b', 'c' };
        var def = new[] { 'd', 'e', 'f' };
            
        var actual = Dm.NullableChars().From(abc).And(def).Characters;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_NullableCharsFrom_With_CharBasicLatin_Get_Returns_Char_ContainedIn_CharBasicLatinOrNull()
    {
        var actual = Dm.Chars().From(Dm.Char.BasicLatin).Get();
        
        Assert.Contains(actual, Dm.Char.BasicLatin.Cast<char?>().Concat([null]));
    }
    
    [Fact]
    public void When_NullableCharsFrom_With_CharDigits_Get_Returns_Char_ContainedIn_CharDigitsOrNull()
    {
        var actual = Dm.NullableChars().From(Dm.Char.Digits).Get();
        
        Assert.Contains(actual, Dm.Char.Digits.Cast<char?>().Concat([null]));
    }
    
    [Fact]
    public void When_NullableCharsFrom_With_CharUppercaseLetters_Get_Returns_Char_ContainedIn_CharUppercaseLettersOrNull()
    {
        var actual = Dm.NullableChars().From(Dm.Char.UppercaseLetters).Get();
        
        Assert.Contains(actual, Dm.Char.UppercaseLetters.Cast<char?>().Concat([null]));
    }
    
    [Fact]
    public void When_NullableCharsFrom_With_CharLowercaseLetters_Get_Returns_Char_ContainedIn_CharLowercaseLettersOrNull()
    {
        var actual = Dm.NullableChars().From(Dm.Char.LowercaseLetters).Get();
        
        Assert.Contains(actual, Dm.Char.LowercaseLetters.Cast<char?>().Concat([null]));
    }
    
    [Fact]
    public void When_NullableCharsFrom_With_CharCaseInsensitiveLetters_Get_Returns_Char_ContainedIn_CharCaseInsensitiveLettersOrNull()
    {
        var actual = Dm.NullableChars().From(Dm.Char.CaseInsensitiveLetters).Get();
        
        Assert.Contains(actual, Dm.Char.CaseInsensitiveLetters.Cast<char?>().Concat([null]));
    }
    
    [Fact]
    public void When_NullableCharsFrom_With_CharSpecialSymbols_Get_Returns_Char_ContainedIn_CharSpecialSymbolsOrNull()
    {
        var actual = Dm.NullableChars().From(Dm.Char.SpecialSymbols).Get();
        
        Assert.Contains(actual, Dm.Char.SpecialSymbols.Cast<char?>().Concat([null]));
    }    
    
    [Fact]
    public void When_NullableCharsExcluding_Returns_ImplOf_IMockTypeOfNullableChar()
    {
        var actual = Dm.NullableChars().Excluding([]);
        
        Assert.IsAssignableFrom<IMockType<char?>>(actual);
    }
    
    [Fact]
    public void When_NullableCharsExcluding_Returns_MockTypeNullableChar()
    {
        var actual = Dm.NullableChars().Excluding([]);
         
        Assert.IsType<MockTypeNullableChar>(actual);
    }
     
    [Fact]
    public void When_NullableCharsFromExcluding_Empty_Get_Returns_Char_ContainedIn_CharDigitsOrNull()
    {
        var actual = Dm.NullableChars()
            .From(Dm.Char.Digits)
            .Excluding([])
            .Get();
         
        Assert.Contains(actual, Dm.Char.Digits.Cast<char?>().Concat([null]));
    }
}