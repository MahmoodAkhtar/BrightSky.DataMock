﻿namespace BrightSky.DataMock.Tests;

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
    public void Test_AutoDataMock_With_ListsOfNullableByte(List<byte?> p1)
    {
        var anon = new
        {
            MyNullableBytes = p1,
        };

        Assert.Equal(p1, anon.MyNullableBytes);
    }
        
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_With_ListsOfNullableShort(List<short?> p1)
    {
        var anon = new
        {
            MyNullableShorts = p1,
        };

        Assert.Equal(p1, anon.MyNullableShorts);
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
    
    [Fact]  
    public void Test_ListsOfNullableString_OneOf()
    {
        var mt = new MockTypeListOfNullableString()
            .NullableProbability(Percentage.MinValue)
            .OneOf(["ABC"]);

        var actual = mt.Get();

        Assert.Equal(Enumerable.Repeat("ABC", 100), actual);
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
        [SetGuids(fix: "2c104c00-38cd-417e-ad7f-4c1ae33b9694", fixPercentage: 60, emptyPercentage: 40)] Guid pSetGuidFixFixEmptyPercentage,
        [SetGuids(nonEmptyPercentage: 60, emptyPercentage: 40)] Guid pSetGuidNonEmptyEmptyPercentage)
    {
        var anon = new
        {
            MyGuid1 = pSetGuidFix,
            MyGuid2 = pSetGuidFixFixEmptyPercentage,
            MyGuid3 = pSetGuidNonEmptyEmptyPercentage,
        };

        Assert.Equal(Guid.Parse("a93cdf90-d7f6-4b4a-8706-0d748dc94e68"), anon.MyGuid1);
        Assert.Equal(pSetGuidFixFixEmptyPercentage, anon.MyGuid2);
        Assert.Equal(pSetGuidNonEmptyEmptyPercentage, anon.MyGuid3);
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
        [SetNullableShorts(fix:123, nullablePercentage: 37)] short? pSetNullableShortFixNullablePercentage,
        [SetNullableShorts(only:null)] short? pSetNullableShortAsNull,
        [SetNullableShorts(min: short.MinValue, max: short.MaxValue)] short? pSetNullableShortMinMax,
        [SetNullableShorts(min: short.MinValue, max: short.MaxValue, nullablePercentage: 37)] short? pSetNullableShortMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyNullableShort1 = pSetNullableShortFix,
            MyNullableShort2 = pSetNullableShortFixNullablePercentage,
            MyNullableShort3 = pSetNullableShortAsNull,
            MyNullableShort4 = pSetNullableShortMinMax,
            MyNullableShort5 = pSetNullableShortMinMaxNullablePercentage,
        };

        Assert.Equal((byte)123, anon.MyNullableShort1);
        Assert.Equal(pSetNullableShortFixNullablePercentage, anon.MyNullableShort2);
        Assert.Null(anon.MyNullableShort3);
        Assert.Equal(pSetNullableShortMinMax, anon.MyNullableShort4);
        Assert.Equal(pSetNullableShortMinMaxNullablePercentage, anon.MyNullableShort5);
    }
        
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableInts(
        [SetNullableInts(fix:123)] int? pSetNullableIntFix,
        [SetNullableInts(fix:123, nullablePercentage: 37)] int? pSetNullableIntFixNullablePercentage,
        [SetNullableInts(only:null)] int? pSetNullableIntAsNull,
        [SetNullableInts(min: int.MinValue, max: int.MaxValue)] int? pSetNullableIntMinMax,
        [SetNullableInts(min: int.MinValue, max: int.MaxValue, nullablePercentage: 37)] int? pSetNullableIntMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyNullableInt1 = pSetNullableIntFix,
            MyNullableInt2 = pSetNullableIntFixNullablePercentage,
            MyNullableInt3 = pSetNullableIntAsNull,
            MyNullableInt4 = pSetNullableIntMinMax,
            MyNullableInt5 = pSetNullableIntMinMaxNullablePercentage,
        };

        Assert.Equal(123, anon.MyNullableInt1);
        Assert.Equal(pSetNullableIntFixNullablePercentage, anon.MyNullableInt2);
        Assert.Null(anon.MyNullableInt3);
        Assert.Equal(pSetNullableIntMinMax, anon.MyNullableInt4);
        Assert.Equal(pSetNullableIntMinMaxNullablePercentage, anon.MyNullableInt5);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableLongs(
        [SetNullableLongs(fix:123)] long? pSetNullableLongFix,
        [SetNullableLongs(fix:123, nullablePercentage: 37)] long? pSetNullableLongFixNullablePercentage,
        [SetNullableLongs(only:null)] long? pSetNullableLongAsNull,
        [SetNullableLongs(min: long.MinValue, max: long.MaxValue)] long? pSetNullableLongMinMax,
        [SetNullableLongs(min: long.MinValue, max: long.MaxValue, nullablePercentage: 37)] long? pSetNullableLongMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyNullableLong1 = pSetNullableLongFix,
            MyNullableLong2 = pSetNullableLongFixNullablePercentage,
            MyNullableLong3 = pSetNullableLongAsNull,
            MyNullableLong4 = pSetNullableLongMinMax,
            MyNullableLong5 = pSetNullableLongMinMaxNullablePercentage,
        };

        Assert.Equal(123, anon.MyNullableLong1);
        Assert.Equal(pSetNullableLongFixNullablePercentage, anon.MyNullableLong2);
        Assert.Null(anon.MyNullableLong3);
        Assert.Equal(pSetNullableLongMinMax, anon.MyNullableLong4);
        Assert.Equal(pSetNullableLongMinMaxNullablePercentage, anon.MyNullableLong5);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableFloats(
        [SetNullableFloats(fix:1.23f)] float? pSetNullableFloatFix,
        [SetNullableFloats(fix:1.23f, nullablePercentage: 37)] float? pSetNullableFloatFixNullablePercentage,
        [SetNullableFloats(only:null)] float? pSetNullableFloatFixAsNull,
        [SetNullableFloats(min: float.MinValue, max: float.MaxValue)] float? pSetNullableFloatMinMax,
        [SetNullableFloats(min: float.MinValue, max: float.MaxValue, nullablePercentage: 37)] float? pSetNullableFloatMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyFloat1 = pSetNullableFloatFix,
            MyFloat2 = pSetNullableFloatFixNullablePercentage,
            MyFloat3 = pSetNullableFloatFixAsNull,
            MyFloat4 = pSetNullableFloatMinMax,
            MyFloat5 = pSetNullableFloatMinMaxNullablePercentage,
        };

        Assert.Equal(1.23f, anon.MyFloat1);
        Assert.Equal(pSetNullableFloatFixNullablePercentage, anon.MyFloat2);
        Assert.Null(anon.MyFloat3);
        Assert.Equal(pSetNullableFloatMinMax, anon.MyFloat4);
        Assert.Equal(pSetNullableFloatMinMaxNullablePercentage, anon.MyFloat5);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableDoubles(
        [SetNullableDoubles(fix:1.23d)] double? pSetNullableDoubleFix,
        [SetNullableDoubles(fix:1.23d, nullablePercentage: 37)] double? pSetNullableDoubleFixNullablePercentage,
        [SetNullableDoubles(only:null)] double? pSetNullableDoubleFixAsNull,
        [SetNullableDoubles(min: double.MinValue, max: double.MaxValue)] double? pSetNullableDoubleMinMax,
        [SetNullableDoubles(min: double.MinValue, max: double.MaxValue, nullablePercentage: 37)] double? pSetNullableDoubleMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyDouble1 = pSetNullableDoubleFix,
            MyDouble2 = pSetNullableDoubleFixNullablePercentage,
            MyDouble3 = pSetNullableDoubleFixAsNull,
            MyDouble4 = pSetNullableDoubleMinMax,
            MyDouble5 = pSetNullableDoubleMinMaxNullablePercentage,
        };

        Assert.Equal(1.23d, anon.MyDouble1);
        Assert.Equal(pSetNullableDoubleFixNullablePercentage, anon.MyDouble2);
        Assert.Null(anon.MyDouble3);
        Assert.Equal(pSetNullableDoubleMinMax, anon.MyDouble4);
        Assert.Equal(pSetNullableDoubleMinMaxNullablePercentage, anon.MyDouble5);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableDecimals(
        [SetNullableDecimals(fix:"1.23")] decimal? pSetNullableDecimalFix,
        [SetNullableDecimals(fix:"1.23", nullablePercentage: 37)] decimal? pSetNullableDecimalFixNullablePercentage,
        [SetNullableDecimals(only:null)] decimal? pSetNullableDecimalFixAsNull,
        [SetNullableDecimals(min: "decimal.MinValue", max: "decimal.MaxValue")] decimal? pSetNullableDecimalMinMax,
        [SetNullableDecimals(min: "Decimal.MinValue", max: "Decimal.MaxValue", nullablePercentage: 37)] decimal? pSetNullableDecimalMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyDecimal1 = pSetNullableDecimalFix,
            MyDecimal2 = pSetNullableDecimalFixNullablePercentage,
            MyDecimal3 = pSetNullableDecimalFixAsNull,
            MyDecimal4 = pSetNullableDecimalMinMax,
            MyDecimal5 = pSetNullableDecimalMinMaxNullablePercentage,
        };

        Assert.Equal(1.23m, anon.MyDecimal1);
        Assert.Equal(pSetNullableDecimalFixNullablePercentage, anon.MyDecimal2);
        Assert.Null(anon.MyDecimal3);
        Assert.Equal(pSetNullableDecimalMinMax, anon.MyDecimal4);
        Assert.Equal(pSetNullableDecimalMinMaxNullablePercentage, anon.MyDecimal5);
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
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableStrings(
        [SetNullableStrings(fix: "ABC")] string? pSetNullableStringFix,
        [SetNullableStrings(fix: "ABC", nullablePercentage: 37)] string? pSetNullableStringFixNullablePercentage,
        [SetNullableStrings(only: null)] string? pSetNullableStringAsNull,
        [SetNullableStrings(from: ['B','C','D'])] string? pSetNullableStringFrom,
        [SetNullableStrings(from: ['E','F','G'], excluding: ['F'])] string? pSetNullableStringFromExcluding,
        [SetNullableStrings(from: ['B','C','D'], nullablePercentage: 37)] string? pSetNullableStringFromNullablePercentage,
        [SetNullableStrings(from: ['E','F','G'], excluding: ['F'], nullablePercentage: 37)] string? pSetNullableStringFromExcludingNullablePercentage)
    {
        var anon = new
        {
            MyNullableString1 = pSetNullableStringFix,
            MyNullableString2 = pSetNullableStringFixNullablePercentage,
            MyNullableString3 = pSetNullableStringAsNull,
            MyNullableString4 = pSetNullableStringFrom,
            MyNullableString5 = pSetNullableStringFromExcluding,
            MyNullableString6 = pSetNullableStringFromNullablePercentage,
            MyNullableString7 = pSetNullableStringFromExcludingNullablePercentage,
        };

        Assert.Equal("ABC", anon.MyNullableString1);
        Assert.Equal(pSetNullableStringFixNullablePercentage, anon.MyNullableString2);
        Assert.Null(anon.MyNullableString3);
        Assert.Equal(pSetNullableStringFrom, anon.MyNullableString4);
        Assert.Equal(pSetNullableStringFromExcluding, anon.MyNullableString5);
        Assert.Equal(pSetNullableStringFromNullablePercentage, anon.MyNullableString6);
        Assert.Equal(pSetNullableStringFromExcludingNullablePercentage, anon.MyNullableString7);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableGuids(
        [SetNullableGuids(fix: "a93cdf90-d7f6-4b4a-8706-0d748dc94e68")] Guid? pSetNullableGuidFix,
        [SetNullableGuids(only: null)] Guid? pSetNullableGuidAsNull,
        [SetNullableGuids(fix: "a93cdf90-d7f6-4b4a-8706-0d748dc94e68", nullablePercentage: 30)] Guid? pSetNullableGuidFixNullablePercentage,
        [SetNullableGuids(fix: "2c104c00-38cd-417e-ad7f-4c1ae33b9694", fixPercentage: 60, emptyPercentage: 40)] Guid? pSetNullableGuidFixFixEmptyPercentage,
        [SetNullableGuids(fix: "17d96410-2c92-4dcd-a368-211c6c73dbd2", fixPercentage: 50, emptyPercentage: 30, nullablePercentage: 20)] Guid? pSetNullableGuidFixFixEmptyNullablePercentage,
        [SetNullableGuids(nonEmptyPercentage: 50, emptyPercentage: 30, nullablePercentage: 20)] Guid? pSetNullableGuidFixNonEmptyEmptyNullablePercentage)
    {
        var anon = new
        {
            MyGuid1 = pSetNullableGuidFix,
            MyGuid2 = pSetNullableGuidAsNull,
            MyGuid3 = pSetNullableGuidFixNullablePercentage,
            MyGuid4 = pSetNullableGuidFixFixEmptyPercentage,
            MyGuid5 = pSetNullableGuidFixFixEmptyNullablePercentage,
            MyGuid6 = pSetNullableGuidFixNonEmptyEmptyNullablePercentage,
        };

        Assert.Equal(Guid.Parse("a93cdf90-d7f6-4b4a-8706-0d748dc94e68"), anon.MyGuid1);
        Assert.Null(anon.MyGuid2);
        Assert.Equal(pSetNullableGuidFixNullablePercentage, anon.MyGuid3);
        Assert.Equal(pSetNullableGuidFixFixEmptyPercentage, anon.MyGuid4);
        Assert.Equal(pSetNullableGuidFixFixEmptyNullablePercentage, anon.MyGuid5);
        Assert.Equal(pSetNullableGuidFixNonEmptyEmptyNullablePercentage, anon.MyGuid6);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetNullableDateTimes(
        [SetNullableDateTimes(fix: "1980-09-02 12:34:56.789")] DateTime? pSetNullableDateTimeFix,
        [SetNullableDateTimes(fix: "1980-09-02 12:34:56.789", nullablePercentage: 37)] DateTime? pSetNullableDateTimeFixNullablePercentage,
        [SetNullableDateTimes(only: null)] DateTime? pSetNullableDateTimeAsNull,
        [SetNullableDateTimes(min: "1980-09-02 12:34:56.789", max: "1988-09-02 12:34:56.789")] DateTime? pSetNullableDateTimeMinMax,
        [SetNullableDateTimes(min: "1980-09-02 12:34:56.789", max: "1988-09-02 12:34:56.789", nullablePercentage: 37)] DateTime? pSetNullableDateTimeMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyNullableDateTime1 = pSetNullableDateTimeFix,
            MyNullableDateTime2 = pSetNullableDateTimeFixNullablePercentage,
            MyNullableDateTime3 = pSetNullableDateTimeAsNull,
            MyNullableDateTime4 = pSetNullableDateTimeMinMax,
            MyNullableDateTime5 = pSetNullableDateTimeMinMaxNullablePercentage,
        };

        Assert.Equal(DateTime.Parse("1980-09-02 12:34:56.789"), anon.MyNullableDateTime1);
        Assert.Equal(pSetNullableDateTimeFixNullablePercentage, anon.MyNullableDateTime2);
        Assert.Null(anon.MyNullableDateTime3);
        Assert.Equal(pSetNullableDateTimeMinMax, anon.MyNullableDateTime4);
        Assert.Equal(pSetNullableDateTimeMinMaxNullablePercentage, anon.MyNullableDateTime5);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfBool(
        [SetListOfBools(fix:true)] List<bool> pSetListOfBoolFixAsTrue,
        [SetListOfBools(fix:false)] List<bool> pSetListOfBoolFixAsFalse,
        [SetListOfBools(truePercentage: 60, falsePercentage: 40)] List<bool> pSetListOfBoolPercentages)
    {
        var anon = new
        {
            MyListOfBool1 = pSetListOfBoolFixAsTrue,
            MyListOfBool2 = pSetListOfBoolFixAsFalse,
            MyListOfBool3 = pSetListOfBoolPercentages,
        };

        Assert.Contains(true, anon.MyListOfBool1);
        Assert.Contains(false, anon.MyListOfBool2);
        Assert.Equal(pSetListOfBoolPercentages, anon.MyListOfBool3);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfNullableBool(
        [SetListOfNullableBools(fix:true)] List<bool?> pSetListOfNullableBoolFixAsTrue,
        [SetListOfNullableBools(fix:false)] List<bool?> pSetListOfNullableBoolFixAsFalse,
        [SetListOfNullableBools(only: null)] List<bool?> pSetListOfNullableBoolAsNull,
        [SetListOfNullableBools(fix:true, nullablePercentage: 37)] List<bool?> pSetListOfNullableBoolFixAsTrueNullablePercentage,
        [SetListOfNullableBools(fix:false, nullablePercentage: 37)] List<bool?> pSetListOfNullableBoolFixAsFalseNullablePercentage,
        [SetListOfNullableBools(truePercentage: 30, falsePercentage: 20, nullablePercentage: 50)] List<bool?> pSetListOfNullableBoolPercentages)
    {
        var anon = new
        {
            MyListOfNullableBool1 = pSetListOfNullableBoolFixAsTrue,
            MyListOfNullableBool2 = pSetListOfNullableBoolFixAsFalse,
            MyListOfNullableBool3 = pSetListOfNullableBoolAsNull,
            MyListOfNullableBool4 = pSetListOfNullableBoolFixAsTrueNullablePercentage,
            MyListOfNullableBool5 = pSetListOfNullableBoolFixAsFalseNullablePercentage,
            MyListOfNullableBool6 = pSetListOfNullableBoolPercentages,
        };

        Assert.All(anon.MyListOfNullableBool1, Assert.True);
        Assert.All(anon.MyListOfNullableBool2, Assert.False);
        Assert.All(anon.MyListOfNullableBool3, Assert.Null);
        Assert.Equal(pSetListOfNullableBoolFixAsTrueNullablePercentage, anon.MyListOfNullableBool4);
        Assert.Equal(pSetListOfNullableBoolFixAsFalseNullablePercentage, anon.MyListOfNullableBool5);
        Assert.Equal(pSetListOfNullableBoolPercentages, anon.MyListOfNullableBool6);
    }
    
    [Theory]
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfBytes(
        [SetListOfBytes(fix:123)] List<byte> pSetListOfByteFix,
        [SetListOfBytes(min: byte.MinValue, max: byte.MaxValue)] List<byte> pSetListOfByteMinMax)
    {
        var anon = new
        {
            MyListOfByte1 = pSetListOfByteFix,
            MyListOfByte2 = pSetListOfByteMinMax,
        };

        Assert.All(anon.MyListOfByte1, x => Assert.Equal((byte)123, x));
        Assert.Equal(pSetListOfByteMinMax, anon.MyListOfByte2);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfNullableBytes(
        [SetListOfNullableBytes(fix:123)] List<byte?> pSetListOfNullableByteFix,
        [SetListOfNullableBytes(fix:123, nullablePercentage: 37)] List<byte?> pSetListOfNullableByteFixNullablePercentage,
        [SetListOfNullableBytes(only:null)] List<byte?> pSetListOfNullableByteAsNull,
        [SetListOfNullableBytes(min: byte.MinValue, max: byte.MaxValue)] List<byte?> pSetListOfNullableByteMinMax,
        [SetListOfNullableBytes(min: byte.MinValue, max: byte.MaxValue, nullablePercentage: 37)] List<byte?> pSetListOfNullableByteMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyListOfNullableByte1 = pSetListOfNullableByteFix,
            MyListOfNullableByte2 = pSetListOfNullableByteFixNullablePercentage,
            MyListOfNullableByte3 = pSetListOfNullableByteAsNull,
            MyListOfNullableByte4 = pSetListOfNullableByteMinMax,
            MyListOfNullableByte5 = pSetListOfNullableByteMinMaxNullablePercentage,
        };

        Assert.All(anon.MyListOfNullableByte1, x => Assert.Equal((byte?)123, x));
        Assert.Equal(pSetListOfNullableByteFixNullablePercentage, anon.MyListOfNullableByte2);
        Assert.All(anon.MyListOfNullableByte3, Assert.Null);
        Assert.Equal(pSetListOfNullableByteMinMax, anon.MyListOfNullableByte4);
        Assert.Equal(pSetListOfNullableByteMinMaxNullablePercentage, anon.MyListOfNullableByte5);
    }
    
    [Theory]
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfShorts(
        [SetListOfShorts(fix:123)] List<short> pSetListOfShortFix,
        [SetListOfShorts(min: short.MinValue, max: short.MaxValue)] List<short> pSetListOfShortMinMax)
    {
        var anon = new
        {
            MyListOfShort1 = pSetListOfShortFix,
            MyListOfShort2 = pSetListOfShortMinMax,
        };

        Assert.All(anon.MyListOfShort1, x => Assert.Equal((short)123, x));
        Assert.Equal(pSetListOfShortMinMax, anon.MyListOfShort2);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfNullableShorts(
        [SetListOfNullableShorts(fix:123)] List<short?> pSetListOfNullableShortFix,
        [SetListOfNullableShorts(fix:123, nullablePercentage: 37)] List<short?> pSetListOfNullableShortFixNullablePercentage,
        [SetListOfNullableShorts(only:null)] List<short?> pSetListOfNullableShortAsNull,
        [SetListOfNullableShorts(min: short.MinValue, max: short.MaxValue)] List<short?> pSetListOfNullableShortMinMax,
        [SetListOfNullableShorts(min: short.MinValue, max: short.MaxValue, nullablePercentage: 37)] List<short?> pSetListOfNullableShortMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyListOfNullableShot1 = pSetListOfNullableShortFix,
            MyListOfNullableShot2 = pSetListOfNullableShortFixNullablePercentage,
            MyListOfNullableShot3 = pSetListOfNullableShortAsNull,
            MyListOfNullableShot4 = pSetListOfNullableShortMinMax,
            MyListOfNullableShot5 = pSetListOfNullableShortMinMaxNullablePercentage,
        };

        Assert.All(anon.MyListOfNullableShot1, x => Assert.Equal((short?)123, x));
        Assert.Equal(pSetListOfNullableShortFixNullablePercentage, anon.MyListOfNullableShot2);
        Assert.All(anon.MyListOfNullableShot3, Assert.Null);
        Assert.Equal(pSetListOfNullableShortMinMax, anon.MyListOfNullableShot4);
        Assert.Equal(pSetListOfNullableShortMinMaxNullablePercentage, anon.MyListOfNullableShot5);
    }
        
    [Theory]
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfInts(
        [SetListOfInts(fix:123)] List<int> pSetListOfIntFix,
        [SetListOfInts(min: int.MinValue, max: int.MaxValue)] List<int> pSetListOfIntMinMax)
    {
        var anon = new
        {
            MyListOfInt1 = pSetListOfIntFix,
            MyListOfInt2 = pSetListOfIntMinMax,
        };

        Assert.All(anon.MyListOfInt1, x => Assert.Equal((int)123, x));
        Assert.Equal(pSetListOfIntMinMax, anon.MyListOfInt2);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfNullableInts(
        [SetListOfNullableInts(fix:123)] List<int?> pSetListOfNullableIntFix,
        [SetListOfNullableInts(fix:123, nullablePercentage: 37)] List<int?> pSetListOfNullableIntFixNullablePercentage,
        [SetListOfNullableInts(only:null)] List<int?> pSetListOfNullableIntAsNull,
        [SetListOfNullableInts(min: int.MinValue, max: int.MaxValue)] List<int?> pSetListOfNullableIntMinMax,
        [SetListOfNullableInts(min: int.MinValue, max: int.MaxValue, nullablePercentage: 37)] List<int?> pSetListOfNullableIntMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyListOfNullableInt1 = pSetListOfNullableIntFix,
            MyListOfNullableInt2 = pSetListOfNullableIntFixNullablePercentage,
            MyListOfNullableInt3 = pSetListOfNullableIntAsNull,
            MyListOfNullableInt4 = pSetListOfNullableIntMinMax,
            MyListOfNullableInt5 = pSetListOfNullableIntMinMaxNullablePercentage,
        };

        Assert.All(anon.MyListOfNullableInt1, x => Assert.Equal((int?)123, x));
        Assert.Equal(pSetListOfNullableIntFixNullablePercentage, anon.MyListOfNullableInt2);
        Assert.All(anon.MyListOfNullableInt3, Assert.Null);
        Assert.Equal(pSetListOfNullableIntMinMax, anon.MyListOfNullableInt4);
        Assert.Equal(pSetListOfNullableIntMinMaxNullablePercentage, anon.MyListOfNullableInt5);
    }
    
    [Theory]
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfLongs(
        [SetListOfLongs(fix:123)] List<long> pSetListOfLongFix,
        [SetListOfLongs(min: long.MinValue, max: long.MaxValue)] List<long> pSetListOfLongMinMax)
    {
        var anon = new
        {
            MyListOfLong1 = pSetListOfLongFix,
            MyListOfLong2 = pSetListOfLongMinMax,
        };

        Assert.All(anon.MyListOfLong1, x => Assert.Equal((long)123, x));
        Assert.Equal(pSetListOfLongMinMax, anon.MyListOfLong2);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfNullableLongs(
        [SetListOfNullableLongs(fix:123)] List<long?> pSetListOfNullableLongFix,
        [SetListOfNullableLongs(fix:123, nullablePercentage: 37)] List<long?> pSetListOfNullableLongFixNullablePercentage,
        [SetListOfNullableLongs(only:null)] List<long?> pSetListOfNullableLongAsNull,
        [SetListOfNullableLongs(min: long.MinValue, max: long.MaxValue)] List<long?> pSetListOfNullableLongMinMax,
        [SetListOfNullableLongs(min: long.MinValue, max: long.MaxValue, nullablePercentage: 37)] List<long?> pSetListOfNullableLongMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyListOfNullableLong1 = pSetListOfNullableLongFix,
            MyListOfNullableLong2 = pSetListOfNullableLongFixNullablePercentage,
            MyListOfNullableLong3 = pSetListOfNullableLongAsNull,
            MyListOfNullableLong4 = pSetListOfNullableLongMinMax,
            MyListOfNullableLong5 = pSetListOfNullableLongMinMaxNullablePercentage,
        };

        Assert.All(anon.MyListOfNullableLong1, x => Assert.Equal((long?)123, x));
        Assert.Equal(pSetListOfNullableLongFixNullablePercentage, anon.MyListOfNullableLong2);
        Assert.All(anon.MyListOfNullableLong3, Assert.Null);
        Assert.Equal(pSetListOfNullableLongMinMax, anon.MyListOfNullableLong4);
        Assert.Equal(pSetListOfNullableLongMinMaxNullablePercentage, anon.MyListOfNullableLong5);
    }
    
    [Theory]
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfFloats(
        [SetListOfFloats(fix:1.23f)] List<float> pSetListOfFloatFix,
        [SetListOfFloats(min: float.MinValue, max: float.MaxValue)] List<float> pSetListOfFloatMinMax)
    {
        var anon = new
        {
            MyListOfFloat1 = pSetListOfFloatFix,
            MyListOfFloat2 = pSetListOfFloatMinMax,
        };

        Assert.All(anon.MyListOfFloat1, x => Assert.Equal((float)1.23f, x));
        Assert.Equal(pSetListOfFloatMinMax, anon.MyListOfFloat2);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfNullableFloats(
        [SetListOfNullableFloats(fix:1.23f)] List<float?> pSetListOfNullableFloatFix,
        [SetListOfNullableFloats(fix:1.23f, nullablePercentage: 37)] List<float?> pSetListOfNullableFloatFixNullablePercentage,
        [SetListOfNullableFloats(only:null)] List<float?> pSetListOfNullableFloatAsNull,
        [SetListOfNullableFloats(min: float.MinValue, max: float.MaxValue)] List<float?> pSetListOfNullableFloatMinMax,
        [SetListOfNullableFloats(min: float.MinValue, max: float.MaxValue, nullablePercentage: 37)] List<float?> pSetListOfNullableFloatMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyListOfNullableFloat1 = pSetListOfNullableFloatFix,
            MyListOfNullableFloat2 = pSetListOfNullableFloatFixNullablePercentage,
            MyListOfNullableFloat3 = pSetListOfNullableFloatAsNull,
            MyListOfNullableFloat4 = pSetListOfNullableFloatMinMax,
            MyListOfNullableFloat5 = pSetListOfNullableFloatMinMaxNullablePercentage,
        };

        Assert.All(anon.MyListOfNullableFloat1, x => Assert.Equal((float?)1.23f, x));
        Assert.Equal(pSetListOfNullableFloatFixNullablePercentage, anon.MyListOfNullableFloat2);
        Assert.All(anon.MyListOfNullableFloat3, Assert.Null);
        Assert.Equal(pSetListOfNullableFloatMinMax, anon.MyListOfNullableFloat4);
        Assert.Equal(pSetListOfNullableFloatMinMaxNullablePercentage, anon.MyListOfNullableFloat5);
    }
    
    [Theory]
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfDoubles(
        [SetListOfDoubles(fix:1.23d)] List<double> pSetListOfDoubleFix,
        [SetListOfDoubles(min: double.MinValue, max: double.MaxValue)] List<double> pSetListOfDoubleMinMax)
    {
        var anon = new
        {
            MyListOfDouble1 = pSetListOfDoubleFix,
            MyListOfDouble2 = pSetListOfDoubleMinMax,
        };

        Assert.All(anon.MyListOfDouble1, x => Assert.Equal((double)1.23d, x));
        Assert.Equal(pSetListOfDoubleMinMax, anon.MyListOfDouble2);
    }

    [Theory]
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfNullableDoubles(
        [SetListOfNullableDoubles(fix: 1.23d)] List<double?> pSetListOfNullableDoubleFix,
        [SetListOfNullableDoubles(fix: 1.23d, nullablePercentage: 37)]
        List<double?> pSetListOfNullableDoubleFixNullablePercentage,
        [SetListOfNullableDoubles(only: null)] List<double?> pSetListOfNullableDoubleAsNull,
        [SetListOfNullableDoubles(min: double.MinValue, max: double.MaxValue)]
        List<double?> pSetListOfNullableDoubleMinMax,
        [SetListOfNullableDoubles(min: double.MinValue, max: double.MaxValue, nullablePercentage: 37)]
        List<double?> pSetListOfNullableDoubleMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyListOfNullableDouble1 = pSetListOfNullableDoubleFix,
            MyListOfNullableDouble2 = pSetListOfNullableDoubleFixNullablePercentage,
            MyListOfNullableDouble3 = pSetListOfNullableDoubleAsNull,
            MyListOfNullableDouble4 = pSetListOfNullableDoubleMinMax,
            MyListOfNullableDouble5 = pSetListOfNullableDoubleMinMaxNullablePercentage,
        };

        Assert.All(anon.MyListOfNullableDouble1, x => Assert.Equal((double?)1.23d, x));
        Assert.Equal(pSetListOfNullableDoubleFixNullablePercentage, anon.MyListOfNullableDouble2);
        Assert.All(anon.MyListOfNullableDouble3, Assert.Null);
        Assert.Equal(pSetListOfNullableDoubleMinMax, anon.MyListOfNullableDouble4);
        Assert.Equal(pSetListOfNullableDoubleMinMaxNullablePercentage, anon.MyListOfNullableDouble5);
    }
    
    [Theory]
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfChars(
        [SetListOfChars(fix:'A')] List<char> pSetListOfCharFix,
        [SetListOfChars(from: ['B','C','D'])] List<char> pSetListOfCharFrom,
		[SetListOfChars(from: ['E','F','G'], excluding: ['F'])] List<char> pSetListOfCharFromExcluding)
    {
        var anon = new
        {
            MyListOfChar1 = pSetListOfCharFix,
            MyListOfChar2 = pSetListOfCharFrom,
            MyListOfChar3 = pSetListOfCharFromExcluding,
        };

        Assert.All(anon.MyListOfChar1, x => Assert.Equal((char)'A', x));
        Assert.Equal(pSetListOfCharFrom, anon.MyListOfChar2);
        Assert.Equal(pSetListOfCharFromExcluding, anon.MyListOfChar3);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfNullableChars(
        [SetListOfNullableChars(fix:'A')] List<char?> pSetListOfNullableCharFix,
        [SetListOfNullableChars(fix:'A', nullablePercentage: 37)] List<char?> pSetListOfNullableCharFixNullablePercentage,
        [SetListOfNullableChars(only:null)] List<char?> pSetListOfNullableCharAsNull,
        [SetListOfNullableChars(from: ['B','C','D'])] List<char?> pSetListOfNullableCharFrom,
        [SetListOfNullableChars(from: ['B','C','D'], nullablePercentage: 37)] List<char?> pSetListOfNullableCharFromNullablePercentage,
        [SetListOfNullableChars(from: ['E','F','G'], excluding: ['F'])] List<char?> pSetListOfNullableCharFromExcludingPercentage,
        [SetListOfNullableChars(from: ['E','F','G'], excluding: ['F'], nullablePercentage: 37)] List<char?> pSetListOfNullableCharFromExcludingNullablePercentage)
	{
        var anon = new
        {
            MyListOfNullableChar1 = pSetListOfNullableCharFix,
            MyListOfNullableChar2 = pSetListOfNullableCharFixNullablePercentage,
            MyListOfNullableChar3 = pSetListOfNullableCharAsNull,
            MyListOfNullableChar4 = pSetListOfNullableCharFrom,
            MyListOfNullableChar5 = pSetListOfNullableCharFromNullablePercentage,
            MyListOfNullableChar6 = pSetListOfNullableCharFromExcludingPercentage,
            MyListOfNullableChar7 = pSetListOfNullableCharFromExcludingNullablePercentage,
        };

        Assert.All(anon.MyListOfNullableChar1, x => Assert.Equal((char?)'A', x));
        Assert.Equal(pSetListOfNullableCharFixNullablePercentage, anon.MyListOfNullableChar2);
        Assert.All(anon.MyListOfNullableChar3, Assert.Null);
        Assert.Equal(pSetListOfNullableCharFrom, anon.MyListOfNullableChar4);
        Assert.Equal(pSetListOfNullableCharFromNullablePercentage, anon.MyListOfNullableChar5);
        Assert.Equal(pSetListOfNullableCharFromExcludingPercentage, anon.MyListOfNullableChar6);
        Assert.Equal(pSetListOfNullableCharFromExcludingNullablePercentage, anon.MyListOfNullableChar7);
    }
    
        
    [Theory]
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfStrings(
        [SetListOfStrings(fix:"ABC")] List<string> pSetListOfStringFix,
        [SetListOfStrings(from: ['B','C','D'])] List<string> pSetListOfStringFrom,
		[SetListOfStrings(from: ['E','F','G'], excluding: ['F'])] List<string> pSetListOfStringFromExcluding)
    {
        var anon = new
        {
            MyListOfString1 = pSetListOfStringFix,
            MyListOfString2 = pSetListOfStringFrom,
            MyListOfString3 = pSetListOfStringFromExcluding,
        };

        Assert.All(anon.MyListOfString1, x => Assert.Equal((string)"ABC", x));
        Assert.Equal(pSetListOfStringFrom, anon.MyListOfString2);
        Assert.Equal(pSetListOfStringFromExcluding, anon.MyListOfString3);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfNullableStrings(
        [SetListOfNullableStrings(fix:"ABC")] List<string?> pSetListOfNullableStringFix,
        [SetListOfNullableStrings(fix:"ABC", nullablePercentage: 37)] List<string?> pSetListOfNullableStringFixNullablePercentage,
        [SetListOfNullableStrings(only:null)] List<string?> pSetListOfNullableStringAsNull,
        [SetListOfNullableStrings(from: ['B','C','D'])] List<string?> pSetListOfNullableStringFrom,
        [SetListOfNullableStrings(from: ['B','C','D'], nullablePercentage: 37)] List<string?> pSetListOfNullableStringFromNullablePercentage,
        [SetListOfNullableStrings(from: ['E','F','G'], excluding: ['F'])] List<string?> pSetListOfNullableStringFromExcludingPercentage,
        [SetListOfNullableStrings(from: ['E','F','G'], excluding: ['F'], nullablePercentage: 37)] List<string?> pSetListOfNullableStringFromExcludingNullablePercentage)
	{
        var anon = new
        {
            MyListOfNullableString1 = pSetListOfNullableStringFix,
            MyListOfNullableString2 = pSetListOfNullableStringFixNullablePercentage,
            MyListOfNullableString3 = pSetListOfNullableStringAsNull,
            MyListOfNullableString4 = pSetListOfNullableStringFrom,
            MyListOfNullableString5 = pSetListOfNullableStringFromNullablePercentage,
            MyListOfNullableString6 = pSetListOfNullableStringFromExcludingPercentage,
            MyListOfNullableString7 = pSetListOfNullableStringFromExcludingNullablePercentage,
        };

        Assert.All(anon.MyListOfNullableString1, x => Assert.Equal((string?)"ABC", x));
        Assert.Equal(pSetListOfNullableStringFixNullablePercentage, anon.MyListOfNullableString2);
        Assert.All(anon.MyListOfNullableString3, Assert.Null);
        Assert.Equal(pSetListOfNullableStringFrom, anon.MyListOfNullableString4);
        Assert.Equal(pSetListOfNullableStringFromNullablePercentage, anon.MyListOfNullableString5);
        Assert.Equal(pSetListOfNullableStringFromExcludingPercentage, anon.MyListOfNullableString6);
        Assert.Equal(pSetListOfNullableStringFromExcludingNullablePercentage, anon.MyListOfNullableString7);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfGuids(
        [SetListOfGuids(fix: "a93cdf90-d7f6-4b4a-8706-0d748dc94e68")] List<Guid> pSetListOfGuidFix,
        [SetListOfGuids(fix: "2c104c00-38cd-417e-ad7f-4c1ae33b9694", fixPercentage: 60, emptyPercentage: 40)] List<Guid> pSetListOfGuidFixFixEmptyPercentage,
        [SetListOfGuids(nonEmptyPercentage: 60, emptyPercentage: 40)] List<Guid> pSetListOfGuidNonEmptyEmptyPercentage)
    {
        var anon = new
        {
            MyListOfGuid1 = pSetListOfGuidFix,
            MyListOfGuid2 = pSetListOfGuidFixFixEmptyPercentage,
            MyListOfGuid3 = pSetListOfGuidNonEmptyEmptyPercentage,
        };

        Assert.All(anon.MyListOfGuid1, x => Assert.Equal(Guid.Parse("a93cdf90-d7f6-4b4a-8706-0d748dc94e68"), x));
        Assert.Equal(pSetListOfGuidFixFixEmptyPercentage, anon.MyListOfGuid2);
        Assert.Equal(pSetListOfGuidNonEmptyEmptyPercentage, anon.MyListOfGuid3);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfNullableGuids(
        [SetListOfNullableGuids(fix: "a93cdf90-d7f6-4b4a-8706-0d748dc94e68")] List<Guid?> pSetListOfNullableGuidFix,
        [SetListOfNullableGuids(only: null)] List<Guid?> pSetListOfNullableGuidAsNull,
        [SetListOfNullableGuids(fix: "a93cdf90-d7f6-4b4a-8706-0d748dc94e68", nullablePercentage: 30)] List<Guid?> pSetListOfNullableGuidFixNullablePercentage,
        [SetListOfNullableGuids(fix: "2c104c00-38cd-417e-ad7f-4c1ae33b9694", fixPercentage: 60, emptyPercentage: 40)] List<Guid?> pSetListOfNullableGuidFixFixEmptyPercentage,
        [SetListOfNullableGuids(fix: "17d96410-2c92-4dcd-a368-211c6c73dbd2", fixPercentage: 50, emptyPercentage: 30, nullablePercentage: 20)] List<Guid?> pSetListOfNullableGuidFixFixEmptyNullablePercentage,
        [SetListOfNullableGuids(nonEmptyPercentage: 50, emptyPercentage: 30, nullablePercentage: 20)] List<Guid?> pSetListOfNullableGuidFixNonEmptyEmptyNullablePercentage)
    {
        var anon = new
        {
            MyListOfNullableGuid1 = pSetListOfNullableGuidFix,
            MyListOfNullableGuid2 = pSetListOfNullableGuidAsNull,
            MyListOfNullableGuid3 = pSetListOfNullableGuidFixNullablePercentage,
            MyListOfNullableGuid4 = pSetListOfNullableGuidFixFixEmptyPercentage,
            MyListOfNullableGuid5 = pSetListOfNullableGuidFixFixEmptyNullablePercentage,
            MyListOfNullableGuid6 = pSetListOfNullableGuidFixNonEmptyEmptyNullablePercentage,
        };

        Assert.All(anon.MyListOfNullableGuid1, x => Assert.Equal((Guid?)Guid.Parse("a93cdf90-d7f6-4b4a-8706-0d748dc94e68"), x));
        Assert.All(anon.MyListOfNullableGuid2, Assert.Null);
        Assert.Equal(pSetListOfNullableGuidFixNullablePercentage, anon.MyListOfNullableGuid3);
        Assert.Equal(pSetListOfNullableGuidFixFixEmptyPercentage, anon.MyListOfNullableGuid4);
        Assert.Equal(pSetListOfNullableGuidFixFixEmptyNullablePercentage, anon.MyListOfNullableGuid5);
        Assert.Equal(pSetListOfNullableGuidFixNonEmptyEmptyNullablePercentage, anon.MyListOfNullableGuid6);
    }
    
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfDateTimes(
        [SetListOfDateTimes(fix: "1980-09-20 04:39:57")] List<DateTime> pSetListOfDateTimeFix,
        [SetListOfDateTimes(min: "2020-09-20 21:19:05", max: "2040-09-20 01:59:13")] List<DateTime> pSetListOfDateTimeMinMax)
    {
        var anon = new
        {
            MyListOfDateTime1 = pSetListOfDateTimeFix,
            MyListOfDateTime2 = pSetListOfDateTimeMinMax,
        };

        Assert.All(anon.MyListOfDateTime1, x => Assert.Equal(DateTime.Parse("1980-09-20 04:39:57"), x));
        Assert.Equal(pSetListOfDateTimeMinMax, anon.MyListOfDateTime2);
    }
        
    [Theory]  
    [AutoDataMock]
    public void Test_AutoDataMock_SetListOfNullableDateTimes(
        [SetListOfNullableDateTimes(fix: "1980-09-02 12:34:56.789")] List<DateTime?> pSetListOfNullableDateTimeFix,
        [SetListOfNullableDateTimes(fix: "1980-09-02 12:34:56.789", nullablePercentage: 37)] List<DateTime?> pSetListOfNullableDateTimeFixNullablePercentage,
        [SetListOfNullableDateTimes(only: null)] List<DateTime?> pSetListOfNullableDateTimeAsNull,
        [SetListOfNullableDateTimes(min: "1980-09-02 12:34:56.789", max: "1988-09-02 12:34:56.789")] List<DateTime?> pSetListOfNullableDateTimeMinMax,
        [SetListOfNullableDateTimes(min: "1980-09-02 12:34:56.789", max: "1988-09-02 12:34:56.789", nullablePercentage: 37)] List<DateTime?> pSetListOfNullableDateTimeMinMaxNullablePercentage)
    {
        var anon = new
        {
            MyListOfNullableDateTime1 = pSetListOfNullableDateTimeFix,
            MyListOfNullableDateTime2 = pSetListOfNullableDateTimeFixNullablePercentage,
            MyListOfNullableDateTime3 = pSetListOfNullableDateTimeAsNull,
            MyListOfNullableDateTime4 = pSetListOfNullableDateTimeMinMax,
            MyListOfNullableDateTime5 = pSetListOfNullableDateTimeMinMaxNullablePercentage,
        };

        Assert.All(anon.MyListOfNullableDateTime1, x => Assert.Equal((DateTime?)DateTime.Parse("1980-09-02 12:34:56.789"), x));
        Assert.Equal(pSetListOfNullableDateTimeFixNullablePercentage, anon.MyListOfNullableDateTime2);
        Assert.All(anon.MyListOfNullableDateTime3, Assert.Null);
        Assert.Equal(pSetListOfNullableDateTimeMinMax, anon.MyListOfNullableDateTime4);
        Assert.Equal(pSetListOfNullableDateTimeMinMaxNullablePercentage, anon.MyListOfNullableDateTime5);
    }
}