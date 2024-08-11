namespace BrightSky.DataMock.Tests;

public class MockTypeStringTests
{
    [Fact]
    public void When_Strings_Returns_ImplOf_IMockTypeOfString()
    {
        var actual = Dm.Strings();

        Assert.IsAssignableFrom<IMockType<string>>(actual);
    }
    
    [Fact]
    public void When_Strings_Returns_MockTypeString()
    {
        var actual = Dm.Strings();

        Assert.IsType<MockTypeString>(actual);
    }
    
    [Fact]
    public void When_StringsGet_Returns_String()
    {
        var actual = Dm.Strings().Get();

        Assert.IsType<string>(actual);
    }
    
    [Fact]
    public void When_Strings_Default_Length_Returns_DefaultLength()
    {
        var actual = Dm.Strings();

        Assert.Equal(10, actual.Length);
        Assert.IsType<MockTypeString>(actual);
    }
        
    [Fact]
    public void When_StringsGet_Default_Length_Returns_String_DefaultLength()
    {
        var actual = Dm.Strings().Get();

        Assert.Equal(10, actual.Length);
        Assert.IsType<string>(actual);
    }
    
    [Fact]
    public void When_StringsWithLength_With_Zero_Returns_ZeroLength()
    {
        var actual = Dm.Strings().WithLength(0);

        Assert.Equal(0, actual.Length);
    }
    
    [Fact]
    public void When_StringsWithLengthAndGet_With_Zero_Returns_String_ZeroLength()
    {
        var actual = Dm.Strings().WithLength(0).Get();

        Assert.Equal(0, actual.Length);
    }
    
    [Fact]
    public void When_StringsWithLengthAndGet_With_LessThanZero_Returns_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Strings().WithLength(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(13)]
    [InlineData(15)]
    [InlineData(50)]
    [InlineData(99)]
    [InlineData(100)]
    public void When_StringsWithLengthAndGet_With_Lengths_Returns_String_WithExpectedLength(int length)
    {
        var actual = Dm.Strings().WithLength(length).Get();

        Assert.Equal(length, actual.Length);
    }
    
    [Fact]
    public void When_StringsToList_Default_Size_Returns_ListOfString()
    {
        var actual = Dm.Strings().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<string>>(actual);
    }
    
    [Fact]
    public void When_StringsToList_Size_0_Returns_EmptyListOfString()
    {
        var actual = Dm.Strings().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<string>>(actual);
    }
    
    [Fact]
    public void When_StringsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Strings().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_StringsToList_With_Size_Returns_ListOfString(int size)
    {
        var actual = Dm.Strings().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<string>>(actual);
    }
    
    [Fact]
    public void When_StringsFrom_With_Empty_Returns_TypeOf_MockTypeString()
    {
        var actual = Dm.Strings().From([]);
        
        Assert.IsType<MockTypeString>(actual);
    }
    
    [Fact]
    public void When_StringsFrom_With_Empty_Returns_Empty_Characters()
    {
        var actual = Dm.Strings().From([]).Characters;
        
        Assert.Equal([], actual);
    }
        
    [Fact]
    public void When_StringsFrom_With_SingleCharArray_Get_Returns_Expected_SingleString()
    {
        var expected = "aaaaaaaaaa";
        var characters = new[] { 'a' };
            
        var actual = Dm.Strings().From(characters).Get();
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_StringsFrom_With_SingleCharArray_Get_Returns_Expected_Characters()
    {
        var expected = new[] { 'a' };
        var characters = new[] { 'a' };
            
        var actual = Dm.Strings().From(characters).Characters;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_StringsFrom_With_Characters_Get_Returns_StringWhereChars_ContainedIn_Characters()
    {
        var characters = new[] { 'a', 'b', 'c' };
            
        var actual = Dm.Strings().From(characters).Get();
        
        Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(characters).Count());
    }
        
    [Fact]
    public void When_StringsFrom_With_Characters_Returns_Expected_Characters()
    {
        var expected = new[] { 'a', 'b', 'c' };
        var characters = new[] { 'a', 'b', 'c' };
            
        var actual = Dm.Strings().From(characters).Characters;
        
        Assert.Equal(expected, actual);
    }
        
    [Fact]
    public void When_StringsFromAndAnd_With_DuplicateCharacters_Returns_Expected_Characters()
    {
        var expected = new[] { 'a', 'b', 'c' };
        var characters = new[] { 'a', 'b', 'c' };
            
        var actual = Dm.Strings().From(characters).And(characters).Characters;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_StringsFromAndAnd_BothWith_Characters_Returns_Expected_Characters()
    {
        var expected = new[] { 'a', 'b', 'c', 'd', 'e', 'f' };
        var abc = new[] { 'a', 'b', 'c' };
        var def = new[] { 'd', 'e', 'f' };
            
        var actual = Dm.Strings().From(abc).And(def).Characters;
        
        Assert.Equal(expected, actual);
    }
            
    [Fact]
    public void When_StringsFrom_With_CharBasicLatin_Get_Returns_String_Containing_CharBasicLatin()
    {
        var actual = Dm.Strings().From(Dm.Char.BasicLatin).Get();
        
        Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.BasicLatin).Count());
    }
    
    [Fact]
    public void When_StringsFrom_With_CharDigits_Get_Returns_String_Containing_CharDigits()
    {
        var actual = Dm.Strings().From(Dm.Char.Digits).Get();
        
        Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.BasicLatin).Count());
    }
                    
    [Fact]
    public void When_StringsFrom_With_CharUppercaseLetters_Get_Returns_String_Containing_CharUppercaseLetters()
    {
        var actual = Dm.Strings().From(Dm.Char.UppercaseLetters).Get();
        
        Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.UppercaseLetters).Count());
    }
                        
    [Fact]
    public void When_StringsFrom_With_CharLowercaseLetters_Get_Returns_String_Containing_CharLowercaseLetters()
    {
        var actual = Dm.Strings().From(Dm.Char.LowercaseLetters).Get();
        
        Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.LowercaseLetters).Count());
    }
    
    [Fact]
    public void When_StringsFrom_With_CharCaseInsensitiveLetters_Get_Returns_String_Containing_CharCaseInsensitiveLetters()
    {
        var actual = Dm.Strings().From(Dm.Char.CaseInsensitiveLetters).Get();
        
        Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.CaseInsensitiveLetters).Count());
    }
                            
    [Fact]
    public void When_StringsFrom_With_CharAlphaNumeric_Get_Returns_String_Containing_CharAlphaNumeric()
    {
        var actual = Dm.Strings().From(Dm.Char.AlphaNumeric).Get();
        
        Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.AlphaNumeric).Count());
    }
                                
    [Fact]
    public void When_StringsFrom_With_CharSpecialSymbols_Get_Returns_String_Containing_CharSpecialSymbols()
    {
        var actual = Dm.Strings().From(Dm.Char.SpecialSymbols).Get();
        
        Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.SpecialSymbols).Count());
    }
                                    
    [Fact]
    public void When_StringsFrom_With_CharSpace_Get_Returns_String_Containing_CharSpace()
    {
        var actual = Dm.Strings().From(Dm.Char.Space).Get();
        
        Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.Space).Count());
    }
    
    [Fact]
    public void When_StringsExcluding_Returns_ImplOf_IMockTypeOfString()
    {
        var actual = Dm.Strings().Excluding([]);
        
        Assert.IsAssignableFrom<IMockType<string>>(actual);
    }
    
    [Fact]
    public void When_StringsExcluding_Returns_MockTypeString()
    {
        var actual = Dm.Strings().Excluding([]);
         
        Assert.IsType<MockTypeString>(actual);
    }
    
    [Fact]
    public void When_StringsFromExcluding_Empty_Get_Returns_String_Containing_CharDigits()
    {
        var actual = Dm.Strings()
            .From(Dm.Char.Digits)
            .Excluding([])
            .Get();
         
        Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.Digits).Count());
    }
    
    [Fact]
    public void When_StringsFromExcluding_SomeDigits_Get_Returns_String_Containing_CharDigits_Excluding_AsExpected()
    {
        var expected = Dm.Char.Digits.Except(['1', '2', '3']);
        
        var actual = Dm.Strings()
            .From(Dm.Char.Digits)
            .Excluding(['1', '2', '3'])
            .Get();
         
        Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(expected).Count());
    }
    
    [Fact]
    public void When_Strings_Default_MinLength_Returns_DefaultMinLength()
    {
        var actual = Dm.Strings();

        Assert.Equal(10, actual.MinLength);
        Assert.IsType<MockTypeString>(actual);
    }
    
    [Fact]
    public void When_Strings_Default_MaxLength_Returns_DefaultMaxLength()
    {
        var actual = Dm.Strings();

        Assert.Equal(10, actual.MaxLength);
        Assert.IsType<MockTypeString>(actual);
    }
    
    [Fact]
    public void When_StringsWithLength_With_Zero_Returns_ZeroMinLength()
    {
        var actual = Dm.Strings().WithLength(0);

        Assert.Equal(0, actual.MinLength);
    }
    
    [Fact]
    public void When_StringsWithLength_With_Zero_Returns_ZeroMaxLength()
    {
        var actual = Dm.Strings().WithLength(0);

        Assert.Equal(0, actual.MaxLength);
    }
    
    [Fact]
    public void When_StringsWithVariableLength_With_MinLength_MaxLength_Returns_MockTypeString()
    {
        var actual = Dm.Strings().WithVariableLength(1, 10);

        Assert.IsType<MockTypeString>(actual);
    }
    
    [Fact]
    public void When_StringsWithVariableLength_With_MaxLength_LessThan_MinLength_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Strings().WithVariableLength(minLength: 100, maxLength: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_StringsWithVariableLength_With_MinLength_MaxLength_Returns_MinLength_AsExpected()
    {
        var minLength = 1;
        var maxLength = 10;
        var actual = Dm.Strings().WithVariableLength(minLength, maxLength);

        Assert.Equal(minLength, actual.MinLength);
    }
        
    [Fact]
    public void When_StringsWithVariableLength_With_MinLength_MaxLength_Returns_MaxLength_AsExpected()
    {
        var minLength = 1;
        var maxLength = 10;
        var actual = Dm.Strings().WithVariableLength(minLength, maxLength);

        Assert.Equal(maxLength, actual.MaxLength);
    }
    
    [Fact]
    public void When_StringsWithVariableLength_With_MinLength_MaxLength_Returns_StringLength_AsExpected()
    {
        var minLength = 1;
        var maxLength = 10;
        var actual = Dm.Strings().WithVariableLength(minLength, maxLength).Get();

        Assert.True(actual.Length >= minLength && actual.Length <= maxLength);
    }
        
    [Theory]
    [InlineData(0,0)]
    [InlineData(0,1)]
    [InlineData(1,3)]
    [InlineData(3,5)]
    [InlineData(5,10)]
    [InlineData(10,50)]
    [InlineData(50,150)] 
    public void When_StringsWithVariableLength_With_MinLength_MaxLength_Returns_StringLength_WithinRangeOf_MinLength_MaxLength(int minLength, int maxLength)
    {
        var actual = Dm.Strings().WithVariableLength(minLength, maxLength).Get();

        Assert.True(actual.Length >= minLength && actual.Length <= maxLength);
    }
}