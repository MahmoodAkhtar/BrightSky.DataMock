namespace BrightSky.DataMock.Tests;

public class MockTypeIntSequenceTests
{
    [Fact]
    public void When_IntSequence_Returns_ImplOf_IMockTypeOfInt()
    {
        var actual = Dm.IntSequence();

        Assert.IsAssignableFrom<IMockType<int>>(actual);
    }
    
    [Fact]
    public void When_IntSequence_Returns_MockTypeIntSequence()
    {
        var actual = Dm.IntSequence();

        Assert.IsType<MockTypeIntSequence>(actual);
    }
    
    [Fact]
    public void When_IntSequenceGet_FirstCall_Returns_Default_Int_0()
    {
        var actual = Dm.IntSequence().Get();

        Assert.Equal(0, actual);
    }
    
    [Fact]
    public void When_IntSequenceGet_SecondCall_Returns_Default_Int_1()
    {
        var intSeq = Dm.IntSequence();
        _ = intSeq.Get();
        var actual = intSeq.Get();

        Assert.Equal(1, actual);
    }
    
    [Fact]
    public void When_IntSequenceGet_ThirdCall_Returns_Default_Int_2()
    {
        var intSeq = Dm.IntSequence();
        _ = intSeq.Get();
        _ = intSeq.Get();
        var actual = intSeq.Get();

        Assert.Equal(2, actual);
    }
    
    [Fact]
    public void When_IntSequenceToList_With_Defaults_Returns_Default_ListOfInt_AsExpected()
    {
        var expected = Enumerable.Range(0, 1001).ToList();
        var actual = Dm.IntSequence().ToList();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_IntSequenceAscending_Returns_ImplOf_IMockTypeOfInt()
    {
        var actual = Dm.IntSequence().Ascending();

        Assert.IsAssignableFrom<IMockType<int>>(actual);
    }
    
    [Fact]
    public void When_IntSequenceAscending_Returns_MockTypeIntSequence()
    {
        var actual = Dm.IntSequence().Ascending();

        Assert.IsAssignableFrom<MockTypeIntSequence>(actual);
    }
    
    [Fact]
    public void When_IntSequenceAscendingToList_With_Defaults_Returns_Default_ListOfInt_AsExpected()
    {
        var expected = Enumerable.Range(0, 1001).ToList();
        var actual = Dm.IntSequence().Ascending().ToList();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_IntSequenceDescending_Returns_ImplOf_IMockTypeOfInt()
    {
        var actual = Dm.IntSequence().Descending();

        Assert.IsAssignableFrom<IMockType<int>>(actual);
    }
    
    [Fact]
    public void When_IntSequenceDescending_Returns_MockTypeIntSequence()
    {
        var actual = Dm.IntSequence().Descending();

        Assert.IsAssignableFrom<MockTypeIntSequence>(actual);
    }
    
    [Fact]
    public void When_IntSequenceDescendingToList_With_Defaults_Returns_Default_ListOfInt_AsExpected()
    {
        var expected = Enumerable.Range(0, 1001).ToList();
        expected.Reverse();
        var actual = Dm.IntSequence().Descending().ToList();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_IntSequenceRange_Returns_ImplOf_IMockTypeOfInt()
    {
        var actual = Dm.IntSequence().Range(0, 1000);

        Assert.IsAssignableFrom<IMockType<int>>(actual);
    }
    
    [Fact]
    public void When_IntSequenceRange_Returns_MockTypeIntSequence()
    {
        var actual = Dm.IntSequence().Range(0, 1000);

        Assert.IsAssignableFrom<MockTypeIntSequence>(actual);
    }
    
    [Fact]
    public void When_IntSequenceRange_With_MinValueGreaterThanMaxValue_Returns_ListOfInt_AsExpected()
    {
        var action = () => Dm.IntSequence().Range(1, 0);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_IntSequenceRangeToList_With_0_To_1000_Returns_ListOfInt_AsExpected()
    {
        var expected = Enumerable.Range(0, 1001).ToList();
        var actual = Dm.IntSequence().Range(0, 1000).ToList();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_IntSequenceRangeToList_With_MaxValue_IsIntMaxValue_Returns_ListOfInt_AsExpected()
    {
        var expected = Enumerable.Range(int.MaxValue - 10, 10).ToList();
        expected.Add(int.MaxValue);
        var actual = Dm.IntSequence().Range(int.MaxValue - 10, int.MaxValue).ToList();

        Assert.Equal(expected, actual);
    }
        
    [Fact]
    public void When_IntSequenceRangeToList_With_MinValue_IsIntMinValue_Returns_ListOfInt_AsExpected()
    {
        var expected = Enumerable.Range(int.MinValue, 11).ToList();
        var actual = Dm.IntSequence().Range(int.MinValue, int.MinValue + 10).ToList();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_IntSequenceIncrement_Returns_ImplOf_IMockTypeOfInt()
    {
        var actual = Dm.IntSequence().Increment(1);

        Assert.IsAssignableFrom<IMockType<int>>(actual);
    }
        
    [Fact]
    public void When_IntSequenceIncrement_Returns_MockTypeIntSequence()
    {
        var actual = Dm.IntSequence().Increment(1);

        Assert.IsAssignableFrom<MockTypeIntSequence>(actual);
    }
            
    [Fact]
    public void When_IntSequenceIncrement_2_Get_FirstCall_Returns_0()
    {
        var actual = Dm.IntSequence().Increment(2).Get();

        Assert.Equal(0, actual);
    }
    
    [Fact]
    public void When_IntSequenceIncrement_2_Get_SecondCall_Returns_2()
    {
        var intSeq = Dm.IntSequence().Increment(2);
        _ = intSeq.Get();
        var actual = intSeq.Get();

        Assert.Equal(2, actual);
    }
    
    [Fact]
    public void When_IntSequenceIncrement_2_Get_ThirdCall_Returns_4()
    {
        var intSeq = Dm.IntSequence().Increment(2);
        _ = intSeq.Get();
        _ = intSeq.Get();
        var actual = intSeq.Get();

        Assert.Equal(4, actual);
    }
        
    [Fact]
    public void When_IntSequenceIncrement_2_ToList_Returns_ListOfInt_AsExpected()
    {
        var expected = Enumerable.Range(0, 1001).Where(x => x % 2 == 0);
        var actual = Dm.IntSequence().Increment(2).ToList();

        Assert.Equal(expected, actual);
    }
            
    [Fact]
    public void When_IntSequenceIncrement_3_ToList_Returns_ListOfInt_AsExpected()
    {
        var expected = Enumerable.Range(0, 1001).Where(x => x % 3 == 0);
        var actual = Dm.IntSequence().Increment(3).ToList();

        Assert.Equal(expected, actual);
    }
                
    [Fact]
    public void When_IntSequenceIncrement_5_ToList_Returns_ListOfInt_AsExpected()
    {
        var expected = Enumerable.Range(0, 1001).Where(x => x % 5 == 0);
        var actual = Dm.IntSequence().Increment(5).ToList();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_IntSequenceRange_MaxValue_IntMaxValue_Increment_2_Get_SecondCall_Returns_IntMaxValue()
    {
        var intSeq = Dm.IntSequence().Range(int.MaxValue - 1, int.MaxValue).Increment(2);
        _ = intSeq.Get();
        var actual = intSeq.Get();

        Assert.Equal(int.MaxValue, actual);
    }
    
    [Fact]
    public void When_IntSequenceRange_MaxValue_IntMaxValue_Increment_2_Get_ThirdCall_Returns_IntMaxValue()
    {
        var intSeq = Dm.IntSequence().Range(int.MaxValue - 1, int.MaxValue).Increment(2);
        _ = intSeq.Get();
        _ = intSeq.Get();
        var actual = intSeq.Get();

        Assert.Equal(int.MaxValue, actual);
    }
    
    [Fact]
    public void When_IntSequenceRange_MinValue_IntMinValue_Increment_2_Descending_Get_SecondCall_Returns_IntMinValue()
    {
        var intSeq = Dm.IntSequence().Range(int.MinValue, int.MinValue + 1).Increment(2).Descending();
        _ = intSeq.Get();
        var actual = intSeq.Get();

        Assert.Equal(int.MinValue, actual);
    }
        
    [Fact]
    public void When_IntSequenceRange_MinValue_IntMinValue_Increment_2_Descending_Get_ThirdCall_Returns_IntMinValue()
    {
        var intSeq = Dm.IntSequence().Range(int.MinValue, int.MinValue + 1).Increment(2).Descending();
        _ = intSeq.Get();
        _ = intSeq.Get();
        var actual = intSeq.Get();

        Assert.Equal(int.MinValue, actual);
    }
}