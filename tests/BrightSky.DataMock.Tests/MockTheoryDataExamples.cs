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
    public void Test_MockPrimitiveData_TheoryData(bool p1, int p2, double p3, string p4)
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
}