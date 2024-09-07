namespace BrightSky.DataMock.Tests;

public class MockTypeGuidTests
{
    [Fact]
    public void When_Guids_Returns_ImplOf_IMockTypeOfGuid()
    {
        var actual = Dm.Guids();

        Assert.IsAssignableFrom<IMockType<Guid>>(actual);
    }
    
    [Fact]
    public void When_Guids_Returns_MockTypeGuid()
    {
        var actual = Dm.Guids();

        Assert.IsType<MockTypeGuid>(actual);
    }
    
    [Fact]
    public void When_GuidsGet_Returns_Guid()
    {
        var actual = Dm.Guids().Get();

        Assert.IsType<Guid>(actual);
    }
    
    [Fact]
    public void When_GuidsToList_Default_Size_Returns_ListOfGuid()
    {
        var actual = Dm.Guids().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<Guid>>(actual);
    }
    
    [Fact]
    public void When_GuidsToList_Size_0_Returns_EmptyListOfGuid()
    {
        var actual = Dm.Guids().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<Guid>>(actual);
    }
    
    [Fact]
    public void When_GuidsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Guids().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_GuidsToList_With_Size_Returns_ListOfGuid(int size)
    {
        var actual = Dm.Guids().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<Guid>>(actual);
    }
    
    [Fact]
    public void When_GuidsNonEmptyProbability_Returns_MockTypeBool()
    {
        var actual = Dm.Guids().NonEmptyProbability((Percentage)1);

        Assert.IsType<MockTypeGuid>(actual);
    }
        
    [Fact]
    public void When_GuidsEmptyProbability_Returns_MockTypeBool()
    {
        var actual = Dm.Guids().EmptyProbability((Percentage)1);

        Assert.IsType<MockTypeGuid>(actual);
    }
    
    [Fact]
    public void When_GuidsNonEmptyProbability_With_0_Returns_AlwaysEmpty()
    {
        var actual = Dm.Guids().NonEmptyProbability((Percentage)0).ToList();

        Assert.True(actual.All(x => x == Guid.Empty));
    }
    
    [Fact]
    public void When_GuidsEmptyProbability_With_0_Returns_AlwaysNonEmpty()
    {
        var actual = Dm.Guids().EmptyProbability((Percentage)0).ToList();

        Assert.True(actual.All(x => x != Guid.Empty));
    }
    
    [Fact]
    public void When_GuidsNonEmptyProbability_With_100_Returns_AlwaysNonEmpty()
    {
        var actual = Dm.Guids().NonEmptyProbability((Percentage)100).ToList();

        Assert.True(actual.All(x => x != Guid.Empty));
    }
        
    [Fact]
    public void When_GuidsEmptyProbability_With_100_Returns_AlwaysEmpty()
    {
        var actual = Dm.Guids().EmptyProbability((Percentage)100).ToList();

        Assert.True(actual.All(x => x == Guid.Empty));
    }
    
    [Fact]
    public void When_GuidsToList_With_DefaultNonEmptyProbability_Returns_True_50Percent()
    {
        var actual = Dm.Guids().ToList();

        Assert.Equal(50, actual.Count(x => x != Guid.Empty));
    }
    
    [Fact]
    public void When_GuidsToList_With_DefaultEmptyProbability_Returns_True_50Percent()
    {
        var actual = Dm.Guids().ToList();

        Assert.Equal(50, actual.Count(x => x == Guid.Empty));
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
    public void When_GuidsNonEmptyProbabilityAndToList_With_NonEmptyPercentage_And_Size_Returns_ExpectedNonEmptyCount(int nonEmptyPercentage, int size)
    {
        var expected = (int)Math.Ceiling(size * (nonEmptyPercentage / 100.0m));
        var actual = Dm.Guids().NonEmptyProbability((Percentage)nonEmptyPercentage).ToList(size);

        Assert.Equal(expected, actual.Count(x => x != Guid.Empty));
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
    public void When_GuidsEmptyProbabilityAndToList_With_EmptyPercentage_And_Size_Returns_ExpectedEmptyCount(int emptyPercentage, int size)
    {
        var expected = (int)Math.Floor(size * (emptyPercentage / 100.0m));
        var actual = Dm.Guids().EmptyProbability((Percentage)emptyPercentage).ToList(size);

        Assert.Equal(expected, actual.Count(x => x == Guid.Empty));
    }
}