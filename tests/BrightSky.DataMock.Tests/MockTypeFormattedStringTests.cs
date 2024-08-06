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
}