namespace BrightSky.DataMock.Tests;

public class MockTypeFromTests
{
    [Fact]
    public void When_FromOfInt_WithValues_Returns_ImplOf_IMockTypeOfInt()
    {
        var actual = Dm.From<int>([1]);

        Assert.IsAssignableFrom<IMockType<int>>(actual);
    }
    
    [Fact]
    public void When_FromOfInt_WithValues_Returns_MockTypeFromOfInt()
    {
        var actual = Dm.From<int>([1]);

        Assert.IsType<MockTypeFrom<int>>(actual);
    }
    
    [Fact]
    public void When_FromOfInt_WithValues_Get_Returns_MockTypeFromOfInt()
    {
        var actual = Dm.From<int>([1]).Get();

        Assert.IsType<int>(actual);
    }
        
    [Fact]
    public void When_FromOfInt_WithOneValue_Get_Returns_Int_AsExpected()
    {
        var actual = Dm.From<int>([1]).Get();

        Assert.Equal(1, actual);
    }
 
    [Fact]
    public void When_FromOfByte_WithValues_Get_Returns_Byte_FromValues()
    {
        var values = new byte[] {1, 2, 3};
        var actual = Dm.From<byte>(values).Get();

        Assert.True(values.Contains(actual));
    }
    
    [Fact]
    public void When_FromOfNullableByte_WithValues_Get_Returns_NullableByte_FromValues()
    {
        var values = new byte?[] {1, null, 3};
        var actual = Dm.From<byte?>(values).Get();

        Assert.True(values.Contains(actual));
    }
    
    [Fact]
    public void When_FromOfShort_WithValues_Get_Returns_Short_FromValues()
    {
        var values = new short[] {1, 2, 3};
        var actual = Dm.From<short>(values).Get();

        Assert.True(values.Contains(actual));
    }
    
    [Fact]
    public void When_FromOfNullableShort_WithValues_Get_Returns_NullableShort_FromValues()
    {
        var values = new short?[] {1, null, 3};
        var actual = Dm.From<short?>(values).Get();

        Assert.True(values.Contains(actual));
    }
    
    [Fact]
    public void When_FromOfInt_WithValues_Get_Returns_Int_FromValues()
    {
        var values = new [] {1, 2, 3};
        var actual = Dm.From<int>(values).Get();

        Assert.True(values.Contains(actual));
    }
    
    [Fact]
    public void When_FromOfNullableInt_WithValues_Get_Returns_NullableInt_FromValues()
    {
        var values = new int?[] {1, null, 3};
        var actual = Dm.From<int?>(values).Get();

        Assert.True(values.Contains(actual));
    }
    
    [Fact]
    public void When_FromOfLong_WithValues_Get_Returns_Long_FromValues()
    {
        var values = new long[] {1, 2, 3};
        var actual = Dm.From<long>(values).Get();

        Assert.True(values.Contains(actual));
    }
    
    [Fact]
    public void When_FromOfNullableLong_WithValues_Get_Returns_NullableLong_FromValues()
    {
        var values = new long?[] {1, null, 3};
        var actual = Dm.From<long?>(values).Get();

        Assert.True(values.Contains(actual));
    }
    
    [Fact]
    public void When_FromOfFloat_WithValues_Get_Returns_Float_FromValues()
    {
        var values = new float[] {0.1f, 0.2f, 0.3f};
        var actual = Dm.From<float>(values).Get();

        Assert.True(values.Contains(actual));
    }
    
    [Fact]
    public void When_FromOfNullableFloat_WithValues_Get_Returns_NullableFloat_FromValues()
    {
        var values = new float?[] {0.1f, null, 0.3f};
        var actual = Dm.From<float?>(values).Get();

        Assert.True(values.Contains(actual));
    }

    [Fact]
    public void When_FromOfDouble_WithValues_Get_Returns_Double_FromValues()
    {
        var values = new double[] {0.1d, 0.2d, 0.3d};
        var actual = Dm.From<double>(values).Get();

        Assert.True(values.Contains(actual));
    }
    
    [Fact]
    public void When_FromOfNullableDouble_WithValues_Get_Returns_NullableDouble_FromValues()
    {
        var values = new double?[] {0.1d, null, 0.3d};
        var actual = Dm.From<double?>(values).Get();

        Assert.True(values.Contains(actual));
    }
    
    [Fact]
    public void When_FromOfChar_WithValues_Get_Returns_Char_FromValues()
    {
        var values = new [] {'A', 'B', 'C'};
        var actual = Dm.From<char>(values).Get();

        Assert.True(values.Contains(actual));
    }
                    
    [Fact]
    public void When_FromOfNullableChar_WithValues_Get_Returns_NullableChar_FromValues()
    {
        var values = new char?[] {'A', null, 'C'};
        var actual = Dm.From<char?>(values).Get();

        Assert.True(values.Contains(actual));
    }
    
    [Fact]
    public void When_FromOfString_WithValues_Get_Returns_String_FromValues()
    {
        var values = new [] {"A", "B", "C"};
        var actual = Dm.From<string>(values).Get();

        Assert.True(values.Contains(actual));
    }
                    
    [Fact]
    public void When_FromOfNullableString_WithValues_Get_Returns_NullableString_FromValues()
    {
        var values = new string?[] {"A", null, "C"};
        var actual = Dm.From<string?>(values).Get();

        Assert.True(values.Contains(actual));
    }

    [Fact]
    public void When_Constructor_WithNullValues_Throws_ArgumentNullException()
    {
        int[] values = null!;
        var action = () => Dm.From<int>(values);

        Assert.Throws<ArgumentNullException>(action);
    }
    
    [Fact]
    public void When_Constructor_WithEmptyValues_Throws_ArgumentOutOfRangeException()
    {
        int[] values = [];
        var action = () => Dm.From<int>(values);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
}