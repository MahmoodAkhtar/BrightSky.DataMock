namespace BrightSky.DataMock.Tests;

public class MockTypeCsvTests
{
    [Fact]
    public void When_Csv_Returns_ImplOf_IMockTypeOfString()
    {
        var actual = Dm.Csv();

        Assert.IsAssignableFrom<IMockType<string>>(actual);
    }
    
    [Fact]
    public void When_Csv_Returns_MockTypeCsv()
    {
        var actual = Dm.Csv();

        Assert.IsType<MockTypeCsv>(actual);
    }
    
    [Fact]
    public void When_CsvGet_Returns_String()
    {
        var actual = Dm.Csv().Get();

        Assert.IsType<string>(actual);
    }
    
        
    [Fact]
    public void When_CsvGet_Returns_EmptyString()
    {
        var actual = Dm.Csv().Get();

        Assert.Empty(actual);
    }
}