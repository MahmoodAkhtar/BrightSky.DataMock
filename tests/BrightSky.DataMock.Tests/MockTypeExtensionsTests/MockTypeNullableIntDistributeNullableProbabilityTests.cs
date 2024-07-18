namespace BrightSky.DataMock.Tests.MockTypeExtensionsTests;

public class MockTypeNullableIntDistributeNullableProbabilityTests
{
    [Fact]
    public void When_SourceIsEmpty_Return_EmptyListOfNullableInt()
    {
        var nullableMockType = new MockTypeNullableInt();
        var nonNullableMockType = new MockTypeInt();
        var source = new List<int?>();

        var actual = source.DistributeNullableProbability(nullableMockType, nonNullableMockType);
        
        Assert.Empty(actual);
    }
    
    [Fact]
    public void When_Source_ItemsAreAllNull_And_MockTypeNullablePercentage_100_Return_ListOfNullableInt_ItemsAreAllNull()
    {
        var nullableMockType = new MockTypeNullableInt().NullableProbability(100);
        var nonNullableMockType = new MockTypeInt();
        var source = Enumerable.Repeat((int?)null, 100).ToList();

        var actual = source.DistributeNullableProbability(nullableMockType, nonNullableMockType);
        
        Assert.Equal(100, actual.Count(x => x is null));
    }    
    
    [Fact]
    public void When_Source_ItemsAreAllNullableInt_And_MockTypeNullablePercentage_100_Return_ListOfNullableInt_ItemsAreAllNull()
    {
        var nullableMockType = new MockTypeNullableInt().NullableProbability(100);
        var nonNullableMockType = new MockTypeInt();
        var source = Enumerable.Repeat((int?)123, 100).ToList();

        var actual = source.DistributeNullableProbability(nullableMockType, nonNullableMockType);
        
        Assert.Equal(100, actual.Count(x => x is null));
    }
    
    [Fact]
    public void When_Source_ItemsAreHalfNullableIntAndHalfNull_And_MockTypeNullablePercentage_100_Return_ListOfNullableInt_ItemsAreAllNull()
    {
        var nullableMockType = new MockTypeNullableInt().NullableProbability(100);
        var nonNullableMockType = new MockTypeInt();
        var source = Enumerable.Repeat((int?)123, 50).ToList();
        source.AddRange(Enumerable.Repeat((int?)null, 50));

        var actual = source.DistributeNullableProbability(nullableMockType, nonNullableMockType);
        
        Assert.Equal(100, actual.Count(x => x is null));
    }
    
    [Fact]
    public void When_Source_ItemsAreAllNull_And_MockTypeNullablePercentage_0_Return_ListOfNullableInt_ItemsAreAllNullableInt()
    {
        var nullableMockType = new MockTypeNullableInt().NullableProbability(0);
        var nonNullableMockType = new MockTypeInt();
        var source = Enumerable.Repeat((int?)null, 100).ToList();

        var actual = source.DistributeNullableProbability(nullableMockType, nonNullableMockType);
        
        Assert.Equal(100, actual.Count(x => x.HasValue));
    } 
    
    [Fact]
    public void When_Source_ItemsAreAllNullableInt_And_MockTypeNullablePercentage_0_Return_ListOfNullableInt_ItemsAreAllNullableInt()
    {
        var nullableMockType = new MockTypeNullableInt().NullableProbability(0);
        var nonNullableMockType = new MockTypeInt();
        var source = Enumerable.Repeat((int?)123, 100).ToList();

        var actual = source.DistributeNullableProbability(nullableMockType, nonNullableMockType);
        
        Assert.Equal(100, actual.Count(x => x.HasValue));
    }
    
    [Fact]
    public void When_Source_ItemsAreHalfNullableIntAndHalfNull_And_MockTypeNullablePercentage_0_Return_ListOfNullableInt_ItemsAreAllNullableInt()
    {
        var nullableMockType = new MockTypeNullableInt().NullableProbability(0);
        var nonNullableMockType = new MockTypeInt();
        var source = Enumerable.Repeat((int?)123, 50).ToList();
        source.AddRange(Enumerable.Repeat((int?)null, 50));

        var actual = source.DistributeNullableProbability(nullableMockType, nonNullableMockType);
        
        Assert.Equal(100, actual.Count(x => x.HasValue));
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
    public void When_Source_ItemsAreVariablyNullableIntAndNull_And_MockTypeNullablePercentage_100_Return_ListOfNullableInt_ItemsAreAllNull(int nullableIntCount, int nullCount)
    {
        var nullableMockType = new MockTypeNullableInt().NullableProbability(100);
        var nonNullableMockType = new MockTypeInt();
        var source = Enumerable.Repeat((int?)123, nullableIntCount).ToList();
        source.AddRange(Enumerable.Repeat((int?)null, nullCount));

        var actual = source.DistributeNullableProbability(nullableMockType, nonNullableMockType);
        
        Assert.Equal(100, actual.Count(x => x is null));
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
    public void When_Source_ItemsAreHalfNullableIntAndHalfNull_And_MockTypeNullablePercentage_IsVariable_Return_ListOfNullableInt_With_NullableIntCount_AsExpected(int nullablePercentage)
    {
        var nullableMockType = new MockTypeNullableInt().NullableProbability(nullablePercentage);
        var nonNullableMockType = new MockTypeInt();
        var source = Enumerable.Repeat((int?)123, 50).ToList();
        source.AddRange(Enumerable.Repeat((int?)null, 50));

        var actual = source.DistributeNullableProbability(nullableMockType, nonNullableMockType);
        
        Assert.Equal(nullablePercentage, actual.Count(x => x is null));
    }
}