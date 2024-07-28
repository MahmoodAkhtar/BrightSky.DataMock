namespace BrightSky.DataMock.Tests;

public class MockTypeStringTests
{
    [Fact]
    public void When_Strings_Returns_ImplOf_IMockTypeOfString()
    {
        var actual = Dm.Strings();

        Assert.IsAssignableFrom<IMockType<string>>(actual);
    }
    
    [Fact]
    public void When_Strings_Returns_MockTypeString()
    {
        var actual = Dm.Strings();

        Assert.IsType<MockTypeString>(actual);
    }
}