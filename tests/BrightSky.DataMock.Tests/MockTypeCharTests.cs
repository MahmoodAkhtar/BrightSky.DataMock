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
    public void When_CharsMax_Returns_MockTypeChar()
    {
        var actual = Dm.Chars().Max(1);

        Assert.IsType<MockTypeChar>(actual);
    }

    [Fact]
    public void When_CharsMax_1_Get_Returns_Char()
    {
        var actual = Dm.Chars().Max(1).Get();

        Assert.True(actual <= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_CharsMax_With_MaxValue_Get_Returns_Char_LessThanOrEqualTo_MaxValue(char maxValue)
    {
        var actual = Dm.Chars().Max(maxValue).Get();

        Assert.True(actual <= maxValue);
    }

    [Fact]
    public void When_CharsMax_With_MaxValue_GreaterThanCharMaxValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Chars().Max(char.MaxValue + 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void When_CharsMax_With_MaxValue_CharMaxValue_Get_Returns_LessThanOrEqualTo_MaxValue()
    {
        var actual = Dm.Chars().Max(char.MaxValue).Get();

        Assert.True(actual <= char.MaxValue);
    }

    [Fact]
    public void When_CharsMin_Returns_MockTypeChar()
    {
        var actual = Dm.Chars().Min(1);

        Assert.IsType<MockTypeChar>(actual);
    }

    [Fact]
    public void When_CharsMin_1_Get_Returns_Char()
    {
        var actual = Dm.Chars().Min(1).Get();

        Assert.True(actual >= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_CharsMin_With_MinValue_Get_Returns_Char_GreaterThanOrEqualTo_MinValue(char minValue)
    {
        var actual = Dm.Chars().Min(minValue).Get();

        Assert.True(actual >= minValue);
    }

    [Fact]
    public void When_CharsMin_With_MinValue_LessThanZero_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Chars().Min(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void When_CharsMin_With_MinValue_CharMinValue_Get_Returns_GreaterThanOrEqualTo_MinValue()
    {
        var actual = Dm.Chars().Min(char.MinValue).Get();

        Assert.True(actual >= char.MinValue);
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
    public void When_CharsRange_With_MinValue_MaxValue_Returns_MockTypeChar()
    {
        var actual = Dm.Chars().Range(1, 10);

        Assert.IsType<MockTypeChar>(actual);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 1)]
    [InlineData(1, 3)]
    [InlineData(3, 5)]
    [InlineData(5, 10)]
    [InlineData(10, 50)]
    [InlineData(50, 150)]
    public void When_CharsRange_With_MinValue_MaxValue_Returns_Char_WithinRangeOf_MinValue_And_MaxValue(char minValue,
        char maxValue)
    {
        var actual = Dm.Chars().Range(minValue, maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 1)]
    [InlineData(1, 3)]
    [InlineData(3, 5)]
    [InlineData(5, 10)]
    [InlineData(10, 50)]
    [InlineData(50, 150)]
    public void When_CharsMinAndMaxAndGet_With_MinValue_MaxValue_Returns_Char_WithinRangeOf_MinValue_And_MaxValue(
        char minValue, char maxValue)
    {
        var actual = Dm.Chars().Min(minValue).Max(maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    }

    [Fact]
    public void When_CharsRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Chars().Range(minValue: 100, maxValue: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void When_CharsMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Chars().Min(minValue: 100).Max(maxValue: 1).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_CharsRange_With_MaxValue_GreaterThanCharMaxValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Chars().Range(minValue: char.MinValue, maxValue: char.MaxValue+1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
        
    [Fact]
    public void When_CharsRange_With_MinValue_LessThanCharMinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Chars().Range(minValue: char.MinValue-1, maxValue: char.MaxValue);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
}