namespace BrightSky.DataMock.Tests;

public class MockTypeCharTests
{
    [Fact]
    public void When_Chars_Returns_ImplOf_IMockTypeOfChar()
    {
        var actual = Dm.Chars();

        Assert.IsAssignableFrom<IMockType<char>>(actual);
    }

    [Fact]
    public void When_Chars_Returns_MockTypeChar()
    {
        var actual = Dm.Chars();

        Assert.IsType<MockTypeChar>(actual);
    }

    [Fact]
    public void When_CharsGet_Returns_Char()
    {
        var actual = Dm.Chars().Get();

        Assert.IsType<char>(actual);
    }

    [Fact]
    public void When_CharsToList_Default_Size_Returns_ListOfChar()
    {
        var actual = Dm.Chars().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<char>>(actual);
    }

    [Fact]
    public void When_CharsToList_Size_0_Returns_EmptyListOfChar()
    {
        var actual = Dm.Chars().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<char>>(actual);
    }

    [Fact]
    public void When_CharsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Chars().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_CharsToList_With_Size_Returns_ListOfChar(int size)
    {
        var actual = Dm.Chars().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<char>>(actual);
    }
}