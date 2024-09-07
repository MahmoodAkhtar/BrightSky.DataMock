namespace BrightSky.DataMock.Tests;

public class PercentageTests
{
    [Fact]
    public void When_Percentage_Value_LessThanZero_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => _ = new Percentage(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_Percentage_Value_GreaterThan100_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => _ = new Percentage(101);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_Percentage_Value_AsZero_Equals_ZeroInt()
    {
        var actual = new Percentage(0);

        Assert.Equal(0, actual);
    }
    
    [Fact]
    public void When_PercentageMinValue_Equals_Percentage_Value_AsZero()
    {
        var expected = new Percentage(0);

        Assert.Equal(expected, Percentage.MinValue);
    }
  
    [Fact]
    public void When_PercentageMinValue_Equals_ZeroInt()
    {
        Assert.Equal(0, Percentage.MinValue);
    }
    
    [Fact]
    public void When_Percentage_Value_As100_Equals_100Int()
    {
        var actual = new Percentage(100);

        Assert.Equal(100, actual);
    }
    
    [Fact]
    public void When_PercentageMaxValue_Equals_Percentage_Value_As100()
    {
        var expected = new Percentage(100);

        Assert.Equal(expected, Percentage.MaxValue);
    }
    
    [Fact]
    public void When_PercentageMaxValue_Equals_100Int()
    {
        Assert.Equal(100, Percentage.MaxValue);
    }
}