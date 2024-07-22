namespace BrightSky.DataMock.Tests;

public class MockTypeByteTests
{
    [Fact]
    public void When_Bytes_Returns_ImplOf_IMockTypeOfByte()
    {
        var actual = Dm.Bytes();

        Assert.IsAssignableFrom<IMockType<byte>>(actual);
    }
    
    [Fact]
    public void When_Bytes_Returns_MockTypeByte()
    {
        var actual = Dm.Bytes();

        Assert.IsType<MockTypeByte>(actual);
    }
    
    [Fact]
    public void When_BytesGet_Returns_Byte()
    {
        var actual = Dm.Bytes().Get();

        Assert.IsType<byte>(actual);
    }
        
    [Fact]
    public void When_BytesMax_Returns_MockTypeByte()
    {
        var actual = Dm.Bytes().Max(1);

        Assert.IsType<MockTypeByte>(actual);
    }  
    
    [Fact]
    public void When_BytesMax_1_Get_Returns_Byte()
    {
        var actual = Dm.Bytes().Max(1).Get();

        Assert.True(actual <= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_BytesMax_With_MaxValue_Get_Returns_Byte_LessThanOrEqualTo_MaxValue(byte maxValue)
    {
        var actual = Dm.Bytes().Max(maxValue).Get();

        Assert.True(actual <= maxValue);
    }    
    
    [Fact]
    public void When_BytesMin_Returns_MockTypeByte()
    {
        var actual = Dm.Bytes().Min(1);

        Assert.IsType<MockTypeByte>(actual);
    }  
    
    [Fact]
    public void When_BytesMin_1_Get_Returns_Byte()
    {
        var actual = Dm.Bytes().Min(1).Get();

        Assert.True(actual >= 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_BytesMin_With_MinValue_Get_Returns_Byte_GreaterThanOrEqualTo_MinValue(byte minValue)
    {
        var actual = Dm.Bytes().Min(minValue).Get();

        Assert.True(actual >= minValue);
    } 
    
    [Fact]
    public void When_BytesToList_Default_Size_Returns_ListOfByte()
    {
        var actual = Dm.Bytes().ToList();

        Assert.Equal(100, actual.Count);
        Assert.IsType<List<byte>>(actual);
    }
    
    [Fact]
    public void When_BytesToList_Size_0_Returns_EmptyListOfByte()
    {
        var actual = Dm.Bytes().ToList(0);

        Assert.Empty(actual);
        Assert.IsType<List<byte>>(actual);
    }
    
    [Fact]
    public void When_BytesToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var action = () => Dm.Bytes().ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(150)]
    public void When_BytesToList_With_Size_Returns_ListOfByte(byte size)
    {
        var actual = Dm.Bytes().ToList(size);

        Assert.Equal(size, actual.Count);
        Assert.IsType<List<byte>>(actual);
    }
    
    [Fact]
    public void When_BytesRange_With_MinValue_MaxValue_Returns_MockTypeByte()
    {
        var actual = Dm.Bytes().Range(1, 10);

        Assert.IsType<MockTypeByte>(actual);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(0,1)]
    [InlineData(1,3)]
    [InlineData(3,5)]
    [InlineData(5,10)]
    [InlineData(10,50)]
    [InlineData(50,150)]    
    [InlineData(97,150)]    
    [InlineData(98,150)]    
    [InlineData(99,150)]    
    [InlineData(100,150)]    
    [InlineData(101,150)]    
    [InlineData(103,150)]    
    [InlineData(105,150)]    
    [InlineData(197,255)]    
    [InlineData(198,255)]    
    [InlineData(199,255)]
    [InlineData(201,255)]    
    [InlineData(203,255)]    
    [InlineData(205,255)]    
    [InlineData(247,255)]    
    [InlineData(248,255)]    
    [InlineData(253,255)]  
    [InlineData(254,255)]  
    public void When_BytesRange_With_MinValue_MaxValue_Returns_Byte_WithinRangeOf_MinValue_And_MaxValue(byte minValue, byte maxValue)
    {
        var actual = Dm.Bytes().Range(minValue, maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(0,1)]
    [InlineData(1,3)]
    [InlineData(3,5)]
    [InlineData(5,10)]
    [InlineData(10,50)]
    [InlineData(50,150)]    
    [InlineData(97,150)]    
    [InlineData(98,150)]    
    [InlineData(99,150)]    
    [InlineData(100,150)]    
    [InlineData(101,150)]    
    [InlineData(103,150)]    
    [InlineData(105,150)]    
    [InlineData(197,255)]    
    [InlineData(198,255)]    
    [InlineData(199,255)]
    [InlineData(201,255)]    
    [InlineData(203,255)]    
    [InlineData(205,255)]    
    [InlineData(247,255)]    
    [InlineData(248,255)]    
    [InlineData(253,255)]  
    [InlineData(254,255)]
    public void When_BytesMinAndMaxAndGet_With_MinValue_MaxValue_Returns_Byte_WithinRangeOf_MinValue_And_MaxValue(byte minValue, byte maxValue)
    {
        var actual = Dm.Bytes().Min(minValue).Max(maxValue).Get();

        Assert.True(actual >= minValue && actual <= maxValue);
    }

    [Fact]
    public void When_BytesRange_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Bytes().Range(minValue: 100, maxValue: 1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_BytesMinAndMaxAndGet_With_MaxValue_LessThan_MinValue_Throws_ArgumentOutOfRangeException()
    {
        Action action = () => Dm.Bytes().Min(minValue: 100).Max(maxValue: 1).Get();

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
}