using System.Text.RegularExpressions;

namespace BrightSky.DataMock;

public record MockTypeEmail : 
    IMockType<string>, 
    IMockTypeWithUsernamesWithDomains<string, MockTypeEmail>
{
    private readonly Random _random = new();
    private readonly string _template = "{#username}@{#domain}";
    
    private readonly MockTypeFormattedString _defaultUsernamesFormattedString = Dm
        .FormattedStrings("{#username}")
        .Param("username", () => Dm.Strings().From(Dm.Char.LowercaseLetters).And(Dm.Char.Digits).WithVariableLength(5, 10));

    private readonly MockTypeFormattedString _defaultDomainsFormattedString = Dm
        .FormattedStrings("{#domain}.{#tld}")
        .Param("domain", () => Dm.Strings().From(Dm.Char.LowercaseLetters).And(Dm.Char.Digits).WithVariableLength(5, 10))
        .Param("tld", () => Dm.Strings().From(Dm.Char.LowercaseLetters).WithVariableLength(2, 3));
    
    private MockTypeFormattedString? _usernamesFormattedString;
    private MockTypeFormattedString? _domainsFormattedString;

    private List<string> _usernamesValues = [];
    private List<string> _domainsValues = [];

    private MockStrategyToUse _usernamesStrategy = MockStrategyToUse.FormattedString;
    private MockStrategyToUse _domainsStrategy = MockStrategyToUse.FormattedString;

    private enum MockStrategyToUse
    {
        Values,
        FormattedString,
    }
    
    public string Get()
    {
        var usernameFormattedString = _usernamesFormattedString ?? _defaultUsernamesFormattedString;
        var domainFormattedString = _domainsFormattedString ?? _defaultDomainsFormattedString;

        var dict = new Dictionary<Func<bool>, Func<string>>
        {
            {
                () => _usernamesStrategy is MockStrategyToUse.FormattedString && _domainsStrategy is MockStrategyToUse.FormattedString, 
                () => Dm.FormattedStrings(_template)
                        .Param("username", () => usernameFormattedString)
                        .Param("domain", () => domainFormattedString)
                        .Get()
            },
            {
                () => _usernamesStrategy is MockStrategyToUse.FormattedString && _domainsStrategy is MockStrategyToUse.Values, 
                () => Dm.FormattedStrings(
                    Regex.Replace(
                        _template, 
                        "domain".ToParam(), 
                        _domainsValues[_random.Next(0, _domainsValues.Count)]))
                        .Param("username", () => usernameFormattedString)
                        .Get()
            },
            {
                () => _usernamesStrategy is MockStrategyToUse.Values && _domainsStrategy is MockStrategyToUse.FormattedString, 
                () => Dm.FormattedStrings(
                        Regex.Replace(
                            _template, 
                            "username".ToParam(), 
                            _usernamesValues[_random.Next(0, _usernamesValues.Count)]))
                        .Param("domain", () => domainFormattedString)
                        .Get()
            },
            {
                () => _usernamesStrategy is MockStrategyToUse.Values && _domainsStrategy is MockStrategyToUse.Values,  
                () => Regex.Replace(
                    Regex.Replace(
                        _template, 
                        "username".ToParam(), 
                        _usernamesValues[_random.Next(0, _usernamesValues.Count)]), 
                    "domain".ToParam(), 
                    _domainsValues[_random.Next(0, _domainsValues.Count)])
            },
        };

        return dict.First(kvp => kvp.Key()).Value();
    }

    public MockTypeEmail WithUsernames(MockTypeFormattedString formattedString)
    {
        _usernamesFormattedString = formattedString ?? throw new ArgumentNullException(nameof(formattedString));
        _usernamesStrategy = MockStrategyToUse.FormattedString;
        return this;
    }

    public MockTypeEmail WithUsernames(IEnumerable<string> values)
    {
        _usernamesValues = values.ToList() ?? throw new ArgumentNullException(nameof(values));
        _usernamesStrategy = MockStrategyToUse.Values;
        return this;
    }

    public MockTypeEmail WithDomains(MockTypeFormattedString formattedString)
    {
        _domainsFormattedString = formattedString ?? throw new ArgumentNullException(nameof(formattedString));
        _domainsStrategy = MockStrategyToUse.FormattedString;
        return this;
    }

    public MockTypeEmail WithDomains(IEnumerable<string> values)
    {
        _domainsValues = values.ToList() ?? throw new ArgumentNullException(nameof(values));
        _domainsStrategy = MockStrategyToUse.Values;
        return this;
    }
}