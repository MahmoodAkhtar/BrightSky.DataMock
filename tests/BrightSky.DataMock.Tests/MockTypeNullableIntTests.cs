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
}