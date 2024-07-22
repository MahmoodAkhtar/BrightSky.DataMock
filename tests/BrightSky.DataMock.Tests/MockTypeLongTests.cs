namespace BrightSky.DataMock.Tests;

public class MockTypeLongTests
{
    [Fact]
    public void When_Longs_Returns_ImplOf_IMockTypeOfInt()
    {
        var actual = Dm.Longs();

        Assert.IsAssignableFrom<IMockType<long>>(actual);
    }
    
    [Fact]
    public void When_Longs_Returns_MockTypeLong()
    {
        var actual = Dm.Longs();

        Assert.IsType<MockTypeLong>(actual);
    }
    
    [Fact]
    public void When_LongsGet_Returns_Long()
    {
        var actual = Dm.Longs().Get();

        Assert.IsType<long>(actual);
    }
        
    [Fact]
    public void When_LongsMax_Returns_MockTypeLong()
    {
        var actual = Dm.Longs().Max(1);

        Assert.IsType<MockTypeLong>(actual);
    }  
    
    [Fact]
    public void When_LongsMax_1_Get_Returns_Long()
    {
        var actual = Dm.Longs().Max(1).Get();

        Assert.True(actual <= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_LongsMax_With_MaxValue_Get_Returns_Long_LessThanOrEqualTo_MaxValue(long maxValue)
    {
        var actual = Dm.Longs().Max(maxValue).Get();

        Assert.True(actual <= maxValue);
    }    
    
    [Fact]
    public void When_LongsMin_Returns_MockTypeLong()
    {
        var actual = Dm.Longs().Min(1);

        Assert.IsType<MockTypeLong>(actual);
    }  
    
    [Fact]
    public void When_LongsMin_1_Get_Returns_Long()
    {
        var actual = Dm.Longs().Min(1).Get();

        Assert.True(actual >= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_LongsMin_With_MinValue_Get_Returns_Long_GreaterThanOrEqualTo_MinValue(long minValue)
    {
        var actual = Dm.Longs().Min(minValue).Get();

        Assert.True(actual >= minValue);
    } 
    
    [Fact]
    public void When_LongsToList_Default_Size_Returns_ListOfLong()
    {
        var actual = Dm.Longs().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<long>>(actual);
    }
    
    [Fact]
    public void When_LongsToList_Size_0_Returns_EmptyListOfLong()
    {
        var actual = Dm.Longs().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<long>>(actual);
    }
    
    [Fact]
    public void When_LongsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Longs().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_LongsToList_With_Size_Returns_ListOfLong(int size)
    {
        var actual = Dm.Longs().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<long>>(actual);
    }
    
    [Fact]
    public void When_LongsRange_With_MinValue_MaxValue_Returns_MockTypeLong()
    {
        var actual = Dm.Longs().Range(1, 10);

        Assert.IsType<MockTypeLong>(actual);
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
    public void When_LongsRange_With_MinValue_MaxValue_Returns_Long_WithinRangeOf_MinValue_And_MaxValue(long minValue, long maxValue)
    {
        var actual = Dm.Longs().Range(minValue, maxValue).Get();

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
    public void When_LongsMinAndMaxAndGet_With_MinValue_MaxValue_Returns_Long_WithinRangeOf_MinValue_And_MaxValue(long minValue, long maxValue)
    {
        var actual = Dm.Longs().Min(minValue).Max(maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    }

    [Fact]
    public void When_LongsRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Longs().Range(minValue: 100, maxValue: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_LongsMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Longs().Min(minValue: 100).Max(maxValue: 1).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
}