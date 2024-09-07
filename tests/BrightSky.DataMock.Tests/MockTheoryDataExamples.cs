namespace BrightSky.DataMock.Tests;

public class MockTheoryDataExamples
{
    private class MockPrimitiveTheoryData : TheoryData<bool, int, double, string>
    {
        public MockPrimitiveTheoryData()
        {
            var p1Gen = Dm.Bools().ToList();
            var p2Gen = Dm.Ints().ToList();
            var p3Gen = Dm.Doubles().ToList();
            var p4Gen = Dm.Strings().ToList();

            for (var i = 0; i < p1Gen.Count; i++)
                Add(p1Gen[i], p2Gen[i], p3Gen[i], p4Gen[i]);
        }
    }
    
    [Theory]  
    [ClassData(typeof(MockPrimitiveTheoryData))]
    public void Test_MockPrimitiveTheoryData(bool p1, int p2, double p3, string p4)
    {
        var anon = new
        {
            MyBool = p1,
            MyInt = p2,
            MyDouble = p3,
            MyString = p4,
        };

        Assert.Equal(p1, anon.MyBool);
        Assert.Equal(p2, anon.MyInt);
        Assert.Equal(p3, anon.MyDouble);
        Assert.Equal(p4, anon.MyString);
    }  
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock(bool p1, int p2, double p3, string p4)
    {
        var anon = new
        {
            MyBool = p1,
            MyInt = p2,
            MyDouble = p3,
            MyString = p4,
        };

        Assert.Equal(p1, anon.MyBool);
        Assert.Equal(p2, anon.MyInt);
        Assert.Equal(p3, anon.MyDouble);
        Assert.Equal(p4, anon.MyString);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_With_ListsOfBool(List<bool> p1)
    {
        var anon = new
        {
            MyBools = p1,
        };

        Assert.Equal(p1, anon.MyBools);
    }
        
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_With_ListsOfInt(List<int> p1)
    {
        var anon = new
        {
            MyInts = p1,
        };

        Assert.Equal(p1, anon.MyInts);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_With_ListsOfDouble(List<double> p1)
    {
        var anon = new
        {
            MyDoubles = p1,
        };

        Assert.Equal(p1, anon.MyDoubles);
    }
        
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_With_ListsOfString(List<string> p1)
    {
        var anon = new
        {
            MyStrings = p1,
        };

        Assert.Equal(p1, anon.MyStrings);
    }
    
        
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_With_ListsOfNullableBool(List<bool?> p1)
    {
        var anon = new
        {
            MyNullableBools = p1,
        };

        Assert.Equal(p1, anon.MyNullableBools);
    }
        
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_With_ListsOfNullableInt(List<int?> p1)
    {
        var anon = new
        {
            MyNullableInts = p1,
        };

        Assert.Equal(p1, anon.MyNullableInts);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_With_ListsOfNullableDouble(List<double?> p1)
    {
        var anon = new
        {
            MyNullableDoubles = p1,
        };

        Assert.Equal(p1, anon.MyNullableDoubles);
    }
        
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_With_ListsOfNullableString(List<string?> p1)
    {
        var anon = new
        {
            MyNullableStrings = p1,
        };

        Assert.Equal(p1, anon.MyNullableStrings);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetBools(
        [SetBools(fix:true)] bool pSetBoolFixAsTrue,
        [SetBools(fix:false)] bool pSetBoolFixAsFalse,
        [SetBools(truePercentage: 60, falsePercentage: 40)] bool pSetBoolPercentages)
    {
        var anon = new
        {
            MyBool1 = pSetBoolFixAsTrue,
            MyBool2 = pSetBoolFixAsFalse,
            MyBool3 = pSetBoolPercentages,
        };

        Assert.True(anon.MyBool1);
        Assert.False(anon.MyBool2);
        Assert.Equal(pSetBoolPercentages, anon.MyBool3);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetBytes(
        [SetBytes(fix:123)] byte pSetByteFix,
        [SetBytes(min: 1, max: 100)] byte pSetByteMinMax)
    {
        var anon = new
        {
            MyByte1 = pSetByteFix,
            MyByte2 = pSetByteMinMax,
        };

        Assert.Equal(123, anon.MyByte1);
        Assert.Equal(pSetByteMinMax, anon.MyByte2);
    }
 
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetShorts(
        [SetShorts(fix:123)] short pSetShortFix,
        [SetShorts(min: 1, max: 100)] short pSetShortMinMax)
    {
        var anon = new
        {
            MyShort1 = pSetShortFix,
            MyShort2 = pSetShortMinMax,
        };

        Assert.Equal(123, anon.MyShort1);
        Assert.Equal(pSetShortMinMax, anon.MyShort2);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetInts(
        [SetInts(fix:123)] int pSetIntFix,
        [SetInts(min: 1, max: 100)] int pSetIntMinMax)
    {
        var anon = new
        {
            MyInt1 = pSetIntFix,
            MyInt2 = pSetIntMinMax,
        };

        Assert.Equal(123, anon.MyInt1);
        Assert.Equal(pSetIntMinMax, anon.MyInt2);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetLongs(
        [SetLongs(fix:123)] long pSetLongFix,
        [SetLongs(min: 1, max: 100)] long pSetLongMinMax)
    {
        var anon = new
        {
            MyLong1 = pSetLongFix,
            MyLong2 = pSetLongMinMax,
        };

        Assert.Equal(123, anon.MyLong1);
        Assert.Equal(pSetLongMinMax, anon.MyLong2);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetFloats(
        [SetFloats(fix:1.23f)] float pSetFloatFix,
        [SetFloats(min: 1.23f, max: 10.123f)] float pSetFloatMinMax)
    {
        var anon = new
        {
            MyFloat1 = pSetFloatFix,
            MyFloat2 = pSetFloatMinMax,
        };

        Assert.Equal(1.23f, anon.MyFloat1);
        Assert.Equal(pSetFloatMinMax, anon.MyFloat2);
    } 
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetDoubles(
        [SetDoubles(fix:1.23d)] double pSetDoubleFix,
        [SetDoubles(min: 1.23d, max: 10.123d)] double pSetDoubleMinMax)
    {
        var anon = new
        {
            MyDouble1 = pSetDoubleFix,
            MyDouble2 = pSetDoubleMinMax,
        };

        Assert.Equal(1.23d, anon.MyDouble1);
        Assert.Equal(pSetDoubleMinMax, anon.MyDouble2);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetDecimals(
        [SetDecimals(fix:"1.23")] decimal pSetDecimalFix,
        [SetDecimals(min: "1.23", max: "10.123")] decimal pSetDecimalMinMax)
    {
        var anon = new
        {
            MyDecimal1 = pSetDecimalFix,
            MyDecimal2 = pSetDecimalMinMax,
        };

        Assert.Equal(1.23m, anon.MyDecimal1);
        Assert.Equal(pSetDecimalMinMax, anon.MyDecimal2);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetChars(
        [SetChars(fix:'A')] char pSetCharFix,
        [SetChars(from: ['B','C','D'])] char pSetCharFrom,
        [SetChars(from: ['E','F','G'], excluding: ['F'])] char pSetCharFromExcluding)
    {
        var anon = new
        {
            MyChar1 = pSetCharFix,
            MyChar2 = pSetCharFrom,
            MyChar3 = pSetCharFromExcluding,
        };

        Assert.Equal('A', anon.MyChar1);
        Assert.Equal(pSetCharFrom, anon.MyChar2);
        Assert.Equal(pSetCharFromExcluding, anon.MyChar3);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetStrings(
        [SetStrings(fix:"ABC")] 
        string pSetStringFix,
        
        [SetStrings(from: ['A','B','C'])] 
        string pSetStringFrom,
        
        [SetStrings(from: ['A','B','C'], length: 5)] 
        string pSetStringFromWithLength,
        
        [SetStrings(from: ['A','B','C'], minLength: 6, maxLength: 8)] 
        string pSetStringFromWithVariableLength,
        
        [SetStrings(from: ['D','E','F'], excluding: ['D'])] 
        string pSetStringFromExcluding,
        
        [SetStrings(from: ['D','E','F'], excluding: ['E'], length: 9)] 
        string pSetStringFromExcludingWithLength,
        
        [SetStrings(from: ['D','E','F'], excluding: ['F'], minLength: 10, maxLength: 12)] 
        string pSetStringFromExcludingWithVariableLength)
    {
        var anon = new
        {
            MyString1 = pSetStringFix,
            MyString2 = pSetStringFrom,
            MyString3 = pSetStringFromWithLength,
            MyString4 = pSetStringFromWithVariableLength,
            MyString5 = pSetStringFromExcluding,
            MyString6 = pSetStringFromExcludingWithLength,
            MyString7 = pSetStringFromExcludingWithVariableLength,
        };

        var abc = new[] { 'A', 'B', 'C' };
        var ef = new[] { 'E', 'F' };
        var df = new[] { 'D', 'F' };
        var de = new[] { 'D', 'E', };
        
        Assert.Equal("ABC", anon.MyString1);
        
        Assert.Equal(pSetStringFrom, anon.MyString2);
        Assert.True(anon.MyString2.Length is 10);
        Assert.False(anon.MyString2.ToCharArray().Except(abc).Any());  
        
        Assert.Equal(pSetStringFromWithLength, anon.MyString3);
        Assert.True(anon.MyString3.Length is 5);
        Assert.False(anon.MyString3.ToCharArray().Except(abc).Any());  
        
        Assert.Equal(pSetStringFromWithVariableLength, anon.MyString4);
        Assert.True(anon.MyString4.Length is >= 6 and <= 8);
        Assert.False(anon.MyString4.ToCharArray().Except(abc).Any());
        
                
        Assert.Equal(pSetStringFromExcluding, anon.MyString5);
        Assert.True(anon.MyString5.Length is 10);
        Assert.False(anon.MyString5.ToCharArray().Except(ef).Any());  
        
        Assert.Equal(pSetStringFromExcludingWithLength, anon.MyString6);
        Assert.True(anon.MyString6.Length is 9);
        Assert.False(anon.MyString6.ToCharArray().Except(df).Any());  
        
        Assert.Equal(pSetStringFromExcludingWithVariableLength, anon.MyString7);
        Assert.True(anon.MyString7.Length is >= 10 and <= 12);
        Assert.False(anon.MyString7.ToCharArray().Except(de).Any());
    }
}