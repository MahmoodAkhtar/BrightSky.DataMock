namespace BrightSky.DataMock.Tests;

public class MockTypeFormattedStringTests
{
    [Fact]
    public void When_FormattedStrings_Template_AsEmptyString_Throws_ArgumentException()
    {
        var action = () => Dm.FormattedStrings("");

        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void When_FormattedStrings_Template_AsOnlyWhitespaceString_Throws_ArgumentException()
    {
        var action = () => Dm.FormattedStrings(" ");

        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void When_FormattedStrings_Returns_ImplOf_IMockTypeOfString()
    {
        var actual = Dm.FormattedStrings("template");

        Assert.IsAssignableFrom<IMockType<string>>(actual);
    }
    
    [Fact]
    public void When_FormattedStrings_Returns_MockTypeFormattedString()
    {
        var actual = Dm.FormattedStrings("template");

        Assert.IsType<MockTypeFormattedString>(actual);
    }
    
    [Fact]
    public void When_FormattedStringsGet_WithNoParams_Returns_Template_AsExpected()
    {
        var expected = "template";
        var actual = Dm.FormattedStrings(expected).Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_FormattedStringsGet_WithParamName_AsNullString_Throws_ArgumentException()
    {
        var expected = "template";
        var action = () => Dm.FormattedStrings(expected)
            .Param(null, Dm.Ints)
            .Get();

        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void When_FormattedStringsGet_WithParamName_AsEmptyString_Throws_ArgumentException()
    {
        var expected = "template";
        var action = () => Dm.FormattedStrings(expected)
            .Param("", Dm.Ints)
            .Get();

        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void When_FormattedStringsGet_WithParamName_AsOnlyWhitespaceString_Throws_ArgumentException()
    {
        var expected = "template";
        var action = () => Dm.FormattedStrings(expected)
            .Param(" ", Dm.Ints)
            .Get();

        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void When_FormattedStringsGet_WithMockTypeFactory_AsNull_Throws_ArgumentNullException()
    {
        Func<IMockType<int>> mockTypeFactory = null;
        var expected = "template";
        var action = () => Dm.FormattedStrings(expected)
            .Param("p1", mockTypeFactory)
            .Get();

        Assert.Throws<ArgumentNullException>(action);
    }
    
    [Fact]
    public void When_FormattedStringsGet_WithNonParam_Returns_Template_AsExpected()
    {
        var expected = "template";
        var actual = Dm.FormattedStrings(expected)
            .Param("not_a_param", Dm.Ints)
            .Get();

        Assert.Equal(expected, actual);
    }
        
    [Fact]
    public void When_FormattedStringsGet_WithNonMatchingParam_Returns_FormattedString_AsExpected()
    {
        var expected = "template-";
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("no_match", Dm.Ints)
            .Get();

        Assert.Equal(expected, actual);
    }
            
    [Fact]
    public void When_FormattedStringsGet_WithOneParam_Returns_FormattedString_AsExpected()
    {
        var expected = "template-A";
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Chars().From(['A']))
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_FormattedStringsGet_WithMultipleParams_Returns_FormattedString_AsExpected()
    {
        var expected = "template-A-B-C";
        var template = "template-{#p1}-{#p2}-{#p3}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Chars().From(['A']))
            .Param("p2", () => Dm.Chars().From(['B']))
            .Param("p3", () => Dm.Chars().From(['C']))
            .Get();

        Assert.Equal(expected, actual);
    }
                
    [Fact]
    public void When_FormattedStringsToList_WithOneParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-A", 100).ToList();
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Chars().From(['A']))
            .ToList();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_FormattedStringsToList_WithMultipleParams_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-A-B-C", 100).ToList();
        var template = "template-{#p1}-{#p2}-{#p3}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Chars().From(['A']))
            .Param("p2", () => Dm.Chars().From(['B']))
            .Param("p3", () => Dm.Chars().From(['C']))
            .ToList();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_FormattedStringsToList_Size_Negative_Throws_ArgumentOutOfRangeException()
    {
        var template = "template-{#p1}";
        var action = () => Dm.FormattedStrings(template).ToList(-1);

        Assert.Throws<ArgumentOutOfRangeException>(action);
    }
    
    [Fact]
    public void When_FormattedStringsToList_WithCharParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-A", 100).ToList();
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Chars().From(['A']))
            .ToList();

        Assert.Equal(expected, actual);
    }
        
    [Fact]
    public void When_FormattedStringsToList_WithBoolParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-True", 100).ToList();
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Bools().TrueProbability(100))
            .ToList();

        Assert.Equal(expected, actual);
    }
            
    [Fact]
    public void When_FormattedStringsToList_WithByteParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-1", 100).ToList();
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Bytes().Range(1, 1))
            .ToList();

        Assert.Equal(expected, actual);
    }
                
    [Fact]
    public void When_FormattedStringsToList_WithShortParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-1", 100).ToList();
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Shorts().Range(1, 1))
            .ToList();

        Assert.Equal(expected, actual);
    }
                    
    [Fact]
    public void When_FormattedStringsToList_WithIntParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-1", 100).ToList();
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Ints().Range(1, 1))
            .ToList();

        Assert.Equal(expected, actual);
    }
                        
    [Fact]
    public void When_FormattedStringsToList_WithLongParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-1", 100).ToList();
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Longs().Range(1, 1))
            .ToList();

        Assert.Equal(expected, actual);
    }
                            
    [Fact]
    public void When_FormattedStringsToList_WithFloatParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-0.1", 100).ToList();
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Floats().Range(0.1f, 0.1f))
            .ToList();

        Assert.Equal(expected, actual);
    }
                                
    [Fact]
    public void When_FormattedStringsToList_WithDoubleParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-0.1", 100).ToList();
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Doubles().Range(0.1d, 0.1d))
            .ToList();

        Assert.Equal(expected, actual);
    }
                                    
    [Fact]
    public void When_FormattedStringsToList_WithDecimalParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-0.1", 100).ToList();
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Decimals().Range(0.1m, 0.1m))
            .ToList();

        Assert.Equal(expected, actual);
    }
                                        
    [Fact]
    public void When_FormattedStringsToList_WithStringParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-AAAAAAAAAA", 100).ToList();
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.Strings().From(['A']))
            .ToList();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_FormattedStringsToList_WithNullableBoolParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-True", 33)
            .Concat(Enumerable.Repeat("template-False", 33))
            .Concat(Enumerable.Repeat("template-", 34))
            .Order()
            .ToList();
        
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.NullableBools())
            .ToList()
            .Order();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_FormattedStringsToList_WithNullableByteParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-1", 50)
            .Concat(Enumerable.Repeat("template-", 50))
            .Order()
            .ToList();
        
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.NullableBytes().Range(1, 1))
            .ToList()
            .Order();

        Assert.Equal(expected, actual);
    }
        
    [Fact]
    public void When_FormattedStringsToList_WithNullableShortParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-1", 50)
            .Concat(Enumerable.Repeat("template-", 50))
            .Order()
            .ToList();
        
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.NullableShorts().Range(1, 1))
            .ToList()
            .Order();

        Assert.Equal(expected, actual);
    }
            
    [Fact]
    public void When_FormattedStringsToList_WithNullableIntParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-1", 50)
            .Concat(Enumerable.Repeat("template-", 50))
            .Order()
            .ToList();
        
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.NullableInts().Range(1, 1))
            .ToList()
            .Order();

        Assert.Equal(expected, actual);
    }
                
    [Fact]
    public void When_FormattedStringsToList_WithNullableLongParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-1", 50)
            .Concat(Enumerable.Repeat("template-", 50))
            .Order()
            .ToList();
        
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.NullableLongs().Range(1, 1))
            .ToList()
            .Order();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_FormattedStringsToList_WithNullableFloatParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-0.1", 50)
            .Concat(Enumerable.Repeat("template-", 50))
            .Order()
            .ToList();
        
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.NullableFloats().Range(0.1f, 0.1f))
            .ToList()
            .Order();

        Assert.Equal(expected, actual);
    }
        
    [Fact]
    public void When_FormattedStringsToList_WithNullableDoubleParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-0.1", 50)
            .Concat(Enumerable.Repeat("template-", 50))
            .Order()
            .ToList();
        
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.NullableDoubles().Range(0.1d, 0.1d))
            .ToList()
            .Order();

        Assert.Equal(expected, actual);
    }
            
    [Fact]
    public void When_FormattedStringsToList_WithNullableDecimalParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-0.1", 50)
            .Concat(Enumerable.Repeat("template-", 50))
            .Order()
            .ToList();
        
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.NullableDecimals().Range(0.1m, 0.1m))
            .ToList()
            .Order();

        Assert.Equal(expected, actual);
    }
                
    [Fact]
    public void When_FormattedStringsToList_WithNullableCharParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-A", 50)
            .Concat(Enumerable.Repeat("template-", 50))
            .Order()
            .ToList();
        
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.NullableChars().From(['A']))
            .ToList()
            .Order();

        Assert.Equal(expected, actual);
    }
                    
    [Fact]
    public void When_FormattedStringsToList_WithNullableStringParam_Returns_FormattedString_AsExpected()
    {
        var expected = Enumerable.Repeat("template-AAAAAAAAAA", 50)
            .Concat(Enumerable.Repeat("template-", 50))
            .Order()
            .ToList();
        
        var template = "template-{#p1}";
        var actual = Dm.FormattedStrings(template)
            .Param("p1", () => Dm.NullableStrings().From(['A']))
            .ToList()
            .Order();

        Assert.Equal(expected, actual);
    }
}