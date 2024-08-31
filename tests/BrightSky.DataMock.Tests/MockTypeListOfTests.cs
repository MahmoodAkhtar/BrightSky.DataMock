namespace BrightSky.DataMock.Tests;

public class MockTypeListOfTests
{
    [Fact]
    public void When_ListsOfByte_Returns_ImplOf_IMockTypeOfListOfListByte()
    {
        var actual = Dm.ListsOf<byte>();

        Assert.IsAssignableFrom<IMockType<List<List<byte>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfByte_Returns_MockTypeListOfByte()
    {
        var actual = Dm.ListsOf<byte>();

        Assert.IsAssignableFrom<MockTypeListOf<byte>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfByteGet_Returns_ListOfListOfByte()
    {
        var actual = Dm.ListsOf<byte>().Get();

        Assert.IsType<List<List<byte>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfShort_Returns_ImplOf_IMockTypeOfListOfListShort()
    {
        var actual = Dm.ListsOf<short>();

        Assert.IsAssignableFrom<IMockType<List<List<short>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfByte_Returns_MockTypeListOfShort()
    {
        var actual = Dm.ListsOf<short>();

        Assert.IsAssignableFrom<MockTypeListOf<short>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfByteGet_Returns_ListOfListOfShort()
    {
        var actual = Dm.ListsOf<short>().Get();

        Assert.IsType<List<List<short>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfInt_Returns_ImplOf_IMockTypeOfListOfListInt()
    {
        var actual = Dm.ListsOf<int>();

        Assert.IsAssignableFrom<IMockType<List<List<int>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfInt_Returns_MockTypeListOfInt()
    {
        var actual = Dm.ListsOf<int>();

        Assert.IsAssignableFrom<MockTypeListOf<int>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfIntGet_Returns_ListOfListOfInt()
    {
        var actual = Dm.ListsOf<int>().Get();

        Assert.IsType<List<List<int>>>(actual);
    }
        
    [Fact]
    public void When_ListsOfLong_Returns_ImplOf_IMockTypeOfListOfListLong()
    {
        var actual = Dm.ListsOf<long>();

        Assert.IsAssignableFrom<IMockType<List<List<long>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfLong_Returns_MockTypeListOfLong()
    {
        var actual = Dm.ListsOf<long>();

        Assert.IsAssignableFrom<MockTypeListOf<long>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfLongGet_Returns_ListOfListOfLong()
    {
        var actual = Dm.ListsOf<long>().Get();

        Assert.IsType<List<List<long>>>(actual);
    }
            
    [Fact]
    public void When_ListsOfFloat_Returns_ImplOf_IMockTypeOfListOfListFloat()
    {
        var actual = Dm.ListsOf<float>();

        Assert.IsAssignableFrom<IMockType<List<List<float>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfFloat_Returns_MockTypeListOfFloat()
    {
        var actual = Dm.ListsOf<float>();

        Assert.IsAssignableFrom<MockTypeListOf<float>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfFloatGet_Returns_ListOfListOfFloat()
    {
        var actual = Dm.ListsOf<float>().Get();

        Assert.IsType<List<List<float>>>(actual);
    }
                
    [Fact]
    public void When_ListsOfDouble_Returns_ImplOf_IMockTypeOfListOfListDouble()
    {
        var actual = Dm.ListsOf<double>();

        Assert.IsAssignableFrom<IMockType<List<List<double>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfDouble_Returns_MockTypeListOfDouble()
    {
        var actual = Dm.ListsOf<double>();

        Assert.IsAssignableFrom<MockTypeListOf<double>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfDoubleGet_Returns_ListOfListOfDouble()
    {
        var actual = Dm.ListsOf<double>().Get();

        Assert.IsType<List<List<double>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfDecimal_Returns_ImplOf_IMockTypeOfListOfListDecimal()
    {
        var actual = Dm.ListsOf<decimal>();

        Assert.IsAssignableFrom<IMockType<List<List<decimal>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfDecimal_Returns_MockTypeListOfDecimal()
    {
        var actual = Dm.ListsOf<decimal>();

        Assert.IsAssignableFrom<MockTypeListOf<decimal>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfDecimalGet_Returns_ListOfListOfDecimal()
    {
        var actual = Dm.ListsOf<decimal>().Get();

        Assert.IsType<List<List<decimal>>>(actual);
    }
}