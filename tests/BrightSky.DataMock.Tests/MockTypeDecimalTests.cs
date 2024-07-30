namespace BrightSky.DataMock.Tests;

public class MockTypeDecimalTests
{
    [Fact]
    public void When_Decimals_Returns_ImplOf_IMockTypeOfDecimal()
    {
        var actual = Dm.Decimals();

        Assert.IsAssignableFrom<IMockType<decimal>>(actual);
    }
    
    [Fact]
    public void When_Decimals_Returns_MockTypeDecimal()
    {
        var actual = Dm.Decimals();

        Assert.IsType<MockTypeDecimal>(actual);
    }
    
    [Fact]
    public void When_DecimalsGet_Returns_Decimal()
    {
        var actual = Dm.Decimals().Get();

        Assert.IsType<decimal>(actual);
    }
        
    [Fact]
    public void When_DecimalsMax_Returns_MockTypeDecimal()
    {
        var actual = Dm.Decimals().Max(1);

        Assert.IsType<MockTypeDecimal>(actual);
    }  
    
    [Fact]
    public void When_DecimalsMax_1_Get_Returns_Decimal()
    {
        var actual = Dm.Decimals().Max(1).Get();

        Assert.True(actual <= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_DecimalsMax_With_MaxValue_Get_Returns_Decimal_LessThanOrEqualTo_MaxValue(decimal maxValue)
    {
        var actual = Dm.Decimals().Max(maxValue).Get();

        Assert.True(actual <= maxValue);
    }    
    
    [Fact]
    public void When_DecimalsMin_Returns_MockTypeDecimal()
    {
        var actual = Dm.Decimals().Min(1);

        Assert.IsType<MockTypeDecimal>(actual);
    }  
    
    [Fact]
    public void When_DecimalsMin_1_Get_Returns_Decimal()
    {
        var actual = Dm.Decimals().Min(1).Get();

        Assert.True(actual >= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_DecimalsMin_With_MinValue_Get_Returns_Decimal_GreaterThanOrEqualTo_MinValue(decimal minValue)
    {
        var actual = Dm.Decimals().Min(minValue).Get();

        Assert.True(actual >= minValue);
    } 
    
    [Fact]
    public void When_DecimalsToList_Default_Size_Returns_ListOfDecimal()
    {
        var actual = Dm.Decimals().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<decimal>>(actual);
    }
    
    [Fact]
    public void When_DecimalsToList_Size_0_Returns_EmptyListOfDecimal()
    {
        var actual = Dm.Decimals().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<decimal>>(actual);
    }
    
    [Fact]
    public void When_DecimalsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Decimals().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_DecimalsToList_With_Size_Returns_ListOfDecimal(int size)
    {
        var actual = Dm.Decimals().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<decimal>>(actual);
    }
    
    [Fact]
    public void When_DecimalsRange_With_MinValue_MaxValue_Returns_MockTypeDecimal()
    {
        var actual = Dm.Decimals().Range(1, 10);

        Assert.IsType<MockTypeDecimal>(actual);
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
    public void When_DecimalsRange_With_MinValue_MaxValue_Returns_Decimal_WithinRangeOf_MinValue_And_MaxValue(decimal minValue, decimal maxValue)
    {
        var actual = Dm.Decimals().Range(minValue, maxValue).Get();

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
    public void When_DecimalsMinAndMaxAndGet_With_MinValue_MaxValue_Returns_Decimal_WithinRangeOf_MinValue_And_MaxValue(decimal minValue, decimal maxValue)
    {
        var actual = Dm.Decimals().Min(minValue).Max(maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    }

    [Fact]
    public void When_DecimalsRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Decimals().Range(minValue: 100, maxValue: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_DecimalsMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Decimals().Min(minValue: 100).Max(maxValue: 1).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
}