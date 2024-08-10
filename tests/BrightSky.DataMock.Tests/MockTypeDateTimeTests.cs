namespace BrightSky.DataMock.Tests;

public class MockTypeDateTimeTests
{
    [Fact]
    public void When_DateTimes_Returns_ImplOf_IMockTypeOfDateTime()
    {
        var actual = Dm.DateTimes();

        Assert.IsAssignableFrom<IMockType<DateTime>>(actual);
    }
    
    [Fact]
    public void When_DateTimes_Returns_MockTypeDateTime()
    {
        var actual = Dm.DateTimes();

        Assert.IsType<MockTypeDateTime>(actual);
    }
    
    [Fact]
    public void When_DateTimesGet_Returns_DateTime()
    {
        var actual = Dm.DateTimes().Get();

        Assert.IsType<DateTime>(actual);
    }
    
    [Fact]
    public void When_DateTimesMax_Returns_MockTypeDateTime()
    {
        var actual = Dm.DateTimes().Max(DateTime.MaxValue);

        Assert.IsType<MockTypeDateTime>(actual);
    }
    
    [Fact]
    public void When_DateTimesMax_MinValueAdd1Day_Get_Returns_DateTimes()
    {
        var actual = Dm.DateTimes().Max(DateTime.MinValue.AddDays(1)).Get();

        Assert.True(actual <= DateTime.MinValue.AddDays(1));
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
    public void When_DateTimesMax_With_MaxValue_Get_Returns_DateTime_LessThanOrEqualTo_MaxValue(DateTime maxValue)
    {
        var actual = Dm.DateTimes().Max(maxValue).Get();

        Assert.True(actual <= maxValue);
    } 
    
    [Fact]
    public void When_DateTimesMin_Returns_MockTypeDateTime()
    {
        var actual = Dm.DateTimes().Min(DateTime.MinValue);

        Assert.IsType<MockTypeDateTime>(actual);
    }
    
    [Fact]
    public void When_DateTimesMin_MinValueAdd1Day_Get_Returns_DateTimes()
    {
        var actual = Dm.DateTimes().Min(DateTime.MinValue.AddDays(1)).Get();

        Assert.True(actual >= DateTime.MinValue.AddDays(1));
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
    public void When_DateTimesMin_With_MinValue_Get_Returns_DateTime_LessThanOrEqualTo_MinValue(DateTime minValue)
    {
        var actual = Dm.DateTimes().Min(minValue).Get();

        Assert.True(actual >= minValue);
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
    public void When_DateTimesMinAndMaxAndGet_With_MinValue_MaxValue_Returns_DateTime_WithinRangeOf_MinValue_And_MaxValue(DateTime minValue, DateTime maxValue)
    {
        var actual = Dm.DateTimes().Min(minValue).Max(maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    } 
    
    [Fact]
    public void When_DateTimesRange_With_MinValue_MaxValue_Returns_MockTypeDateTime()
    {
        var actual = Dm.DateTimes().Range(DateTime.MinValue, DateTime.MaxValue);

        Assert.IsType<MockTypeDateTime>(actual);
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
    public void When_DateTimesRange_With_MinValue_MaxValue_Returns_DateTime_WithinRangeOf_MinValue_And_MaxValue(DateTime minValue, DateTime maxValue)
    {
        var actual = Dm.DateTimes().Range(minValue, maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    }
    
    [Fact]
    public void When_DateTimesMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.DateTimes().Min(DateTime.MaxValue).Max(DateTime.MinValue).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_DateTimesRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.DateTimes().Range(DateTime.MaxValue, DateTime.MinValue);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }


}