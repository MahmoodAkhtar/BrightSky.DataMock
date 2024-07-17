namespace BrightSky.DataMock.Tests;

public class MockTypeNullableIntTests
{
    // TODO: Place into some testing helper class eventually ???
    public static bool IsNullable<T>(T value)
    {
        if (value == null) return true; // obvious
        Type type = typeof(T);
        if (!type.IsValueType) return true; // ref-type
        if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
        return false; // value-type
    }
    
    [Fact]
    public void When_NullableInts_Returns_ImplOf_IMockTypeOfNullableInt()
    {
        var actual = Dm.NullableInts();

        Assert.IsAssignableFrom<IMockType<int?>>(actual);
    }
    
    [Fact]
    public void When_NullableInts_Returns_MockTypeNullableInt()
    {
        var actual = Dm.NullableInts();

        Assert.IsType<MockTypeNullableInt>(actual);
    }
    
    [Fact]
    public void When_NullableIntsGet_Returns_NullableInt()
    {
        var actual = Dm.NullableInts().Get();

        Assert.True(IsNullable(actual));
    }
        
    [Fact]
    public void When_NullableIntsMax_Returns_MockTypeNullableInt()
    {
        var actual = Dm.NullableInts().Max(1);

        Assert.IsType<MockTypeNullableInt>(actual);
    }
    
    [Fact]
    public void When_NullableIntsMax_1_Get_Returns_NullableInt()
    {
        var actual = Dm.NullableInts().Max(1).Get();

        Assert.True(actual is not > 1);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableIntsMax_With_MaxValue_Get_Returns_NullableInt_LessThanOrEqualTo_MaxValue(int maxValue)
    {
        var actual = Dm.NullableInts().Max(maxValue).Get();

        Assert.True(!actual.HasValue || actual.Value < maxValue);
    }   
    
    [Fact]
    public void When_NullableIntsMin_Returns_MockTypeNullableInt()
    {
        var actual = Dm.NullableInts().Min(1);

        Assert.IsType<MockTypeNullableInt>(actual);
    } 
    
    [Fact]
    public void When_NullableIntsMin_1_Get_Returns_NullableInt()
    {
        var actual = Dm.NullableInts().Min(1).Get();

        Assert.True(actual is not < 1);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableIntsMin_With_MinValue_Get_Returns_NullableInt_GreaterThanOrEqualTo_MinValue(int minValue)
    {
        var actual = Dm.NullableInts().Min(minValue).Get();

        Assert.True(!actual.HasValue || actual.Value >= minValue);
    }
    
    [Fact]
    public void When_NullableIntsToList_Default_Size_Returns_ListOfNullableInt()
    {
        var actual = Dm.NullableInts().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<int?>>(actual);
    }
    
    [Fact]
    public void When_NullableIntsToList_Size_0_Returns_EmptyListOfNullableInt()
    {
        var actual = Dm.NullableInts().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<int?>>(actual);
    }
    
    [Fact]
    public void When_NullableIntsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.NullableInts().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableIntsToList_With_Size_Returns_ListOfNullableInt(int size)
    {
        var actual = Dm.NullableInts().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<int?>>(actual);
    }
    
    [Fact]
    public void When_NullableIntsRange_With_MinValue_MaxValue_Returns_MockTypeNullableInt()
    {
        var actual = Dm.NullableInts().Range(1, 10);

        Assert.IsType<MockTypeNullableInt>(actual);
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
    public void When_NullableIntsRange_With_MinValue_MaxValue_Returns_NullableInt_WithinRangeOf_MinValue_And_MaxValue(int minValue, int maxValue)
    {
        var actual = Dm.NullableInts().Range(minValue, maxValue).Get();

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
    public void When_NullableIntsMinAndMaxAndGet_With_MinValue_MaxValue_Returns_NullableInt_WithinRangeOf_MinValue_And_MaxValue(int minValue, int maxValue)
    {
        var actual = Dm.NullableInts().Min(minValue).Max(maxValue).Get();

        Assert.True(!actual.HasValue || actual.Value >= minValue && actual.Value <= maxValue);
    }
    
    [Fact]
    public void When_NullableIntsRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableInts().Range(minValue: 100, maxValue: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableIntsMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableInts().Min(minValue: 100).Max(maxValue: 1).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableIntsProbability_Returns_MockTypeNullableInt()
    {
        var actual = Dm.NullableInts().Probability(1);

        Assert.IsType<MockTypeNullableInt>(actual);
    }
    
    [Fact]
    public void When_NullableIntsProbability_Percentage_LessThanZero_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableInts().Probability(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableIntsProbability_Percentage_GreaterThanOneHundred_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableInts().Probability(101);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableIntsProbability_With_0_NeverReturns_Null()
    {
        var actual = Dm.NullableInts().Probability(0).ToList();

        Assert.True(actual.All(x => x is not null));
    }
    
    [Fact]
    public void When_NullableIntsProbability_With_100_Returns_AlwaysNull()
    {
        var actual = Dm.NullableInts().Probability(100).ToList();

        Assert.True(actual.All(x => x is null));
    }
    
    [Fact]
    public void When_NullableIntsToList_With_DefaultProbability_Returns_Null_50Percent()
    {
        var actual = Dm.NullableInts().ToList();

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
    public void When_NullableIntsProbabilityAndToList_With_Percentage_And_Size_Returns_ExpectedNullCount(int percentage, int size)
    {
        var expected = (int)Math.Round(size * (percentage / 100.0m), MidpointRounding.AwayFromZero);
        var actual = Dm.NullableInts().Probability(percentage).ToList(size);

        Assert.Equal(expected, actual.Count(x => x is null));
    }
}