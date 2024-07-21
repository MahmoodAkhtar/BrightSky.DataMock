namespace BrightSky.DataMock.Tests;

public class MockTypeBoolTests
{
    [Fact]
    public void When_Bools_Returns_ImplOf_IMockTypeOfBool()
    {
        var actual = Dm.Bools();

        Assert.IsAssignableFrom<IMockType<bool>>(actual);
    }
    
    [Fact]
    public void When_Bools_Returns_MockTypeBools()
    {
        var actual = Dm.Bools();

        Assert.IsType<MockTypeBool>(actual);
    }
    
    [Fact]
    public void When_BoolsGet_Returns_Bool()
    {
        var actual = Dm.Bools().Get();

        Assert.IsType<bool>(actual);
    }
    
    [Fact]
    public void When_BoolsToList_Default_Size_Returns_ListOfBool()
    {
        var actual = Dm.Bools().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<bool>>(actual);
    }
     
    [Fact]
    public void When_BoolsToList_Size_0_Returns_EmptyListOfBool()
    {
        var actual = Dm.Bools().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<bool>>(actual);
    }
    
    [Fact]
    public void When_BoolsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Bools().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_BoolsToList_With_Size_Returns_ListOfBool(int size)
    {
        var actual = Dm.Bools().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<bool>>(actual);
    }
    
    [Fact]
    public void When_BoolsTrueProbability_Returns_MockTypeBool()
    {
        var actual = Dm.Bools().TrueProbability(1);

        Assert.IsType<MockTypeBool>(actual);
    }
    
    [Fact]
    public void When_BoolsFalseProbability_Returns_MockTypeBool()
    {
        var actual = Dm.Bools().FalseProbability(1);

        Assert.IsType<MockTypeBool>(actual);
    }
    
    [Fact]
    public void When_BoolsTrueProbability_TruePercentage_LessThanZero_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Bools().TrueProbability(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void When_BoolsFalseProbability_FalsePercentage_LessThanZero_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Bools().FalseProbability(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_BoolsTrueProbability_TruePercentage_GreaterThanOneHundred_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Bools().TrueProbability(101);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_BoolsFalseProbability_FalsePercentage_GreaterThanOneHundred_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Bools().FalseProbability(101);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_BoolsTrueProbability_With_0_Returns_AlwaysFalse()
    {
        var actual = Dm.Bools().TrueProbability(0).ToList();

        Assert.True(actual.All(x => x is false));
    }
    
    [Fact]
    public void When_BoolsFalseProbability_With_0_Returns_AlwaysTrue()
    {
        var actual = Dm.Bools().FalseProbability(0).ToList();

        Assert.True(actual.All(x => x is true));
    }
    
    [Fact]
    public void When_BoolsTrueProbability_With_100_Returns_AlwaysTrue()
    {
        var actual = Dm.Bools().TrueProbability(100).ToList();

        Assert.True(actual.All(x => x is true));
    }
    
    [Fact]
    public void When_BoolsFalseProbability_With_100_Returns_AlwaysFalse()
    {
        var actual = Dm.Bools().FalseProbability(100).ToList();

        Assert.True(actual.All(x => x is false));
    }
    
    [Fact]
    public void When_BoolsToList_With_DefaultTrueProbability_Returns_True_50Percent()
    {
        var actual = Dm.Bools().ToList();

        Assert.Equal(50, actual.Count(x => x is true));
    }
        
    [Fact]
    public void When_BoolsToList_With_DefaultFalseProbability_Returns_False_50Percent()
    {
        var actual = Dm.Bools().ToList();

        Assert.Equal(50, actual.Count(x => x is false));
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
    public void When_BoolsTrueProbabilityAndToList_With_TruePercentage_And_Size_Returns_ExpectedTrueCount(int truePercentage, int size)
    {
        var expected = (int)Math.Ceiling(size * (truePercentage / 100.0m));
        var actual = Dm.Bools().TrueProbability(truePercentage).ToList(size);

        Assert.Equal(expected, actual.Count(x => x is true));
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
    public void When_BoolsFalseProbabilityAndToList_With_FalsePercentage_And_Size_Returns_ExpectedTrueCount(int falsePercentage, int size)
    {
        var expected = (int)Math.Floor(size * (falsePercentage / 100.0m));
        var actual = Dm.Bools().FalseProbability(falsePercentage).ToList(size);

        Assert.Equal(expected, actual.Count(x => x is false));
    }
}