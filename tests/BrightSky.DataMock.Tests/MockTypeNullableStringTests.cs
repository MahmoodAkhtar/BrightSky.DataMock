namespace BrightSky.DataMock.Tests;

public class MockTypeNullableStringTests
{
    [Fact]
    public void When_NullableStrings_Returns_ImplOf_IMockTypeOfNullableString()
    {
        var actual = Dm.NullableStrings();

        Assert.IsAssignableFrom<IMockType<string?>>(actual);
    }
        
    [Fact]
    public void When_NullableStrings_Returns_MockTypeNullableString()
    {
        var actual = Dm.NullableStrings();

        Assert.IsType<MockTypeNullableString>(actual);
    }
        
    [Fact]
    public void When_NullableStringsGet_Returns_NullableString()
    {
        var actual = Dm.NullableStrings().Get();

        Assert.True(Test.IsNullable(actual));
    }
    
    [Fact]
    public void When_NullableStringsToList_Default_Size_Returns_ListOfNullableString()
    {
        var actual = Dm.NullableStrings().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<string?>>(actual);
    }
    
    [Fact]
    public void When_NullableStringsToList_Size_0_Returns_EmptyListOfNullableString()
    {
        var actual = Dm.NullableStrings().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<string?>>(actual);
    }
    
    [Fact]
    public void When_NullableStringsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.NullableStrings().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableStringsToList_With_Size_Returns_ListOfNullableString(int size)
    {
        var actual = Dm.NullableStrings().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<string?>>(actual);
    }
        
    [Fact]
    public void When_NullableStringsNullableProbability_Returns_MockTypeNullableString()
    {
        var actual = Dm.NullableStrings().NullableProbability(1);

        Assert.IsType<MockTypeNullableString>(actual);
    }
        
    [Fact]
    public void When_NullableStringsNullableProbability_NullablePercentage_LessThanZero_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableStrings().NullableProbability(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableStringsNullableProbability_NullablePercentage_GreaterThanOneHundred_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableStrings().NullableProbability(101);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableStringsNullableProbability_With_0_NeverReturns_Null()
    {
        var actual = Dm.NullableStrings().NullableProbability(0).ToList();

        Assert.True(actual.All(x => x is not null));
    }
        
    [Fact]
    public void When_NullableStringsNullableProbability_With_100_Returns_AlwaysNull()
    {
        var actual = Dm.NullableStrings().NullableProbability(100).ToList();

        Assert.True(actual.All(x => x is null));
    }
        
    [Fact]
    public void When_NullableStringsToList_With_DefaultNullableProbability_Returns_Null_50Percent()
    {
        var actual = Dm.NullableStrings().ToList();

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
    public void When_NullableStringsNullableProbabilityAndToList_With_NullablePercentage_And_Size_Returns_ExpectedNullCount(int nullablePercentage, int size)
    {
        var expected = (int)Math.Ceiling(size * (nullablePercentage / 100.0m));
        var actual = Dm.NullableStrings().NullableProbability(nullablePercentage).ToList(size);

        Assert.Equal(expected, actual.Count(x => x is null));
    }

    [Fact]
    public void When_NullableStringsFromAndAnd_With_DuplicateCharacters_Returns_Expected_Characters()
    {
        var expected = new[] { 'a', 'b', 'c' };
        var characters = new[] { 'a', 'b', 'c' };
            
        var actual = Dm.NullableStrings().From(characters).And(characters).Characters;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_NullableStringsFromAndAnd_BothWith_Characters_Returns_Expected_Characters()
    {
        var expected = new[] { 'a', 'b', 'c', 'd', 'e', 'f' };
        var abc = new[] { 'a', 'b', 'c' };
        var def = new[] { 'd', 'e', 'f' };
            
        var actual = Dm.NullableStrings().From(abc).And(def).Characters;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_NullableStringsFrom_With_CharBasicLatin_Get_Returns_String_Containing_CharBasicLatin_OrIsNull()
    {
        var actual = Dm.NullableStrings().From(Dm.Char.BasicLatin).Get();
    
        if (actual is not null)
            Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.BasicLatin).Count());
    }
    
    [Fact]
    public void When_NullableStringsFrom_With_CharDigits_Get_Returns_String_Containing_CharDigits_OrIsNull()
    {
        var actual = Dm.NullableStrings().From(Dm.Char.Digits).Get();
        
        if (actual is not null)
            Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.Digits).Count());
    }
    
    [Fact]
    public void When_NullableStringsFrom_With_CharUppercaseLetters_Get_Returns_String_Containing_CharUppercaseLetters_OrIsNull()
    {
        var actual = Dm.NullableStrings().From(Dm.Char.UppercaseLetters).Get();
        
        if (actual is not null)
            Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.UppercaseLetters).Count());
    }
    
    [Fact]
    public void When_NullableStringsFrom_With_CharLowercaseLetters_Get_Returns_String_Containing_CharLowercaseLetters_OrIsNull()
    {
        var actual = Dm.NullableStrings().From(Dm.Char.LowercaseLetters).Get();
        
        if (actual is not null)
            Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.LowercaseLetters).Count());
    }
    
    [Fact]
    public void When_NullableStringsFrom_With_CharCaseInsensitiveLetters_Get_Returns_String_Containing_CharCaseInsensitiveLetters_OrIsNull()
    {
        var actual = Dm.NullableStrings().From(Dm.Char.CaseInsensitiveLetters).Get();
        
        if (actual is not null)
            Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.CaseInsensitiveLetters).Count());
    }
    
    [Fact]
    public void When_NullableStringsFrom_With_CharAlphaNumeric_Get_Returns_String_Containing_CharAlphaNumeric_OrIsNull()
    {
        var actual = Dm.NullableStrings().From(Dm.Char.AlphaNumeric).Get();
        
        if (actual is not null)
            Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.AlphaNumeric).Count());
    }
    
    [Fact]
    public void When_NullableStringsFrom_With_CharSpecialSymbols_Get_Returns_String_Containing_CharSpecialSymbols_OrIsNull()
    {
        var actual = Dm.NullableStrings().From(Dm.Char.SpecialSymbols).Get();
        
        if (actual is not null)
            Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.SpecialSymbols).Count());
    }
    
    [Fact]
    public void When_NullableStringsExcluding_Returns_ImplOf_IMockTypeOfNullableString()
    {
        var actual = Dm.NullableStrings().Excluding([]);
        
        Assert.IsAssignableFrom<IMockType<string?>>(actual);
    }
    
    [Fact]
    public void When_NullableStringsExcluding_Returns_MockTypeNullableString()
    {
        var actual = Dm.NullableStrings().Excluding([]);
         
        Assert.IsType<MockTypeNullableString>(actual);
    }
    
    [Fact]
    public void When_NullableStringsFromExcluding_Empty_Get_Returns_String_Containing_CharDigits_OrIsNull()
    {
        var actual = Dm.NullableStrings()
            .From(Dm.Char.Digits)
            .Excluding([])
            .Get();
         
        if (actual is not null)
            Assert.Equal(actual.Distinct().Count(), actual.ToArray().Intersect(Dm.Char.Digits).Count());
    }
    
    [Fact]
    public void When_NullableStrings_Default_Length_Returns_DefaultLength()
    {
        var actual = Dm.NullableStrings();

        if (actual is not null)
        {
            Assert.Equal(10, actual.Length);
            Assert.IsType<MockTypeNullableString>(actual);
        }
    }
    
    [Fact]
    public void When_NullableStringsGet_Default_Length_Returns_String_DefaultLength()
    {
        var actual = Dm.NullableStrings().Get();

        if (actual is not null)
        {
            Assert.Equal(10, actual.Length);
            Assert.IsType<string>(actual);
        }
    }
    
    [Fact]
    public void When_NullableStringsWithLength_With_Zero_Returns_ZeroLength()
    {
        var actual = Dm.NullableStrings().WithLength(0);

        Assert.Equal(0, actual.Length);
    }
    
    [Fact]
    public void When_NullableStringsWithLengthAndGet_With_Zero_Returns_String_ZeroLength()
    {
        var actual = Dm.NullableStrings().WithLength(0).Get();

        if (actual is not null)
        {
            Assert.Equal(0, actual.Length);
        }
    }
    
    [Fact]
    public void When_NullableStringsWithLengthAndGet_With_LessThanZero_Returns_ArgumentOutOfRangeException()
    {
        var action = () => Dm.NullableStrings().WithLength(-1);

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
    public void When_NullableStringsWithLengthAndGet_With_Lengths_Returns_String_WithExpectedLength(int length)
    {
        var actual = Dm.NullableStrings().WithLength(length).Get();

        if (actual is not null)
        {
            Assert.Equal(length, actual.Length);
        }
    }
}