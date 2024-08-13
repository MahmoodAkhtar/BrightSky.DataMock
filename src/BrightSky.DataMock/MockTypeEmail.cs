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

    private StrategyToUse _usernamesStrategy = StrategyToUse.FormattedString;
    private StrategyToUse _domainsStrategy = StrategyToUse.FormattedString;

    private enum StrategyToUse
    {
        Values,
        FormattedString,
    }
    
    public string Get()
    {
        var usernameFormattedString = _usernamesFormattedString ?? _defaultUsernamesFormattedString;
        var domainFormattedString = _domainsFormattedString ?? _defaultDomainsFormattedString;

        return _usernamesStrategy switch
        {
            StrategyToUse.FormattedString when _domainsStrategy == StrategyToUse.FormattedString => 
                Dm.FormattedStrings(_template)
                    .Param("username", () => usernameFormattedString)
                    .Param("domain", () => domainFormattedString)
                    .Get(),
            StrategyToUse.FormattedString when _domainsStrategy == StrategyToUse.Values => 
                Regex.Replace(
                    Dm.FormattedStrings(_template).Param("username", () => usernameFormattedString).Get(), 
                    ParamValue.ToParam("domain"), 
                    _domainsValues[_random.Next(0, _domainsValues.Count)]),
            StrategyToUse.Values when _domainsStrategy == StrategyToUse.FormattedString => 
                Regex.Replace(
                    Dm.FormattedStrings(_template).Param("domain", () => domainFormattedString).Get(), 
                    ParamValue.ToParam("username"), 
                    _usernamesValues[_random.Next(0, _usernamesValues.Count)]),
            StrategyToUse.Values when _domainsStrategy == StrategyToUse.Values => 
                Regex.Replace(
                    Regex.Replace(
                        _template, 
                        ParamValue.ToParam("username"), 
                        _usernamesValues[_random.Next(0, _usernamesValues.Count)]), 
                    ParamValue.ToParam("domain"), 
                    _domainsValues[_random.Next(0, _domainsValues.Count)]),
            _ => string.Empty,
        };
    }

    public MockTypeEmail WithUsernames(MockTypeFormattedString formattedString)
    {
        _usernamesFormattedString = formattedString ?? throw new ArgumentNullException(nameof(formattedString));
        _usernamesStrategy = StrategyToUse.FormattedString;
        return this;
    }

    public MockTypeEmail WithUsernames(IEnumerable<string> values)
    {
        _usernamesValues = values.ToList() ?? throw new ArgumentNullException(nameof(values));
        _usernamesStrategy = StrategyToUse.Values;
        return this;
    }

    public MockTypeEmail WithDomains(MockTypeFormattedString formattedString)
    {
        _domainsFormattedString = formattedString ?? throw new ArgumentNullException(nameof(formattedString));
        _domainsStrategy = StrategyToUse.FormattedString;
        return this;
    }

    public MockTypeEmail WithDomains(IEnumerable<string> values)
    {
        _domainsValues = values.ToList() ?? throw new ArgumentNullException(nameof(values));
        _domainsStrategy = StrategyToUse.Values;
        return this;
    }
}