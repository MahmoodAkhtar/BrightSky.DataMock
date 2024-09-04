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
    public void Test_AutoDataMock_SetBools(
        [SetBools(fix:true)] bool pSetBoolFixAsTrue,
        [SetBools(fix:false)] bool pSetBoolFixAsFalse,
        [SetBools(truePercentage: 60, falsePercentage: 40)] int pSetBoolPercentages)
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
}