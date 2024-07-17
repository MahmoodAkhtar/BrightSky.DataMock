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

}