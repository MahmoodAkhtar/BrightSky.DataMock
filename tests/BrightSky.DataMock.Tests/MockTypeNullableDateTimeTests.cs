namespace BrightSky.DataMock.Tests;

public class MockTypeNullableDateTimeTests
{
    [Fact]
    public void When_NullableDateTimes_Returns_ImplOf_IMockTypeOfNullableDateTime()
    {
        var actual = Dm.NullableDateTimes();

        Assert.IsAssignableFrom<IMockType<DateTime?>>(actual);
    }
    
    [Fact]
    public void When_NullableDateTimes_Returns_MockTypeNullableDateTime()
    {
        var actual = Dm.NullableDateTimes();

        Assert.IsType<MockTypeNullableDateTime>(actual);
    }
        
    [Fact]
    public void When_NullableDateTimesGet_Returns_NullableDateTime()
    {
        var actual = Dm.NullableDateTimes().Get();

        Assert.True(Test.IsNullable(actual));
    }
    
    [Fact]
    public void When_NullableDateTimesMax_Returns_MockTypeNullableDateTime()
    {
        var actual = Dm.NullableDateTimes().Max(DateTime.MaxValue);

        Assert.IsType<MockTypeNullableDateTime>(actual);
    }
    
    [Fact]
    public void When_NullableDateTimesMax_MinValueAdd1Day_Get_Returns_NullableDateTimes()
    {
        var actual = Dm.NullableDateTimes().Max(DateTime.MinValue.AddDays(1)).Get();

        Assert.True(!actual.HasValue || actual <= DateTime.MinValue.AddDays(1));
    }
    
    [Theory]
    [InlineData("1900-01-01")]
    [InlineData("1905-02-03")]
    [InlineData("1909-03-05")]
    [InlineData("1915-04-09")]
    [InlineData("1920-05-10")]
    [InlineData("1925-06-13")]
    [InlineData("1975-07-15")]
    [InlineData("2000-08-20")]
    [InlineData("2009-09-21")]
    [InlineData("2024-10-24")]
    [InlineData("2050-11-28")]
    [InlineData("2100-12-31")]
    public void When_NullableDateTimesMax_With_MaxValue_Get_Returns_NullableDateTime_LessThanOrEqualTo_MaxValue(DateTime maxValue)
    {
        var actual = Dm.NullableDateTimes().Max(maxValue).Get();

        Assert.True(!actual.HasValue || actual.Value < maxValue);
    }
    
    [Fact]
    public void When_NullableDateTimesMin_Returns_MockTypeNullableDateTime()
    {
        var actual = Dm.NullableDateTimes().Min(DateTime.MinValue);

        Assert.IsType<MockTypeNullableDateTime>(actual);
    }
    
    [Fact]
    public void When_NullableDateTimesMin_MinValueAdd1Day_Get_Returns_NullableDateTimes()
    {
        var actual = Dm.NullableDateTimes().Min(DateTime.MinValue.AddDays(1)).Get();

        Assert.True(!actual.HasValue || actual.Value >= DateTime.MinValue.AddDays(1));
    }
    
    [Theory]
    [InlineData("1900-01-01")]
    [InlineData("1905-02-03")]
    [InlineData("1909-03-05")]
    [InlineData("1915-04-09")]
    [InlineData("1920-05-10")]
    [InlineData("1925-06-13")]
    [InlineData("1975-07-15")]
    [InlineData("2000-08-20")]
    [InlineData("2009-09-21")]
    [InlineData("2024-10-24")]
    [InlineData("2050-11-28")]
    [InlineData("2100-12-31")]
    public void When_NullableDateTimesMin_With_MinValue_Get_Returns_NullableDateTime_LessThanOrEqualTo_MinValue(DateTime minValue)
    {
        var actual = Dm.NullableDateTimes().Min(minValue).Get();

        Assert.True(!actual.HasValue || actual.Value >= minValue);
    }
    
    [Theory]
    [InlineData("1900-01-01", "1900-01-15")]
    [InlineData("1905-02-03", "1905-02-23")]
    [InlineData("1909-03-05", "1909-03-25")]
    [InlineData("1915-04-09", "1915-04-19")]
    [InlineData("1920-05-10", "1920-05-20")]
    [InlineData("1925-06-13", "1925-06-23")]
    [InlineData("1975-07-15", "1975-07-25")]
    [InlineData("2000-08-20", "2000-08-30")]
    [InlineData("2009-09-21", "2009-09-30")]
    [InlineData("2024-10-14", "2024-10-24")]
    [InlineData("2050-11-18", "2050-11-28")]
    [InlineData("2100-12-01", "2100-12-31")]
    public void When_NullableDateTimesMinAndMaxAndGet_With_MinValue_MaxValue_Returns_NullableDateTime_WithinRangeOf_MinValue_And_MaxValue(DateTime minValue, DateTime maxValue)
    {
        var actual = Dm.NullableDateTimes().Min(minValue).Max(maxValue).Get();

        Assert.True(!actual.HasValue || actual >= minValue && actual <= maxValue);
    }
    
    [Fact]
    public void When_NullableDateTimesRange_With_MinValue_MaxValue_Returns_MockTypeNullableDateTime()
    {
        var actual = Dm.NullableDateTimes().Range(DateTime.MinValue, DateTime.MaxValue);

        Assert.IsType<MockTypeNullableDateTime>(actual);
    }
    
    [Theory]
    [InlineData("1900-01-01", "1900-01-15")]
    [InlineData("1905-02-03", "1905-02-23")]
    [InlineData("1909-03-05", "1909-03-25")]
    [InlineData("1915-04-09", "1915-04-19")]
    [InlineData("1920-05-10", "1920-05-20")]
    [InlineData("1925-06-13", "1925-06-23")]
    [InlineData("1975-07-15", "1975-07-25")]
    [InlineData("2000-08-20", "2000-08-30")]
    [InlineData("2009-09-21", "2009-09-30")]
    [InlineData("2024-10-14", "2024-10-24")]
    [InlineData("2050-11-18", "2050-11-28")]
    [InlineData("2100-12-01", "2100-12-31")]
    public void When_NullableDateTimesRange_With_MinValue_MaxValue_Returns_NullableDateTime_WithinRangeOf_MinValue_And_MaxValue(DateTime minValue, DateTime maxValue)
    {
        var actual = Dm.NullableDateTimes().Range(minValue, maxValue).Get();

        Assert.True(!actual.HasValue || actual >= minValue && actual <= maxValue);
    }

    [Fact]
    public void When_NullableDateTimesMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableDateTimes().Min(DateTime.MaxValue).Max(DateTime.MinValue).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableDateTimesRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableDateTimes().Range(DateTime.MaxValue, DateTime.MinValue);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableDateTimesToList_Default_Size_Returns_ListOfNullableDateTime()
    {
        var actual = Dm.NullableDateTimes().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<DateTime?>>(actual);
    }
    
    [Fact]
    public void When_NullableDateTimesToList_Size_0_Returns_EmptyListOfNullableDateTime()
    {
        var actual = Dm.NullableDateTimes().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<DateTime?>>(actual);
    }
    
    [Fact]
    public void When_NullableDateTimesToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.NullableDateTimes().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_NullableDateTimesToList_With_Size_Returns_ListOfNullableDateTime(int size)
    {
        var actual = Dm.NullableDateTimes().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<DateTime?>>(actual);
    }
    
    [Fact]
    public void When_NullableDateTimesNullableProbability_Returns_MockTypeNullableDateTime()
    {
        var actual = Dm.NullableDateTimes().NullableProbability((Percentage)1);

        Assert.IsType<MockTypeNullableDateTime>(actual);
    }
    
    [Fact]
    public void When_NullableDateTimesNullableProbability_With_0_NeverReturns_Null()
    {
        var actual = Dm.NullableDateTimes().NullableProbability((Percentage)0).ToList();

        Assert.True(actual.All(x => x is not null));
    }
    
    [Fact]
    public void When_NullableDateTimesNullableProbability_With_100_Returns_AlwaysNull()
    {
        var actual = Dm.NullableDateTimes().NullableProbability((Percentage)100).ToList();

        Assert.True(actual.All(x => x is null));
    }
    [Fact]
    public void When_NullableDateTimesToList_With_DefaultNullableProbability_Returns_Null_50Percent()
    {
        var actual = Dm.NullableDateTimes().ToList();

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
    public void When_NullableDateTimesNullableProbabilityAndToList_With_NullablePercentage_And_Size_Returns_ExpectedNullCount(int nullablePercentage, int size)
    {
        var expected = (int)Math.Ceiling(size * (nullablePercentage / 100.0m));
        var actual = Dm.NullableDateTimes().NullableProbability((Percentage)nullablePercentage).ToList(size);

        Assert.Equal(expected, actual.Count(x => x is null));
    }
}