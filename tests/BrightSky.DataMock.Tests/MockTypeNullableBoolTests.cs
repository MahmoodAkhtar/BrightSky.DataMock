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
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    private void When_NullableBoolsToList_With_Size_Returns_ListOfNullableBool(int size)
    {
        var actual = Dm.NullableBools().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<bool?>>(actual);
    }

    [Fact]
    public void When_NullableBoolsTrueProbability_Returns_MockTypeNullableBool()
    {
        var actual = Dm.NullableBools().TrueProbability((Percentage)1);

        Assert.IsType<MockTypeNullableBool>(actual);
    }

    [Fact]
    public void When_NullableBoolsFalseProbability_Returns_MockTypeNullableBool()
    {
        var actual = Dm.NullableBools().FalseProbability((Percentage)1);

        Assert.IsType<MockTypeNullableBool>(actual);
    }    
    
    [Fact]
    public void When_NullableBoolsNullableProbability_Returns_MockTypeNullableBool()
    {
        var actual = Dm.NullableBools().NullableProbability((Percentage)1);

        Assert.IsType<MockTypeNullableBool>(actual);
    }

    [Fact]
    public void When_NullableBoolsTrueProbability_With_0_Returns_HalfFalseAndHalfNull()
    {
        var actual = Dm.NullableBools().TrueProbability((Percentage)0).ToList();

        Assert.Equal(50, actual.Count(x => x is false));
        Assert.Equal(50, actual.Count(x => x is null));
    }
    
    [Fact]
    public void When_NullableBoolsFalseProbability_With_0_Returns_HalfTrueAndHalfNull()
    {
        var actual = Dm.NullableBools().FalseProbability((Percentage)0).ToList();

        Assert.Equal(50, actual.Count(x => x is true));
        Assert.Equal(50, actual.Count(x => x is null));
    }
        
    [Fact]
    public void When_NullableBoolsNullableProbability_With_0_Returns_HalfTrueAndHalfFalse()
    {
        var actual = Dm.NullableBools().NullableProbability((Percentage)0).ToList();

        Assert.Equal(50, actual.Count(x => x is true));
        Assert.Equal(50, actual.Count(x => x is false));
    }
    
    [Fact]
    public void When_NullableBoolsTrueProbability_With_100_Returns_AllTrue()
    {
        var actual = Dm.NullableBools().TrueProbability((Percentage)100).ToList();

        Assert.Equal(100, actual.Count(x => x is true));
    }
        
    [Fact]
    public void When_NullableBoolsFalseProbability_With_100_Returns_AllFalse()
    {
        var actual = Dm.NullableBools().FalseProbability((Percentage)100).ToList();

        Assert.Equal(100, actual.Count(x => x is false));
    }
            
    [Fact]
    public void When_NullableBoolsNullableProbability_With_100_Returns_AllNull()
    {
        var actual = Dm.NullableBools().NullableProbability((Percentage)100).ToList();

        Assert.Equal(100, actual.Count(x => x is null));
    }
    
    [Theory]
    [InlineData(50,50,1)]
    [InlineData(50,1,50)]
    [InlineData(1,50,50)]
    public void When_NullableBools_CombinationOfProbabilityPercentages_GreaterThanOneHundred_Throws_ArgumentOutOfRangeException(
        int nullablePercentage, int truePercentage, int falsePercentage)
    {
        Action action = () => Dm.NullableBools()
            .NullableProbability((Percentage)nullablePercentage)
            .TrueProbability((Percentage)truePercentage)
            .FalseProbability((Percentage)falsePercentage);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(0,0,-1)]
    [InlineData(0,-1,0)]
    [InlineData(-1,0,0)]
    public void When_NullableBools_CombinationOfProbabilityPercentages_LessThanZero_Throws_ArgumentOutOfRangeException(
        int nullablePercentage, int truePercentage, int falsePercentage)
    {
        Action action = () => Dm.NullableBools()
            .NullableProbability((Percentage)nullablePercentage)
            .TrueProbability((Percentage)truePercentage)
            .FalseProbability((Percentage)falsePercentage);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_NullableBools_DefaultPercentages_AsExpected()
    {
        var actual = Dm.NullableBools();

        Assert.Equal(34, actual.NullablePercentage);
        Assert.Equal(33, actual.TruePercentage);
        Assert.Equal(33, actual.FalsePercentage);
    }
    
    [Theory]
    [InlineData(34,33,33)]
    [InlineData(40,30,30)]
    [InlineData(60,20,20)]
    public void When_NullableBools_CombinationOfProbabilityPercentages_Returns_ListOfNullableBool_WithExpectedCounts(
        int nullablePercentage, int truePercentage, int falsePercentage)
    {
        var actual = Dm.NullableBools()
            .NullableProbability((Percentage)nullablePercentage)
            .TrueProbability((Percentage)truePercentage)
            .FalseProbability((Percentage)falsePercentage)
            .ToList();

        Assert.Equal(nullablePercentage, actual.Count(x => x is null));
        Assert.Equal(truePercentage, actual.Count(x => x is true));
        Assert.Equal(falsePercentage, actual.Count(x => x is false));
    }
    
    [Theory]
    [InlineData(100,0,0)]
    [InlineData(99,1,0)]
    [InlineData(98,1,1)]
    [InlineData(97,2,1)]
    public void When_NullableBools_OnlyNullableProbabilitySet_Returns_ListOfNullableBool_WithExpectedCounts(
        int nullablePercentage, int truePercentage, int falsePercentage)
    {
        var actual = Dm.NullableBools()
            .NullableProbability((Percentage)nullablePercentage)
            .ToList();

        Assert.Equal(nullablePercentage, actual.Count(x => x is null));
        Assert.Equal(truePercentage, actual.Count(x => x is true));
        Assert.Equal(falsePercentage, actual.Count(x => x is false));
    }

    [Theory]
    [InlineData(0,100,0)]
    [InlineData(1,99,0)]
    [InlineData(1,98,1)]
    [InlineData(2,97,1)]
    public void When_NullableBools_OnlyTrueProbabilitySet_Returns_ListOfNullableBool_WithExpectedCounts(
        int nullablePercentage, int truePercentage, int falsePercentage)
    {
        var actual = Dm.NullableBools()
            .TrueProbability((Percentage)truePercentage)
            .ToList();

        Assert.Equal(nullablePercentage, actual.Count(x => x is null));
        Assert.Equal(truePercentage, actual.Count(x => x is true));
        Assert.Equal(falsePercentage, actual.Count(x => x is false));
    }
    
    [Theory]
    [InlineData(0,0,100)]
    [InlineData(1,0,99)]
    [InlineData(1,1,98)]
    [InlineData(2,1,97)]
    public void When_NullableBools_OnlyFalseProbabilitySet_Returns_ListOfNullableBool_WithExpectedCounts(
        int nullablePercentage, int truePercentage, int falsePercentage)
    {
        var actual = Dm.NullableBools()
            .FalseProbability((Percentage)falsePercentage)
            .ToList();

        Assert.Equal(nullablePercentage, actual.Count(x => x is null));
        Assert.Equal(truePercentage, actual.Count(x => x is true));
        Assert.Equal(falsePercentage, actual.Count(x => x is false));
    }   
    
    [Theory]
    [InlineData(100,0,0)]
    [InlineData(99,1,0)]
    [InlineData(98,1,1)]
    [InlineData(97,2,1)]
    public void When_NullableBools_NullableAndTrueProbabilitySet_Returns_ListOfNullableBool_WithExpectedCounts(
        int nullablePercentage, int truePercentage, int falsePercentage)
    {
        var actual = Dm.NullableBools()
            .NullableProbability((Percentage)nullablePercentage)
            .TrueProbability((Percentage)truePercentage)
            .ToList();

        Assert.Equal(nullablePercentage, actual.Count(x => x is null));
        Assert.Equal(truePercentage, actual.Count(x => x is true));
        Assert.Equal(falsePercentage, actual.Count(x => x is false));
    }
    
    [Theory]
    [InlineData(100,0,0)]
    [InlineData(99,1,0)]
    [InlineData(98,1,1)]
    [InlineData(97,2,1)]
    public void When_NullableBools_NullableAndFalseProbabilitySet_Returns_ListOfNullableBool_WithExpectedCounts(
        int nullablePercentage, int truePercentage, int falsePercentage)
    {
        var actual = Dm.NullableBools()
            .NullableProbability((Percentage)nullablePercentage)
            .FalseProbability((Percentage)falsePercentage)
            .ToList();

        Assert.Equal(nullablePercentage, actual.Count(x => x is null));
        Assert.Equal(truePercentage, actual.Count(x => x is true));
        Assert.Equal(falsePercentage, actual.Count(x => x is false));
    }
    
    [Theory]
    [InlineData(100,0,0)]
    [InlineData(99,1,0)]
    [InlineData(98,1,1)]
    [InlineData(97,2,1)]
    public void When_NullableBools_TrueAndFalseProbabilitySet_Returns_ListOfNullableBool_WithExpectedCounts(
        int nullablePercentage, int truePercentage, int falsePercentage)
    {
        var actual = Dm.NullableBools()
            .TrueProbability((Percentage)truePercentage)
            .FalseProbability((Percentage)falsePercentage)
            .ToList();

        Assert.Equal(nullablePercentage, actual.Count(x => x is null));
        Assert.Equal(truePercentage, actual.Count(x => x is true));
        Assert.Equal(falsePercentage, actual.Count(x => x is false));
    }
}