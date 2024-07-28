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
    
    [Fact]
    public void When_StringsGet_Returns_String()
    {
        var actual = Dm.Strings().Get();

        Assert.IsType<string>(actual);
    }
    
    [Fact]
    public void When_Strings_Default_Length_Returns_DefaultLength()
    {
        var actual = Dm.Strings();

        Assert.Equal(10, actual.Length);
        Assert.IsType<MockTypeString>(actual);
    }
        
    [Fact]
    public void When_StringsGet_Default_Length_Returns_String_DefaultLength()
    {
        var actual = Dm.Strings().Get();

        Assert.Equal(10, actual.Length);
        Assert.IsType<string>(actual);
    }
}