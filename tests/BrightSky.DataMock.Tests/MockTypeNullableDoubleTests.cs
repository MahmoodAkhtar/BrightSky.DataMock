namespace BrightSky.DataMock.Tests;

public class MockTypeNullableDoubleTests
{
    [Fact]
    public void When_NullableDoubles_Returns_ImplOf_IMockTypeOfNullableDouble()
    {
        var actual = Dm.NullableDoubles();

        Assert.IsAssignableFrom<IMockType<double?>>(actual);
    }
    
    [Fact]
    public void When_NullableDoubles_Returns_MockTypeNullableDouble()
    {
        var actual = Dm.NullableDoubles();

        Assert.IsType<MockTypeNullableDouble>(actual);
    }
    
    [Fact]
    public void When_NullableDoublesGet_Returns_NullableDouble()
    {
        var actual = Dm.NullableDoubles().Get();

        Assert.True(Test.IsNullable(actual));
    }
        
    [Fact]
    public void When_NullableDoublesMax_Returns_MockTypeNullableDouble()
    {
        var actual = Dm.NullableDoubles().Max(1);

        Assert.IsType<MockTypeNullableDouble>(actual);
    }
    
    [Fact]
    public void When_NullableDoublesMax_1_Get_Returns_NullableDouble()
    {
        var actual = Dm.NullableDoubles().Max(1).Get();

        Assert.True(actual is not > 1);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableDoublesMax_With_MaxValue_Get_Returns_NullableDouble_LessThanOrEqualTo_MaxValue(double maxValue)
    {
        var actual = Dm.NullableDoubles().Max(maxValue).Get();

        Assert.True(!actual.HasValue || actual.Value < maxValue);
    }   
    
    [Fact]
    public void When_NullableDoublesMin_Returns_MockTypeNullableDouble()
    {
        var actual = Dm.NullableDoubles().Min(1);

        Assert.IsType<MockTypeNullableDouble>(actual);
    } 
    
    [Fact]
    public void When_NullableDoublesMin_1_Get_Returns_NullableDouble()
    {
        var actual = Dm.NullableDoubles().Min(1).Get();

        Assert.True(actual is not < 1);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableDoublesMin_With_MinValue_Get_Returns_NullableDouble_GreaterThanOrEqualTo_MinValue(double minValue)
    {
        var actual = Dm.NullableDoubles().Min(minValue).Get();

        Assert.True(!actual.HasValue || actual.Value >= minValue);
    }
    
    [Fact]
    public void When_NullableDoublesToList_Default_Size_Returns_ListOfNullableDouble()
    {
        var actual = Dm.NullableDoubles().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<double?>>(actual);
    }
    
    [Fact]
    public void When_NullableDoublesToList_Size_0_Returns_EmptyListOfNullableDouble()
    {
        var actual = Dm.NullableDoubles().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<double?>>(actual);
    }
    
    [Fact]
    public void When_NullableDoublesToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.NullableDoubles().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableDoublesToList_With_Size_Returns_ListOfNullableDouble(int size)
    {
        var actual = Dm.NullableDoubles().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<double?>>(actual);
    }
    
    [Fact]
    public void When_NullableDoublesRange_With_MinValue_MaxValue_Returns_MockTypeNullableDouble()
    {
        var actual = Dm.NullableDoubles().Range(1, 10);

        Assert.IsType<MockTypeNullableDouble>(actual);
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
    public void When_NullableDoublesRange_With_MinValue_MaxValue_Returns_NullableDouble_WithinRangeOf_MinValue_And_MaxValue(double minValue, double maxValue)
    {
        var actual = Dm.NullableDoubles().Range(minValue, maxValue).Get();

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
    public void When_NullableDoublesMinAndMaxAndGet_With_MinValue_MaxValue_Returns_NullableDouble_WithinRangeOf_MinValue_And_MaxValue(double minValue, double maxValue)
    {
        var actual = Dm.NullableDoubles().Min(minValue).Max(maxValue).Get();

        Assert.True(!actual.HasValue || actual.Value >= minValue && actual.Value <= maxValue);
    }
    
    [Fact]
    public void When_NullableDoublesRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableDoubles().Range(minValue: 100, maxValue: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableDoublesMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableDoubles().Min(minValue: 100).Max(maxValue: 1).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableDoublesNullableProbability_Returns_MockTypeNullableDouble()
    {
        var actual = Dm.NullableDoubles().NullableProbability(1);

        Assert.IsType<MockTypeNullableDouble>(actual);
    }
    
    [Fact]
    public void When_NullableDoublesNullableProbability_NullablePercentage_LessThanZero_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableDoubles().NullableProbability(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableDoublesNullableProbability_NullablePercentage_GreaterThanOneHundred_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableDoubles().NullableProbability(101);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableDoublesNullableProbability_With_0_NeverReturns_Null()
    {
        var actual = Dm.NullableDoubles().NullableProbability(0).ToList();

        Assert.True(actual.All(x => x is not null));
    }
    
    [Fact]
    public void When_NullableDoublesNullableProbability_With_100_Returns_AlwaysNull()
    {
        var actual = Dm.NullableDoubles().NullableProbability(100).ToList();

        Assert.True(actual.All(x => x is null));
    }
    
    [Fact]
    public void When_NullableDoublesToList_With_DefaultNullableProbability_Returns_Null_50Percent()
    {
        var actual = Dm.NullableDoubles().ToList();

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
    public void When_NullableDoublesNullableProbabilityAndToList_With_NullablePercentage_And_Size_Returns_ExpectedNullCount(int nullablePercentage, int size)
    {
        var expected = (int)Math.Ceiling(size * (nullablePercentage / 100.0m));
        var actual = Dm.NullableDoubles().NullableProbability(nullablePercentage).ToList(size);

        Assert.Equal(expected, actual.Count(x => x is null));
    }
}