namespace BrightSky.DataMock.Tests;

public class MockTypeDoubleTests
{
    [Fact]
    public void When_Doubles_Returns_ImplOf_IMockTypeOfDouble()
    {
        var actual = Dm.Doubles();

        Assert.IsAssignableFrom<IMockType<double>>(actual);
    }
    
    [Fact]
    public void When_Doubles_Returns_MockTypeDouble()
    {
        var actual = Dm.Doubles();

        Assert.IsType<MockTypeDouble>(actual);
    }
    
    [Fact]
    public void When_DoublesGet_Returns_Double()
    {
        var actual = Dm.Doubles().Get();

        Assert.IsType<double>(actual);
    }
        
    [Fact]
    public void When_DoublesMax_Returns_MockTypeDouble()
    {
        var actual = Dm.Doubles().Max(1);

        Assert.IsType<MockTypeDouble>(actual);
    }  
    
    [Fact]
    public void When_DoublesMax_1_Get_Returns_Double()
    {
        var actual = Dm.Doubles().Max(1).Get();

        Assert.True(actual <= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_DoublesMax_With_MaxValue_Get_Returns_Double_LessThanOrEqualTo_MaxValue(double maxValue)
    {
        var actual = Dm.Doubles().Max(maxValue).Get();

        Assert.True(actual <= maxValue);
    }    
    
    [Fact]
    public void When_DoublesMin_Returns_MockTypeDouble()
    {
        var actual = Dm.Doubles().Min(1);

        Assert.IsType<MockTypeDouble>(actual);
    }  
    
    [Fact]
    public void When_DoublesMin_1_Get_Returns_Double()
    {
        var actual = Dm.Doubles().Min(1).Get();

        Assert.True(actual >= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_DoublesMin_With_MinValue_Get_Returns_Double_GreaterThanOrEqualTo_MinValue(double minValue)
    {
        var actual = Dm.Doubles().Min(minValue).Get();

        Assert.True(actual >= minValue);
    } 
    
    [Fact]
    public void When_DoublesToList_Default_Size_Returns_ListOfDouble()
    {
        var actual = Dm.Doubles().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<double>>(actual);
    }
    
    [Fact]
    public void When_DoublesToList_Size_0_Returns_EmptyListOfDouble()
    {
        var actual = Dm.Doubles().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<double>>(actual);
    }
    
    [Fact]
    public void When_DoublesToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Doubles().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_DoublesToList_With_Size_Returns_ListOfDouble(int size)
    {
        var actual = Dm.Doubles().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<double>>(actual);
    }
    
    [Fact]
    public void When_DoublesRange_With_MinValue_MaxValue_Returns_MockTypeDouble()
    {
        var actual = Dm.Doubles().Range(1, 10);

        Assert.IsType<MockTypeDouble>(actual);
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
    public void When_DoublesRange_With_MinValue_MaxValue_Returns_Double_WithinRangeOf_MinValue_And_MaxValue(double minValue, double maxValue)
    {
        var actual = Dm.Doubles().Range(minValue, maxValue).Get();

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
    public void When_DoublesMinAndMaxAndGet_With_MinValue_MaxValue_Returns_Double_WithinRangeOf_MinValue_And_MaxValue(double minValue, double maxValue)
    {
        var actual = Dm.Doubles().Min(minValue).Max(maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    }

    [Fact]
    public void When_DoublesRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Doubles().Range(minValue: 100, maxValue: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_DoublesMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Doubles().Min(minValue: 100).Max(maxValue: 1).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
}