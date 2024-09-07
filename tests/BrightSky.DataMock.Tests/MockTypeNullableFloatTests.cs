namespace BrightSky.DataMock.Tests;

public class MockTypeNullableFloatTests
{
    [Fact]
    public void When_NullableFloats_Returns_ImplOf_IMockTypeOfNullableFloat()
    {
        var actual = Dm.NullableFloats();

        Assert.IsAssignableFrom<IMockType<float?>>(actual);
    }
    
    [Fact]
    public void When_NullableFloats_Returns_MockTypeNullableFloat()
    {
        var actual = Dm.NullableFloats();

        Assert.IsType<MockTypeNullableFloat>(actual);
    }
    
    [Fact]
    public void When_NullableFloatsGet_Returns_NullableFloat()
    {
        var actual = Dm.NullableFloats().Get();

        Assert.True(Test.IsNullable(actual));
    }
        
    [Fact]
    public void When_NullableFloatsMax_Returns_MockTypeNullableFloat()
    {
        var actual = Dm.NullableFloats().Max(1);

        Assert.IsType<MockTypeNullableFloat>(actual);
    }
    
    [Fact]
    public void When_NullableFloatsMax_1_Get_Returns_NullableFloat()
    {
        var actual = Dm.NullableFloats().Max(1).Get();

        Assert.True(actual is not > 1);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableFloatsMax_With_MaxValue_Get_Returns_NullableFloat_LessThanOrEqualTo_MaxValue(float maxValue)
    {
        var actual = Dm.NullableFloats().Max(maxValue).Get();

        Assert.True(!actual.HasValue || actual.Value < maxValue);
    }   
    
    [Fact]
    public void When_NullableFloatsMin_Returns_MockTypeNullableFloat()
    {
        var actual = Dm.NullableFloats().Min(1);

        Assert.IsType<MockTypeNullableFloat>(actual);
    } 
    
    [Fact]
    public void When_NullableFloatsMin_1_Get_Returns_NullableFloat()
    {
        var actual = Dm.NullableFloats().Min(1).Get();

        Assert.True(actual is not < 1);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableFloatsMin_With_MinValue_Get_Returns_NullableFloat_GreaterThanOrEqualTo_MinValue(float minValue)
    {
        var actual = Dm.NullableFloats().Min(minValue).Get();

        Assert.True(!actual.HasValue || actual.Value >= minValue);
    }
    
    [Fact]
    public void When_NullableFloatsToList_Default_Size_Returns_ListOfNullableFloat()
    {
        var actual = Dm.NullableFloats().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<float?>>(actual);
    }
    
    [Fact]
    public void When_NullableFloatsToList_Size_0_Returns_EmptyListOfNullableFloat()
    {
        var actual = Dm.NullableFloats().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<float?>>(actual);
    }
    
    [Fact]
    public void When_NullableFloatsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.NullableFloats().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableFloatsToList_With_Size_Returns_ListOfNullableFloat(int size)
    {
        var actual = Dm.NullableFloats().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<float?>>(actual);
    }
    
    [Fact]
    public void When_NullableFloatsRange_With_MinValue_MaxValue_Returns_MockTypeNullableFloat()
    {
        var actual = Dm.NullableFloats().Range(1, 10);

        Assert.IsType<MockTypeNullableFloat>(actual);
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
    public void When_NullableFloatsRange_With_MinValue_MaxValue_Returns_NullableFloat_WithinRangeOf_MinValue_And_MaxValue(float minValue, float maxValue)
    {
        var actual = Dm.NullableFloats().Range(minValue, maxValue).Get();

        Assert.True(!actual.HasValue || actual.Value >= minValue && actual.Value <= maxValue);
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
    public void When_NullableFloatsMinAndMaxAndGet_With_MinValue_MaxValue_Returns_NullableFloat_WithinRangeOf_MinValue_And_MaxValue(float minValue, float maxValue)
    {
        var actual = Dm.NullableFloats().Min(minValue).Max(maxValue).Get();

        Assert.True(!actual.HasValue || actual.Value >= minValue && actual.Value <= maxValue);
    }
    
    [Fact]
    public void When_NullableFloatsRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableFloats().Range(minValue: 100, maxValue: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableFloatsMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableFloats().Min(minValue: 100).Max(maxValue: 1).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableFloatsNullableProbability_Returns_MockTypeNullableFloat()
    {
        var actual = Dm.NullableFloats().NullableProbability((Percentage)1);

        Assert.IsType<MockTypeNullableFloat>(actual);
    }
    
    [Fact]
    public void When_NullableFloatsNullableProbability_With_0_NeverReturns_Null()
    {
        var actual = Dm.NullableFloats().NullableProbability((Percentage)0).ToList();

        Assert.True(actual.All(x => x is not null));
    }
    
    [Fact]
    public void When_NullableFloatsNullableProbability_With_100_Returns_AlwaysNull()
    {
        var actual = Dm.NullableFloats().NullableProbability((Percentage)100).ToList();

        Assert.True(actual.All(x => x is null));
    }
    
    [Fact]
    public void When_NullableFloatsToList_With_DefaultNullableProbability_Returns_Null_50Percent()
    {
        var actual = Dm.NullableFloats().ToList();

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
    public void When_NullableFloatsNullableProbabilityAndToList_With_NullablePercentage_And_Size_Returns_ExpectedNullCount(int nullablePercentage, int size)
    {
        var expected = (int)Math.Ceiling(size * (nullablePercentage / 100.0m));
        var actual = Dm.NullableFloats().NullableProbability((Percentage)nullablePercentage).ToList(size);

        Assert.Equal(expected, actual.Count(x => x is null));
    }
}