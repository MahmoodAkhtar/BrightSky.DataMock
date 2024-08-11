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
}