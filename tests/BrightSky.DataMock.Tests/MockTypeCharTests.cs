namespace BrightSky.DataMock.Tests;

public class MockTypeCharTests
{
    [Fact]
    public void When_Chars_Returns_ImplOf_IMockTypeOfChar()
    {
        var actual = Dm.Chars();

        Assert.IsAssignableFrom<IMockType<char>>(actual);
    }

    [Fact]
    public void When_Chars_Returns_MockTypeChar()
    {
        var actual = Dm.Chars();

        Assert.IsType<MockTypeChar>(actual);
    }

    [Fact]
    public void When_CharsGet_Returns_Char()
    {
        var actual = Dm.Chars().Get();

        Assert.IsType<char>(actual);
    }

    [Fact]
    public void When_CharsToList_Default_Size_Returns_ListOfChar()
    {
        var actual = Dm.Chars().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<char>>(actual);
    }

    [Fact]
    public void When_CharsToList_Size_0_Returns_EmptyListOfChar()
    {
        var actual = Dm.Chars().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<char>>(actual);
    }

    [Fact]
    public void When_CharsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Chars().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_CharsToList_With_Size_Returns_ListOfChar(int size)
    {
        var actual = Dm.Chars().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<char>>(actual);
    }

    [Fact]
    public void When_CharsFrom_With_Empty_Returns_TypeOf_MockTypeChar()
    {
        var actual = Dm.Chars().From([]);
        
        Assert.IsType<MockTypeChar>(actual);
    }
    
    [Fact]
    public void When_CharsFrom_With_Empty_Returns_Empty_Characters()
    {
        var actual = Dm.Chars().From([]).Characters;
        
        Assert.Equal([], actual);
    }
    
    [Fact]
    public void When_CharsFrom_With_SingleCharArray_Get_Returns_Expected_SingleChar()
    {
        var expected = 'a';
        var characters = new[] { expected };
            
        var actual = Dm.Chars().From(characters).Get();
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CharsFrom_With_SingleCharArray_Get_Returns_Expected_Characters()
    {
        var expected = new[] { 'a' };
        var characters = new[] { 'a' };
            
        var actual = Dm.Chars().From(characters).Characters;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CharsFrom_With_Characters_Get_Returns_Char_ContainedIn_Characters()
    {
        var characters = new[] { 'a', 'b', 'c' };
            
        var actual = Dm.Chars().From(characters).Get();
        
        Assert.Contains(actual, characters);
    }
    
    [Fact]
    public void When_CharsFrom_With_Characters_Returns_Expected_Characters()
    {
        var expected = new[] { 'a', 'b', 'c' };
        var characters = new[] { 'a', 'b', 'c' };
            
        var actual = Dm.Chars().From(characters).Characters;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CharsFromAndAnd_With_DuplicateCharacters_Returns_Expected_Characters()
    {
        var expected = new[] { 'a', 'b', 'c' };
        var characters = new[] { 'a', 'b', 'c' };
            
        var actual = Dm.Chars().From(characters).And(characters).Characters;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CharsFromAndAnd_BothWith_Characters_Returns_Expected_Characters()
    {
        var expected = new[] { 'a', 'b', 'c', 'd', 'e', 'f' };
        var abc = new[] { 'a', 'b', 'c' };
        var def = new[] { 'd', 'e', 'f' };
            
        var actual = Dm.Chars().From(abc).And(def).Characters;
        
        Assert.Equal(expected, actual);
    }
        
    [Fact]
    public void When_CharsFrom_With_CharBasicLatin_Get_Returns_Char_ContainedIn_CharBasicLatin()
    {
        var actual = Dm.Chars().From(Dm.Char.BasicLatin).Get();
        
        Assert.Contains(actual, Dm.Char.BasicLatin);
    }
            
    [Fact]
    public void When_CharsFrom_With_CharDigits_Get_Returns_Char_ContainedIn_CharDigits()
    {
        var actual = Dm.Chars().From(Dm.Char.Digits).Get();
        
        Assert.Contains(actual, Dm.Char.Digits);
    }
                
    [Fact]
    public void When_CharsFrom_With_CharUppercaseLetters_Get_Returns_Char_ContainedIn_CharUppercaseLetters()
    {
        var actual = Dm.Chars().From(Dm.Char.UppercaseLetters).Get();
        
        Assert.Contains(actual, Dm.Char.UppercaseLetters);
    }
                    
    [Fact]
    public void When_CharsFrom_With_CharLowercaseLetters_Get_Returns_Char_ContainedIn_CharLowercaseLetters()
    {
        var actual = Dm.Chars().From(Dm.Char.LowercaseLetters).Get();
        
        Assert.Contains(actual, Dm.Char.LowercaseLetters);
    }
                        
    [Fact]
    public void When_CharsFrom_With_CharCaseInsensitiveLetters_Get_Returns_Char_ContainedIn_CharCaseInsensitiveLetters()
    {
        var actual = Dm.Chars().From(Dm.Char.CaseInsensitiveLetters).Get();
        
        Assert.Contains(actual, Dm.Char.CaseInsensitiveLetters);
    }
                            
    [Fact]
    public void When_CharsFrom_With_CharAlphaNumeric_Get_Returns_Char_ContainedIn_CharAlphaNumeric()
    {
        var actual = Dm.Chars().From(Dm.Char.AlphaNumeric).Get();
        
        Assert.Contains(actual, Dm.Char.AlphaNumeric);
    }
                                
    [Fact]
    public void When_CharsFrom_With_CharSpecialSymbols_Get_Returns_Char_ContainedIn_CharSpecialSymbols()
    {
        var actual = Dm.Chars().From(Dm.Char.SpecialSymbols).Get();
        
        Assert.Contains(actual, Dm.Char.SpecialSymbols);
    }
                                    
    [Fact]
    public void When_CharsFrom_With_CharSpace_Get_Returns_Char_ContainedIn_CharSpace()
    {
        var actual = Dm.Chars().From(Dm.Char.Space).Get();
        
        Assert.Contains(actual, Dm.Char.Space);
    }
                                        
    [Fact]
    public void When_CharsExcluding_Returns_ImplOf_IMockTypeOfChar()
    {
        var actual = Dm.Chars().Excluding([]);
        
        Assert.IsAssignableFrom<IMockType<char>>(actual);
    }
    
    [Fact]
    public void When_CharsExcluding_Returns_MockTypeChar()
     {
         var actual = Dm.Chars().Excluding([]);
         
         Assert.IsType<MockTypeChar>(actual);
     }
        
    [Fact]
    public void When_CharsFromExcluding_Empty_Get_Returns_Char_ContainedIn_CharDigits()
    {
        var actual = Dm.Chars()
            .From(Dm.Char.Digits)
            .Excluding([]);
         
        Assert.IsType<MockTypeChar>(actual);
    }
            
    [Fact]
    public void When_CharsFromExcluding_SomeDigits_Get_Returns_Char_ContainedIn_CharDigits_Excluding_AsExpected()
    {
        var expected = Dm.Char.Digits.Except(['1', '2', '3']);
        
        var actual = Dm.Chars()
            .From(Dm.Char.Digits)
            .Excluding(['1', '2', '3'])
            .Get();
         
        Assert.Contains(actual, expected);
    }
}