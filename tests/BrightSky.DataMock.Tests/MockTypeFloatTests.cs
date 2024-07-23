namespace BrightSky.DataMock.Tests;

public class MockTypeFloatTests
{
    [Fact]
    public void When_Floats_Returns_ImplOf_IMockTypeOfFloat()
    {
        var actual = Dm.Floats();

        Assert.IsAssignableFrom<IMockType<float>>(actual);
    }
    
    [Fact]
    public void When_Floats_Returns_MockTypeFloat()
    {
        var actual = Dm.Floats();

        Assert.IsType<MockTypeFloat>(actual);
    }
    
    [Fact]
    public void When_FloatsGet_Returns_Float()
    {
        var actual = Dm.Floats().Get();

        Assert.IsType<float>(actual);
    }
        
    [Fact]
    public void When_FloatsMax_Returns_MockTypeFloat()
    {
        var actual = Dm.Floats().Max(1);

        Assert.IsType<MockTypeFloat>(actual);
    }  
    
    [Fact]
    public void When_FloatsMax_1_Get_Returns_Float()
    {
        var actual = Dm.Floats().Max(1).Get();

        Assert.True(actual <= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_FloatsMax_With_MaxValue_Get_Returns_Float_LessThanOrEqualTo_MaxValue(float maxValue)
    {
        var actual = Dm.Floats().Max(maxValue).Get();

        Assert.True(actual <= maxValue);
    }    
    
    [Fact]
    public void When_FloatsMin_Returns_MockTypeFloat()
    {
        var actual = Dm.Floats().Min(1);

        Assert.IsType<MockTypeFloat>(actual);
    }  
    
    [Fact]
    public void When_FloatsMin_1_Get_Returns_Float()
    {
        var actual = Dm.Floats().Min(1).Get();

        Assert.True(actual >= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_FloatsMin_With_MinValue_Get_Returns_Float_GreaterThanOrEqualTo_MinValue(float minValue)
    {
        var actual = Dm.Floats().Min(minValue).Get();

        Assert.True(actual >= minValue);
    } 
    
    [Fact]
    public void When_FloatsToList_Default_Size_Returns_ListOfFloat()
    {
        var actual = Dm.Floats().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<float>>(actual);
    }
    
    [Fact]
    public void When_FloatsToList_Size_0_Returns_EmptyListOfFloat()
    {
        var actual = Dm.Floats().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<float>>(actual);
    }
    
    [Fact]
    public void When_FloatsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Floats().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_FloatsToList_With_Size_Returns_ListOfFloat(int size)
    {
        var actual = Dm.Floats().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<float>>(actual);
    }
    
    [Fact]
    public void When_FloatsRange_With_MinValue_MaxValue_Returns_MockTypeFloat()
    {
        var actual = Dm.Floats().Range(1, 10);

        Assert.IsType<MockTypeFloat>(actual);
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
    public void When_FloatsRange_With_MinValue_MaxValue_Returns_Float_WithinRangeOf_MinValue_And_MaxValue(float minValue, float maxValue)
    {
        var actual = Dm.Floats().Range(minValue, maxValue).Get();

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
    public void When_FloatsMinAndMaxAndGet_With_MinValue_MaxValue_Returns_Float_WithinRangeOf_MinValue_And_MaxValue(float minValue, float maxValue)
    {
        var actual = Dm.Floats().Min(minValue).Max(maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    }

    [Fact]
    public void When_FloatsRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Floats().Range(minValue: 100, maxValue: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_FloatsMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Floats().Min(minValue: 100).Max(maxValue: 1).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
}