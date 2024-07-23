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
    public void When_NullableCharsMax_Returns_MockTypeNullableChar()
    {
        var actual = Dm.NullableChars().Max(1);

        Assert.IsType<MockTypeNullableChar>(actual);
    }
    
    [Fact]
    public void When_NullableCharsMax_1_Get_Returns_NullableChar()
    {
        var actual = Dm.NullableChars().Max(1).Get();

        Assert.True(actual is not > (char)1);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableCharsMax_With_MaxValue_Get_Returns_NullableChar_LessThanOrEqualTo_MaxValue(byte maxValue)
    {
        var actual = Dm.NullableChars().Max(maxValue).Get();

        Assert.True(!actual.HasValue || actual.Value < maxValue);
    }   
    
    [Fact]
    public void When_NullableCharsMin_Returns_MockTypeNullableChar()
    {
        var actual = Dm.NullableChars().Min(1);

        Assert.IsType<MockTypeNullableChar>(actual);
    } 
    
    [Fact]
    public void When_NullableCharsMin_1_Get_Returns_NullableChar()
    {
        var actual = Dm.NullableChars().Min(1).Get();

        Assert.True(actual is not < (char)1);
    }
    
    [Fact]
    public void When_NullableCharsMin_With_MinValue_LessThanZero_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableChars().Min(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void When_NullableCharsMin_With_MinValue_CharMinValue_And_NullableProbability_0_Get_Returns_GreaterThanOrEqualTo_MinValue()
    {
        var actual = Dm.NullableChars().NullableProbability(0).Min(char.MinValue).Get();

        Assert.True(actual >= char.MinValue);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableCharsMin_With_MinValue_Get_Returns_NullableChar_GreaterThanOrEqualTo_MinValue(byte minValue)
    {
        var actual = Dm.NullableChars().Min(minValue).Get();

        Assert.True(!actual.HasValue || actual.Value >= minValue);
    }
    
    [Fact]
    public void When_NullableCharsToList_Default_Size_Returns_ListOfNullableChar()
    {
        var actual = Dm.NullableChars().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<byte?>>(actual);
    }
    
    [Fact]
    public void When_NullableCharsToList_Size_0_Returns_EmptyListOfNullableChar()
    {
        var actual = Dm.NullableChars().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<byte?>>(actual);
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
        Assert.IsType<List<byte?>>(actual);
    }
    
    [Fact]
    public void When_NullableCharsRange_With_MinValue_MaxValue_Returns_MockTypeNullableChar()
    {
        var actual = Dm.NullableChars().Range(1, 10);

        Assert.IsType<MockTypeNullableChar>(actual);
    }
    
    
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(0,1)]
    [InlineData(1,3)]
    [InlineData(3,5)]
    [InlineData(5,10)]
    [InlineData(10,50)]
    [InlineData(50,150)]    
    [InlineData(97,150)]    
    [InlineData(98,150)]    
    [InlineData(99,150)]    
    [InlineData(100,150)]    
    [InlineData(101,150)]    
    [InlineData(103,150)]    
    [InlineData(105,150)]    
    [InlineData(197,255)]    
    [InlineData(198,255)]    
    [InlineData(199,255)]
    [InlineData(201,255)]    
    [InlineData(203,255)]    
    [InlineData(205,255)]    
    [InlineData(247,255)]    
    [InlineData(248,255)]    
    [InlineData(253,255)]  
    [InlineData(254,255)]  
    public void When_NullableCharsRange_With_MinValue_MaxValue_Returns_NullableChar_WithinRangeOf_MinValue_And_MaxValue(byte minValue, byte maxValue)
    {
        var actual = Dm.NullableChars().Range(minValue, maxValue).Get();

        Assert.True(!actual.HasValue || actual.Value >= minValue && actual.Value <= maxValue);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(0,1)]
    [InlineData(1,3)]
    [InlineData(3,5)]
    [InlineData(5,10)]
    [InlineData(10,50)]
    [InlineData(50,150)]    
    [InlineData(97,150)]    
    [InlineData(98,150)]    
    [InlineData(99,150)]    
    [InlineData(100,150)]    
    [InlineData(101,150)]    
    [InlineData(103,150)]    
    [InlineData(105,150)]    
    [InlineData(197,255)]    
    [InlineData(198,255)]    
    [InlineData(199,255)]
    [InlineData(201,255)]    
    [InlineData(203,255)]    
    [InlineData(205,255)]    
    [InlineData(247,255)]    
    [InlineData(248,255)]    
    [InlineData(253,255)]  
    [InlineData(254,255)]   
    public void When_NullableCharsMinAndMaxAndGet_With_MinValue_MaxValue_Returns_NullableChar_WithinRangeOf_MinValue_And_MaxValue(byte minValue, byte maxValue)
    {
        var actual = Dm.NullableChars().Min(minValue).Max(maxValue).Get();

        Assert.True(!actual.HasValue || actual.Value >= minValue && actual.Value <= maxValue);
    }
    
    [Fact]
    public void When_NullableCharsRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableChars().Range(minValue: 100, maxValue: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableCharsMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableChars().Min(minValue: 100).Max(maxValue: 1).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
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
    public void When_NullableCharsRange_With_MaxValue_GreaterThanCharMaxValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableChars().Range(minValue: char.MinValue, maxValue: char.MaxValue+1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
        
    [Fact]
    public void When_NullableCharsRange_With_MinValue_LessThanCharMinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableChars().Range(minValue: char.MinValue-1, maxValue: char.MaxValue);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
}