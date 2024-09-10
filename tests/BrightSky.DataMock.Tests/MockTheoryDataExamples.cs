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
        [SetDecimals(fix: "1.23")] decimal pSetDecimalFix,
        [SetDecimals(min: "Decimal.MinValue", max: "Decimal.MaxValue")] decimal pSetDecimalMinMax1,
        [SetDecimals(min: "decimal.MinValue", max: "decimal.MaxValue")] decimal pSetDecimalMinMax2)
    {
        var anon = new
        {
            MyDecimal1 = pSetDecimalFix,
            MyDecimal2 = pSetDecimalMinMax1,
            MyDecimal3 = pSetDecimalMinMax2,
        };

        Assert.Equal(1.23m, anon.MyDecimal1);
        Assert.Equal(pSetDecimalMinMax1, anon.MyDecimal2);
        Assert.Equal(pSetDecimalMinMax2, anon.MyDecimal3);
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
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetGuids(
        [SetGuids(fix: "a93cdf90-d7f6-4b4a-8706-0d748dc94e68")] Guid pSetGuidFix,
        [SetGuids(nonEmptyPercentage: 60, emptyPercentage: 40)] Guid pSetGuidNonEmptyEmptyPercentage)
    {
        var anon = new
        {
            MyGuid1 = pSetGuidFix,
            MyGuid2 = pSetGuidNonEmptyEmptyPercentage,
        };

        Assert.Equal(Guid.Parse("a93cdf90-d7f6-4b4a-8706-0d748dc94e68"), anon.MyGuid1);
        Assert.Equal(pSetGuidNonEmptyEmptyPercentage, anon.MyGuid2);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetDateTimes(
        [SetDateTimes(fix: "1980-09-20 04:39:57")] DateTime pSetDateTimeFix,
        [SetDateTimes(min: "2020-09-20 21:19:05", max: "2040-09-20 01:59:13")] DateTime pSetDateTimeMinMax)
    {
        var anon = new
        {
            MyDateTime1 = pSetDateTimeFix,
            MyDateTime2 = pSetDateTimeMinMax,
        };

        Assert.Equal(DateTime.Parse("1980-09-20 04:39:57"), anon.MyDateTime1);
        Assert.Equal(pSetDateTimeMinMax, anon.MyDateTime2);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableBools(
        [SetNullableBools(fix:true)] bool? pSetNullableBoolFixAsTrue,
        [SetNullableBools(fix:false)] bool? pSetNullableBoolFixAsFalse,        
        [SetNullableBools(fix:true, nullablePercentage: 37)] bool? pSetNullableBoolFixAsTrueNullablePercentage,
        [SetNullableBools(fix:false, nullablePercentage: 37)] bool? pSetNullableBoolFixAsFalseNullablePercentage,
        [SetNullableBools(only:null)] bool? pSetNullableBoolFixAsNull,
        [SetNullableBools(nullablePercentage: 40, truePercentage: 30, falsePercentage: 30)] bool? pSetNullableBoolPercentages)
    {
        var anon = new
        {
            MyBool1 = pSetNullableBoolFixAsTrue,
            MyBool2 = pSetNullableBoolFixAsFalse,
            MyBool3 = pSetNullableBoolFixAsTrueNullablePercentage,
            MyBool4 = pSetNullableBoolFixAsFalseNullablePercentage,
            MyBool5 = pSetNullableBoolFixAsNull,
            MyBool6 = pSetNullableBoolPercentages,
        };

        Assert.True(anon.MyBool1);
        Assert.False(anon.MyBool2);
        Assert.Equal(pSetNullableBoolFixAsTrueNullablePercentage, anon.MyBool3);
        Assert.Equal(pSetNullableBoolFixAsFalseNullablePercentage, anon.MyBool4);
        Assert.Null(anon.MyBool5);
        Assert.Equal(pSetNullableBoolPercentages, anon.MyBool6);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableBytes(
        [SetNullableBytes(fix:123)] byte? pSetNullableByteFix,
        [SetNullableBytes(fix:123, nullablePercentage: 37)] byte? pSetNullableByteFixNullablePercentage,
        [SetNullableBytes(only:null)] byte? pSetNullableByteAsNull,
        [SetNullableBytes(min: byte.MinValue, max: byte.MaxValue)] byte? pSetNullableByteMinMax,
        [SetNullableBytes(min: byte.MinValue, max: byte.MaxValue, nullablePercentage: 37)] byte? pSetNullableByteMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyByte1 = pSetNullableByteFix,
            MyByte2 = pSetNullableByteFixNullablePercentage,
            MyByte3 = pSetNullableByteAsNull,
            MyByte4 = pSetNullableByteMinMax,
            MyByte5 = pSetNullableByteMinMaxNullablePercentage,
        };

        Assert.Equal((byte)123, anon.MyByte1);
        Assert.Equal(pSetNullableByteFixNullablePercentage, anon.MyByte2);
        Assert.Null(anon.MyByte3);
        Assert.Equal(pSetNullableByteMinMax, anon.MyByte4);
        Assert.Equal(pSetNullableByteMinMaxNullablePercentage, anon.MyByte5);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableShorts(
        [SetNullableShorts(fix:123)] short? pSetNullableShortFix,
        [SetNullableShorts(only:null)] short? pSetNullableShortFixAsNull,
        [SetNullableShorts(min: short.MinValue, max: short.MaxValue)] short? pSetNullableShortMinMax,
        [SetNullableShorts(min: short.MinValue, max: short.MaxValue, nullablePercentage: 37)] short? pSetNullableShortMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyShort1 = pSetNullableShortFix,
            MyShort2 = pSetNullableShortFixAsNull,
            MyShort3 = pSetNullableShortMinMax,
            MyShort4 = pSetNullableShortMinMaxNullablePercentage,
        };

        Assert.Equal((byte)123, anon.MyShort1);
        Assert.Null(anon.MyShort2);
        Assert.Equal(pSetNullableShortMinMax, anon.MyShort3);
        Assert.Equal(pSetNullableShortMinMaxNullablePercentage, anon.MyShort4);
    }
        
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableInts(
        [SetNullableInts(fix:123)] int? pSetNullableIntFix,
        [SetNullableInts(only:null)] int? pSetNullableIntFixAsNull,
        [SetNullableInts(min: int.MinValue, max: int.MaxValue)] int? pSetNullableIntMinMax,
        [SetNullableInts(min: int.MinValue, max: int.MaxValue, nullablePercentage: 37)] int? pSetNullableIntMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyInt1 = pSetNullableIntFix,
            MyInt2 = pSetNullableIntFixAsNull,
            MyInt3 = pSetNullableIntMinMax,
            MyInt4 = pSetNullableIntMinMaxNullablePercentage,
        };

        Assert.Equal(123, anon.MyInt1);
        Assert.Null(anon.MyInt2);
        Assert.Equal(pSetNullableIntMinMax, anon.MyInt3);
        Assert.Equal(pSetNullableIntMinMaxNullablePercentage, anon.MyInt4);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableLongs(
        [SetNullableLongs(fix:123)] long? pSetNullableLongFix,
        [SetNullableLongs(only:null)] long? pSetNullableLongFixAsNull,
        [SetNullableLongs(min: long.MinValue, max: long.MaxValue)] long? pSetNullableLongMinMax,
        [SetNullableLongs(min: long.MinValue, max: long.MaxValue, nullablePercentage: 37)] long? pSetNullableLongMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyLong1 = pSetNullableLongFix,
            MyLong2 = pSetNullableLongFixAsNull,
            MyLong3 = pSetNullableLongMinMax,
            MyLong4 = pSetNullableLongMinMaxNullablePercentage,
        };

        Assert.Equal(123, anon.MyLong1);
        Assert.Null(anon.MyLong2);
        Assert.Equal(pSetNullableLongMinMax, anon.MyLong3);
        Assert.Equal(pSetNullableLongMinMaxNullablePercentage, anon.MyLong4);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableFloats(
        [SetNullableFloats(fix:1.23f)] float? pSetNullableFloatFix,
        [SetNullableFloats(only:null)] float? pSetNullableFloatFixAsNull,
        [SetNullableFloats(min: float.MinValue, max: float.MaxValue)] float? pSetNullableFloatMinMax,
        [SetNullableFloats(min: float.MinValue, max: float.MaxValue, nullablePercentage: 37)] float? pSetNullableFloatMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyFloat1 = pSetNullableFloatFix,
            MyFloat2 = pSetNullableFloatFixAsNull,
            MyFloat3 = pSetNullableFloatMinMax,
            MyFloat4 = pSetNullableFloatMinMaxNullablePercentage,
        };

        Assert.Equal(1.23f, anon.MyFloat1);
        Assert.Null(anon.MyFloat2);
        Assert.Equal(pSetNullableFloatMinMax, anon.MyFloat3);
        Assert.Equal(pSetNullableFloatMinMaxNullablePercentage, anon.MyFloat4);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableDoubles(
        [SetNullableDoubles(fix:1.23d)] double? pSetNullableDoubleFix,
        [SetNullableDoubles(only:null)] double? pSetNullableDoubleFixAsNull,
        [SetNullableDoubles(min: double.MinValue, max: double.MaxValue)] double? pSetNullableDoubleMinMax,
        [SetNullableDoubles(min: double.MinValue, max: double.MaxValue, nullablePercentage: 37)] double? pSetNullableDoubleMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyDouble1 = pSetNullableDoubleFix,
            MyDouble2 = pSetNullableDoubleFixAsNull,
            MyDouble3 = pSetNullableDoubleMinMax,
            MyDouble4 = pSetNullableDoubleMinMaxNullablePercentage,
        };

        Assert.Equal(1.23d, anon.MyDouble1);
        Assert.Null(anon.MyDouble2);
        Assert.Equal(pSetNullableDoubleMinMax, anon.MyDouble3);
        Assert.Equal(pSetNullableDoubleMinMaxNullablePercentage, anon.MyDouble4);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableDecimals(
        [SetNullableDecimals(fix:"1.23")] decimal? pSetNullableDecimalFix,
        [SetNullableDecimals(only:null)] decimal? pSetNullableDecimalFixAsNull,
        [SetNullableDecimals(min: "decimal.MinValue", max: "decimal.MaxValue")] decimal? pSetNullableDecimalMinMax,
        [SetNullableDecimals(min: "Decimal.MinValue", max: "Decimal.MaxValue", nullablePercentage: 37)] decimal? pSetNullableDecimalMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyDecimal1 = pSetNullableDecimalFix,
            MyDecimal2 = pSetNullableDecimalFixAsNull,
            MyDecimal3 = pSetNullableDecimalMinMax,
            MyDecimal4 = pSetNullableDecimalMinMaxNullablePercentage,
        };

        Assert.Equal(1.23m, anon.MyDecimal1);
        Assert.Null(anon.MyDecimal2);
        Assert.Equal(pSetNullableDecimalMinMax, anon.MyDecimal3);
        Assert.Equal(pSetNullableDecimalMinMaxNullablePercentage, anon.MyDecimal4);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableChars(
        [SetNullableChars(fix:'A')] char? pSetNullableCharFix,
        [SetNullableChars(fix:'A', nullablePercentage: 37)] char? pSetNullableCharFixNullablePercentage,
        [SetNullableChars(only:null)] char? pSetNullableCharAsNull,
        [SetNullableChars(from: ['B','C','D'])] char? pSetNullableCharFrom,
        [SetNullableChars(from: ['E','F','G'], excluding: ['F'])] char? pSetNullableCharFromExcluding,
        [SetNullableChars(from: ['B','C','D'], nullablePercentage: 37)] char? pSetNullableCharFromNullablePercentage,
        [SetNullableChars(from: ['E','F','G'], excluding: ['F'], nullablePercentage: 37)] char? pSetNullableCharFromExcludingNullablePercentage)
    {
        var anon = new
        {
            MyNullableChar1 = pSetNullableCharFix,
            MyNullableChar2 = pSetNullableCharFixNullablePercentage,

            MyNullableChar3 = pSetNullableCharAsNull,
            MyNullableChar4 = pSetNullableCharFrom,
            MyNullableChar5 = pSetNullableCharFromExcluding,
            MyNullableChar6 = pSetNullableCharFromNullablePercentage,
            MyNullableChar7 = pSetNullableCharFromExcludingNullablePercentage,
        };

        Assert.Equal('A', anon.MyNullableChar1);
        Assert.Equal(pSetNullableCharFixNullablePercentage, anon.MyNullableChar2);
        Assert.Null(anon.MyNullableChar3);
        Assert.Equal(pSetNullableCharFrom, anon.MyNullableChar4);
        Assert.Equal(pSetNullableCharFromExcluding, anon.MyNullableChar5);
        Assert.Equal(pSetNullableCharFromNullablePercentage, anon.MyNullableChar6);
        Assert.Equal(pSetNullableCharFromExcludingNullablePercentage, anon.MyNullableChar7);
    }}