namespace BrightSky.DataMock.Tests;

public class MockTypeEmailTests
{
    [Fact]
    public void When_Emails_Returns_ImplOf_IMockTypeOfString()
    {
        var actual = Dm.Emails();

        Assert.IsAssignableFrom<IMockType<string>>(actual);
    }
    
    [Fact]
    public void When_Emails_Returns_MockTypeEmail()
    {
        var actual = Dm.Emails();

        Assert.IsType<MockTypeEmail>(actual);
    }
    
    [Fact]
    public void When_EmailsGet_Returns_String()
    {
        var actual = Dm.Emails().Get();

        Assert.IsType<string>(actual);
    }
    
    [Fact]
    public void When_EmailsGet_Default_Returns_String_WithinDefaultLength()
    {
        var actual = Dm.Emails().Get();

        Assert.True(actual.Length is >= 13 and <= 24);
    }
    
    [Fact]
    public void When_EmailsWithUsernames_FormattedString_IsNull_Throws_ArgumentNullException()
    {
        MockTypeFormattedString formattedString = null!;
        var action = () => Dm.Emails().WithUsernames(formattedString);

        Assert.Throws<ArgumentNullException>(action);
    }
        
    [Fact]
    public void When_EmailsWithUsernames_FormattedString_Returns_MockTypeEmail()
    {
        var actual = Dm.Emails().WithUsernames(Dm.FormattedStrings("template"));

        Assert.IsType<MockTypeEmail>(actual);
    }
            
    [Fact]
    public void When_EmailsWithUsernames_FormattedString_Returns_Email_AsExpected()
    {
        var formattedString = Dm.FormattedStrings("{#p1}")
            .Param("p1", () => Dm.Strings().From(['A']));
        var actual = Dm.Emails().WithUsernames(formattedString).Get();

        Assert.StartsWith("A", actual);
    }
    
    [Fact]
    public void When_EmailsWithUsernames_Strings_IsNull_Throws_ArgumentNullException()
    {
        string[] strings = null!;
        var action = () => Dm.Emails().WithUsernames(strings);

        Assert.Throws<ArgumentNullException>(action);
    }
        
    [Fact]
    public void When_EmailsWithUsernames_Strings_Returns_MockTypeEmail()
    {
        var actual = Dm.Emails().WithUsernames(["A"]);

        Assert.IsType<MockTypeEmail>(actual);
    }
            
    [Fact]
    public void When_EmailsWithUsernames_Strings_Returns_Email_AsExpected()
    {
        var actual = Dm.Emails().WithUsernames(["A"]).Get();

        Assert.StartsWith("A", actual);
    }
    
    [Fact]
    public void When_EmailsWithDomains_FormattedString_IsNull_Throws_ArgumentNullException()
    {
        MockTypeFormattedString formattedString = null!;
        var action = () => Dm.Emails().WithDomains(formattedString);

        Assert.Throws<ArgumentNullException>(action);
    }
        
    [Fact]
    public void When_EmailsWithDomains_FormattedString_Returns_MockTypeEmail()
    {
        var actual = Dm.Emails().WithDomains(Dm.FormattedStrings("template"));

        Assert.IsType<MockTypeEmail>(actual);
    }
            
    [Fact]
    public void When_EmailsWithDomains_FormattedString_Returns_Email_AsExpected()
    {
        var formattedString = Dm.FormattedStrings("{#p1}")
            .Param("p1", () => Dm.Strings().From(['A']));
        var actual = Dm.Emails().WithDomains(formattedString).Get();

        Assert.EndsWith("A", actual);
    }
    
    [Fact]
    public void When_EmailsWithDomains_Strings_IsNull_Throws_ArgumentNullException()
    {
        string[] strings = null!;
        var action = () => Dm.Emails().WithDomains(strings);

        Assert.Throws<ArgumentNullException>(action);
    }
        
    [Fact]
    public void When_EmailsWithDomains_Strings_Returns_MockTypeEmail()
    {
        var actual = Dm.Emails().WithDomains(["A"]);

        Assert.IsType<MockTypeEmail>(actual);
    }
            
    [Fact]
    public void When_EmailsWithDomains_Strings_Returns_Email_AsExpected()
    {
        var actual = Dm.Emails().WithDomains(["A"]).Get();

        Assert.EndsWith("A", actual);
    }
    
    [Fact]
    public void When_EmailsWithUsernameWithDomains_FormattedString_Returns_Email_AsExpected()
    {
        var usernameFormattedString = Dm.FormattedStrings("{#p1}")
            .Param("p1", () => Dm.Strings().From(['A']).WithLength(1));        
        var domainFormattedString = Dm.FormattedStrings("{#p2}")
            .Param("p2", () => Dm.Strings().From(['B']).WithLength(1));
        
        var actual = Dm.Emails()
            .WithUsernames(usernameFormattedString)
            .WithDomains(domainFormattedString)
            .Get();

        Assert.Equal("A@B", actual);
    }
    
    [Fact]
    public void When_EmailsWithUsernameWithDomains_Strings_Returns_Email_AsExpected()
    {
        var actual = Dm.Emails()
            .WithUsernames(["A"])
            .WithDomains(["B"])
            .Get();

        Assert.Equal("A@B", actual);
    }
}