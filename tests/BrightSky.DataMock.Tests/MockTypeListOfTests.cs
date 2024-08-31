namespace BrightSky.DataMock.Tests;

public class MockTypeListOfTests
{
    [Fact]
    public void When_ListsOfBool_Returns_ImplOf_IMockTypeOfListOfListBool()
    {
        var actual = Dm.ListsOf<bool>();

        Assert.IsAssignableFrom<IMockType<List<List<bool>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfBool_Returns_MockTypeListOfBool()
    {
        var actual = Dm.ListsOf<bool>();

        Assert.IsAssignableFrom<MockTypeListOf<bool>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfBoolGet_Returns_ListOfListOfBool()
    {
        var actual = Dm.ListsOf<bool>().Get();

        Assert.IsType<List<List<bool>>>(actual);
    }
    
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
    
    [Fact]
    public void When_ListsOfChar_Returns_ImplOf_IMockTypeOfListOfListChar()
    {
        var actual = Dm.ListsOf<char>();

        Assert.IsAssignableFrom<IMockType<List<List<char>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfChar_Returns_MockTypeListOfChar()
    {
        var actual = Dm.ListsOf<char>();

        Assert.IsAssignableFrom<MockTypeListOf<char>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfCharGet_Returns_ListOfListOfChar()
    {
        var actual = Dm.ListsOf<char>().Get();

        Assert.IsType<List<List<char>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfString_Returns_ImplOf_IMockTypeOfListOfListString()
    {
        var actual = Dm.ListsOf<string>();

        Assert.IsAssignableFrom<IMockType<List<List<string>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfString_Returns_MockTypeListOfString()
    {
        var actual = Dm.ListsOf<string>();

        Assert.IsAssignableFrom<MockTypeListOf<string>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfStringGet_Returns_ListOfListOfString()
    {
        var actual = Dm.ListsOf<string>().Get();

        Assert.IsType<List<List<string>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfGuid_Returns_ImplOf_IMockTypeOfListOfListGuid()
    {
        var actual = Dm.ListsOf<Guid>();

        Assert.IsAssignableFrom<IMockType<List<List<Guid>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfGuid_Returns_MockTypeListOfGuid()
    {
        var actual = Dm.ListsOf<Guid>();

        Assert.IsAssignableFrom<MockTypeListOf<Guid>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfGuidGet_Returns_ListOfListOfGuid()
    {
        var actual = Dm.ListsOf<Guid>().Get();

        Assert.IsType<List<List<Guid>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfDateTime_Returns_ImplOf_IMockTypeOfListOfListDateTime()
    {
        var actual = Dm.ListsOf<DateTime>();

        Assert.IsAssignableFrom<IMockType<List<List<DateTime>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfDateTime_Returns_MockTypeListOfDateTime()
    {
        var actual = Dm.ListsOf<DateTime>();

        Assert.IsAssignableFrom<MockTypeListOf<DateTime>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfDateTimeGet_Returns_ListOfListOfDateTime()
    {
        var actual = Dm.ListsOf<DateTime>().Get();

        Assert.IsType<List<List<DateTime>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfNullableBool_Returns_ImplOf_IMockTypeOfListOfListNullableBool()
    {
        var actual = Dm.ListsOf<bool?>();

        Assert.IsAssignableFrom<IMockType<List<List<bool?>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableBool_Returns_MockTypeListOfNullableBool()
    {
        var actual = Dm.ListsOf<bool?>();

        Assert.IsAssignableFrom<MockTypeListOf<bool?>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableBoolGet_Returns_ListOfListOfNullableBool()
    {
        var actual = Dm.ListsOf<bool?>().Get();

        Assert.IsType<List<List<bool?>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfNullableByte_Returns_ImplOf_IMockTypeOfListOfListNullableByte()
    {
        var actual = Dm.ListsOf<byte?>();

        Assert.IsAssignableFrom<IMockType<List<List<byte?>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableByte_Returns_MockTypeListOfNullableByte()
    {
        var actual = Dm.ListsOf<byte?>();

        Assert.IsAssignableFrom<MockTypeListOf<byte?>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableByteGet_Returns_ListOfListOfNullableByte()
    {
        var actual = Dm.ListsOf<byte?>().Get();

        Assert.IsType<List<List<byte?>>>(actual);
    }

    [Fact]
    public void When_ListsOfNullableShort_Returns_ImplOf_IMockTypeOfListOfListNullableShort()
    {
        var actual = Dm.ListsOf<short?>();

        Assert.IsAssignableFrom<IMockType<List<List<short?>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableShort_Returns_MockTypeListOfNullableShort()
    {
        var actual = Dm.ListsOf<short?>();

        Assert.IsAssignableFrom<MockTypeListOf<short?>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableShortGet_Returns_ListOfListOfNullableShort()
    {
        var actual = Dm.ListsOf<short?>().Get();

        Assert.IsType<List<List<short?>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfNullableInt_Returns_ImplOf_IMockTypeOfListOfListNullableInt()
    {
        var actual = Dm.ListsOf<int?>();

        Assert.IsAssignableFrom<IMockType<List<List<int?>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableInt_Returns_MockTypeListOfNullableInt()
    {
        var actual = Dm.ListsOf<int?>();

        Assert.IsAssignableFrom<MockTypeListOf<int?>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableIntGet_Returns_ListOfListOfNullableInt()
    {
        var actual = Dm.ListsOf<int?>().Get();

        Assert.IsType<List<List<int?>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfNullableLong_Returns_ImplOf_IMockTypeOfListOfListNullableLong()
    {
        var actual = Dm.ListsOf<long?>();

        Assert.IsAssignableFrom<IMockType<List<List<long?>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableLong_Returns_MockTypeListOfNullableLong()
    {
        var actual = Dm.ListsOf<long?>();

        Assert.IsAssignableFrom<MockTypeListOf<long?>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableLongGet_Returns_ListOfListOfNullableLong()
    {
        var actual = Dm.ListsOf<long?>().Get();

        Assert.IsType<List<List<long?>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfNullableFloat_Returns_ImplOf_IMockTypeOfListOfListNullableFloat()
    {
        var actual = Dm.ListsOf<float?>();

        Assert.IsAssignableFrom<IMockType<List<List<float?>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableFloat_Returns_MockTypeListOfNullableFloat()
    {
        var actual = Dm.ListsOf<float?>();

        Assert.IsAssignableFrom<MockTypeListOf<float?>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableFloatGet_Returns_ListOfListOfNullableFloat()
    {
        var actual = Dm.ListsOf<float?>().Get();

        Assert.IsType<List<List<float?>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfNullableDouble_Returns_ImplOf_IMockTypeOfListOfListNullableDouble()
    {
        var actual = Dm.ListsOf<double?>();

        Assert.IsAssignableFrom<IMockType<List<List<double?>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableDouble_Returns_MockTypeListOfNullableDouble()
    {
        var actual = Dm.ListsOf<double?>();

        Assert.IsAssignableFrom<MockTypeListOf<double?>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableDoubleGet_Returns_ListOfListOfNullableDouble()
    {
        var actual = Dm.ListsOf<double?>().Get();

        Assert.IsType<List<List<double?>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfNullableDecimal_Returns_ImplOf_IMockTypeOfListOfListNullableDecimal()
    {
        var actual = Dm.ListsOf<decimal?>();

        Assert.IsAssignableFrom<IMockType<List<List<decimal?>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableDecimal_Returns_MockTypeListOfNullableDecimal()
    {
        var actual = Dm.ListsOf<decimal?>();

        Assert.IsAssignableFrom<MockTypeListOf<decimal?>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableDecimalGet_Returns_ListOfListOfNullableDecimal()
    {
        var actual = Dm.ListsOf<decimal?>().Get();

        Assert.IsType<List<List<decimal?>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfNullableChar_Returns_ImplOf_IMockTypeOfListOfListNullableChar()
    {
        var actual = Dm.ListsOf<char?>();

        Assert.IsAssignableFrom<IMockType<List<List<char?>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableChar_Returns_MockTypeListOfNullableChar()
    {
        var actual = Dm.ListsOf<char?>();

        Assert.IsAssignableFrom<MockTypeListOf<char?>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableCharGet_Returns_ListOfListOfNullableChar()
    {
        var actual = Dm.ListsOf<char?>().Get();

        Assert.IsType<List<List<char?>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfNullableString_Returns_ImplOf_IMockTypeOfListOfListNullableString()
    {
        var actual = Dm.ListsOf<string?>();

        Assert.IsAssignableFrom<IMockType<List<List<string?>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableString_Returns_MockTypeListOfNullableString()
    {
        var actual = Dm.ListsOf<string?>();

        Assert.IsAssignableFrom<MockTypeListOf<string?>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableStringGet_Returns_ListOfListOfNullableString()
    {
        var actual = Dm.ListsOf<string?>().Get();

        Assert.IsType<List<List<string?>>>(actual);
    } 
    
    [Fact]
    public void When_ListsOfNullableGuid_Returns_ImplOf_IMockTypeOfListOfListNullableGuid()
    {
        var actual = Dm.ListsOf<Guid?>();

        Assert.IsAssignableFrom<IMockType<List<List<Guid?>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableGuid_Returns_MockTypeListOfNullableGuid()
    {
        var actual = Dm.ListsOf<Guid?>();

        Assert.IsAssignableFrom<MockTypeListOf<Guid?>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableGuidGet_Returns_ListOfListOfNullableGuid()
    {
        var actual = Dm.ListsOf<Guid?>().Get();

        Assert.IsType<List<List<Guid?>>>(actual);
    }
    
    [Fact]
    public void When_ListsOfNullableDateTime_Returns_ImplOf_IMockTypeOfListOfListNullableDateTime()
    {
        var actual = Dm.ListsOf<DateTime?>();

        Assert.IsAssignableFrom<IMockType<List<List<DateTime?>>>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableDateTime_Returns_MockTypeListOfNullableDateTime()
    {
        var actual = Dm.ListsOf<DateTime?>();

        Assert.IsAssignableFrom<MockTypeListOf<DateTime?>>(actual);        
    }
    
    [Fact]
    public void When_ListsOfNullableDateTimeGet_Returns_ListOfListOfNullableDateTime()
    {
        var actual = Dm.ListsOf<DateTime?>().Get();

        Assert.IsType<List<List<DateTime?>>>(actual);
    } 
}