namespace BrightSky.DataMock.Tests.MockTypeExtensionsTests;

public class MockTypeBoolDistributeTrueProbabilityTests
{
    [Fact]
    public void When_SourceIsEmpty_Return_EmptyListOfBool()
    {
        var mockType = new MockTypeBool();
        var source = new List<bool>();

        var actual = source.DistributeTrueProbability(mockType.TruePercentage);
        
        Assert.Empty(actual);
    }
    
    [Fact]
    public void When_Source_ItemsAreAllTrue_And_MockTypeTruePercentage_100_Return_ListOfBool_ItemsAreAllTrue()
    {
        var mockType = new MockTypeBool().TrueProbability(100);
        var source = Enumerable.Repeat(true, 100).ToList();

        var actual = source.DistributeTrueProbability(mockType.TruePercentage);
        
        Assert.Equal(100, actual.Count(x => x is true));
    }
        
    [Fact]
    public void When_Source_ItemsAreAllFalse_And_MockTypeTruePercentage_100_Return_ListOfBool_ItemsAreAllTrue()
    {
        var mockType = new MockTypeBool().TrueProbability(100);
        var source = Enumerable.Repeat(false, 100).ToList();

        var actual = source.DistributeTrueProbability(mockType.TruePercentage);
        
        Assert.Equal(100, actual.Count(x => x is true));
    }
            
    [Fact]
    public void When_Source_ItemsAreHalfTrueAndHalfFalse_And_MockTypeTruePercentage_100_Return_ListOfBool_ItemsAreAllTrue()
    {
        var mockType = new MockTypeBool().TrueProbability(100);
        var source = Enumerable.Repeat(true, 50).ToList();
        source.AddRange(Enumerable.Repeat(false, 50));
        
        var actual = source.DistributeTrueProbability(mockType.TruePercentage);
        
        Assert.Equal(100, actual.Count(x => x is true));
    }
    
    [Theory]
    [InlineData(1, 99)]
    [InlineData(2, 98)]
    [InlineData(3, 97)]
    [InlineData(5, 95)]
    [InlineData(10, 90)]
    [InlineData(50, 50)]
    [InlineData(51, 49)]
    [InlineData(63, 37)]
    [InlineData(75, 25)]
    [InlineData(80, 20)]
    [InlineData(95, 5)]
    [InlineData(99, 1)]
    public void When_Source_ItemsAreVariablyTrueAndFalse_And_MockTypeTruePercentage_100_Return_ListOfBool_ItemsAreAllTrue(int trueCount, int falseCount)
    {
        var mockType = new MockTypeBool().TrueProbability(100);
        var source = Enumerable.Repeat(true, trueCount).ToList();
        source.AddRange(Enumerable.Repeat(false, falseCount));
        
        var actual = source.DistributeTrueProbability(mockType.TruePercentage);
        
        Assert.Equal(100, actual.Count(x => x is true));
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(51)]
    [InlineData(63)]
    [InlineData(75)]
    [InlineData(80)]
    [InlineData(95)]
    [InlineData(99)]
    [InlineData(100)]
    public void When_Source_ItemsAreHalfTrueAndHalfFalse_And_MockTypeTruePercentage_IsVariable_Return_ListOfBool_With_TrueCount_AsExpected(int truePercentage)
    {
        var mockType = new MockTypeBool().TrueProbability(truePercentage);
        var source = Enumerable.Repeat(true, 50).ToList();
        source.AddRange(Enumerable.Repeat(false, 50));
        
        var actual = source.DistributeTrueProbability(mockType.TruePercentage);
        
        Assert.Equal(truePercentage, actual.Count(x => x is true));
    }
}