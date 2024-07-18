namespace BrightSky.DataMock.Tests;

public class MockTypeNullableBoolTests
{
    [Fact]
    public void When_NullableBools_Returns_ImplOf_IMockTypeOfNullableBool()
    {
        var actual = Dm.NullableBools();

        Assert.IsAssignableFrom<IMockType<bool?>>(actual);
    }
    
    [Fact]
    public void When_NullableBools_Returns_MockTypeNullableBools()
    {
        var actual = Dm.NullableBools();

        Assert.IsType<MockTypeNullableBool>(actual);
    }
    
    [Fact]
    public void When_NullableBoolsGet_Returns_NullableBool()
    {
        var actual = Dm.NullableBools().Get();

        Assert.True(Test.IsNullable(actual));
    }
    
    [Fact]
    public void When_NullableBoolsToList_Default_Size_Returns_ListOfNullableBool()
    {
        var actual = Dm.NullableBools().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<bool?>>(actual);
    }
     
    [Fact]
    public void When_NullableBoolsToList_Size_0_Returns_EmptyListOfNullableBool()
    {
        var actual = Dm.NullableBools().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<bool?>>(actual);
    }
    
    [Fact]
    public void When_NullableBoolsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.NullableBools().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    //[Theory]
    //[InlineData(1)]
    //[InlineData(3)]
    //[InlineData(5)]
    //[InlineData(10)]
    //[InlineData(50)]
    //[InlineData(150)]
    private void When_NullableBoolsToList_With_Size_Returns_ListOfNullableBool(int size)
    {
        var actual = Dm.NullableBools().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<bool?>>(actual);
    }

    [Fact]
    public void When_NullableBoolsTrueProbability_Returns_MockTypeNullableBool()
    {
        var actual = Dm.NullableBools().TrueProbability(1);

        Assert.IsType<MockTypeNullableBool>(actual);
    }

    [Fact]
    public void When_NullableBoolsTrueProbability_TruePercentage_LessThanZero_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableBools().TrueProbability(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableBoolsTrueProbability_TruePercentage_GreaterThanOneHundred_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.NullableBools().TrueProbability(101);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableBoolsTrueProbability_With_0_Returns_HalfFalse()
    {
        var actual = Dm.NullableBools().TrueProbability(0).ToList();

        Assert.Equal(50, actual.Count(x => x is false));
    }
    
    //[Fact]
    private void When_NullableBoolsTrueProbability_With_100_Returns_HalfTrue()
    {
        var actual = Dm.NullableBools().TrueProbability(100).ToList();

        Assert.Equal(50, actual.Count(x => x is true));
    }
}