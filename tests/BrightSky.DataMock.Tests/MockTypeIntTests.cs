namespace BrightSky.DataMock.Tests;

public class MockTypeIntTests
{
    [Fact]
    public void When_Ints_Returns_ImplOf_IMockTypeOfInt()
    {
        var actual = Dm.Ints();

        Assert.IsAssignableFrom<IMockType<int>>(actual);
    }
    
    [Fact]
    public void When_Ints_Returns_MockTypeInt()
    {
        var actual = Dm.Ints();

        Assert.IsType<MockTypeInt>(actual);
    }
    
    [Fact]
    public void When_IntsGet_Returns_Int()
    {
        var actual = Dm.Ints().Get();

        Assert.IsType<int>(actual);
    }
        
    [Fact]
    public void When_IntsMax_Returns_MockTypeInt()
    {
        var actual = Dm.Ints().Max(1);

        Assert.IsType<MockTypeInt>(actual);
    }  
    
    [Fact]
    public void When_IntsMax_1_Get_Returns_Int()
    {
        var actual = Dm.Ints().Max(1).Get();

        Assert.True(actual <= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_IntsMax_With_MaxValue_Get_Returns_Int_LessThanOrEqualTo_MaxValue(int maxValue)
    {
        var actual = Dm.Ints().Max(maxValue).Get();

        Assert.True(actual <= maxValue);
    }    
    
    [Fact]
    public void When_IntsMin_Returns_MockTypeInt()
    {
        var actual = Dm.Ints().Min(1);

        Assert.IsType<MockTypeInt>(actual);
    }  
    
    [Fact]
    public void When_IntsMin_1_Get_Returns_Int()
    {
        var actual = Dm.Ints().Min(1).Get();

        Assert.True(actual >= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_IntsMin_With_MinValue_Get_Returns_Int_GreaterThanOrEqualTo_MinValue(int minValue)
    {
        var actual = Dm.Ints().Min(minValue).Get();

        Assert.True(actual >= minValue);
    } 
    
    [Fact]
    public void When_IntsToList_Default_Size_Returns_ListOfInt()
    {
        var actual = Dm.Ints().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<int>>(actual);
    }
    
    [Fact]
    public void When_IntsToList_Size_0_Returns_EmptyListOfInt()
    {
        var actual = Dm.Ints().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<int>>(actual);
    }
    
    [Fact]
    public void When_IntsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Ints().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_IntsToList_With_Size_Returns_ListOfInt(int size)
    {
        var actual = Dm.Ints().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<int>>(actual);
    }
    
    [Fact]
    public void When_IntsRange_With_MinValue_MaxValue_Returns_MockTypeInt()
    {
        var actual = Dm.Ints().Range(1, 10);

        Assert.IsType<MockTypeInt>(actual);
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
    public void When_IntsRange_With_MinValue_MaxValue_Returns_Int_WithinRangeOf_MinValue_And_MaxValue(int minValue, int maxValue)
    {
        var actual = Dm.Ints().Range(minValue, maxValue).Get();

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
    public void When_IntsMinAndMaxAndGet_With_MinValue_MaxValue_Returns_Int_WithinRangeOf_MinValue_And_MaxValue(int minValue, int maxValue)
    {
        var actual = Dm.Ints().Min(minValue).Max(maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    }

    [Fact]
    public void When_IntsRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Ints().Range(minValue: 100, maxValue: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_IntsMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Ints().Min(minValue: 100).Max(maxValue: 1).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
}