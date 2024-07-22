namespace BrightSky.DataMock.Tests;

public class MockTypeShortTests
{
    [Fact]
    public void When_Shorts_Returns_ImplOf_IMockTypeOfShort()
    {
        var actual = Dm.Shorts();

        Assert.IsAssignableFrom<IMockType<short>>(actual);
    }
    
    [Fact]
    public void When_Shorts_Returns_MockTypeShort()
    {
        var actual = Dm.Shorts();

        Assert.IsType<MockTypeShort>(actual);
    }
    
    [Fact]
    public void When_ShortsGet_Returns_Short()
    {
        var actual = Dm.Shorts().Get();

        Assert.IsType<short>(actual);
    }
        
    [Fact]
    public void When_ShortsMax_Returns_MockTypeShort()
    {
        var actual = Dm.Shorts().Max(1);

        Assert.IsType<MockTypeShort>(actual);
    }  
    
    [Fact]
    public void When_ShortsMax_1_Get_Returns_Short()
    {
        var actual = Dm.Shorts().Max(1).Get();

        Assert.True(actual <= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_ShortsMax_With_MaxValue_Get_Returns_Short_LessThanOrEqualTo_MaxValue(short maxValue)
    {
        var actual = Dm.Shorts().Max(maxValue).Get();

        Assert.True(actual <= maxValue);
    }    
    
    [Fact]
    public void When_ShortsMin_Returns_MockTypeShort()
    {
        var actual = Dm.Shorts().Min(1);

        Assert.IsType<MockTypeShort>(actual);
    }  
    
    [Fact]
    public void When_ShortsMin_1_Get_Returns_Short()
    {
        var actual = Dm.Shorts().Min(1).Get();

        Assert.True(actual >= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_ShortsMin_With_MinValue_Get_Returns_Short_GreaterThanOrEqualTo_MinValue(short minValue)
    {
        var actual = Dm.Shorts().Min(minValue).Get();

        Assert.True(actual >= minValue);
    } 
    
    [Fact]
    public void When_ShortsToList_Default_Size_Returns_ListOfShort()
    {
        var actual = Dm.Shorts().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<short>>(actual);
    }
    
    [Fact]
    public void When_ShortsToList_Size_0_Returns_EmptyListOfShort()
    {
        var actual = Dm.Shorts().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<short>>(actual);
    }
    
    [Fact]
    public void When_ShortsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Shorts().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_ShortsToList_With_Size_Returns_ListOfShort(short size)
    {
        var actual = Dm.Shorts().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<short>>(actual);
    }
    
    [Fact]
    public void When_ShortsRange_With_MinValue_MaxValue_Returns_MockTypeShort()
    {
        var actual = Dm.Shorts().Range(1, 10);

        Assert.IsType<MockTypeShort>(actual);
    }
    
    [Theory]
    [InlineData(-150,-50)]
    [InlineData(-50,-10)]
    [InlineData(-10,-5)]
    [InlineData(-5,-3)]
    [InlineData(-3,-1)]
    [InlineData(-1,0)]
    [InlineData(0,0)]
    [InlineData(0,1)]
    [InlineData(1,3)]
    [InlineData(3,5)]
    [InlineData(5,10)]
    [InlineData(10,50)]
    [InlineData(50,150)]    
    public void When_ShortsRange_With_MinValue_MaxValue_Returns_Short_WithinRangeOf_MinValue_And_MaxValue(short minValue, short maxValue)
    {
        var actual = Dm.Shorts().Range(minValue, maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    }
    
    [Theory]
    [InlineData(-150,-50)]
    [InlineData(-50,-10)]
    [InlineData(-10,-5)]
    [InlineData(-5,-3)]
    [InlineData(-3,-1)]
    [InlineData(-1,0)]
    [InlineData(0,0)]
    [InlineData(0,1)]
    [InlineData(1,3)]
    [InlineData(3,5)]
    [InlineData(5,10)]
    [InlineData(10,50)]
    [InlineData(50,150)]    
    public void When_ShortsMinAndMaxAndGet_With_MinValue_MaxValue_Returns_Short_WithinRangeOf_MinValue_And_MaxValue(short minValue, short maxValue)
    {
        var actual = Dm.Shorts().Min(minValue).Max(maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    }

    [Fact]
    public void When_ShortsRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Shorts().Range(minValue: 100, maxValue: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_ShortsMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Shorts().Min(minValue: 100).Max(maxValue: 1).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
}