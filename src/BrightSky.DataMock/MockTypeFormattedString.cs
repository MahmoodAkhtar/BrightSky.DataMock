using System.Text.RegularExpressions;

namespace BrightSky.DataMock;

public record MockTypeFormattedString : IMockType<string>, IMockTypeParam<string, MockTypeFormattedString>, IMockTypeTemplate
{
    private readonly List<ParamValue> _paramsValues = [];
    private readonly string _template;

    public List<ParamValue> ParamValues => _paramsValues;
    public string Template => _template;
    
    public MockTypeFormattedString(string template)
    {
        if (string.IsNullOrWhiteSpace(template))
            throw new ArgumentException($"{nameof(template)} is required.", nameof(template));
        
        _template = template;
    }
    
    public string Get()
    {
        if (ParamValues.Count is 0) return Template;
        var formatted = Template;
        var matches = Regex.Matches(Template, ParamValue.Pattern);
        foreach (Match match in matches)
            formatted = Regex.Replace(formatted, match.Value, Replacement(ParamValues, match.Value));
        
        return formatted;
    }
    
    public MockTypeFormattedString Param<TParam>(string paramName, Func<IMockType<TParam>> mockTypeFactory)
    {
        if (string.IsNullOrWhiteSpace(paramName))
            throw new ArgumentException($"{nameof(paramName)} is required", nameof(paramName));
        ArgumentNullException.ThrowIfNull(mockTypeFactory);

        _paramsValues.Add(new ParamValue(paramName, mockTypeFactory));

        return this;
    }

    internal MockTypeFormattedString AddParamValueRange(IEnumerable<ParamValue> paramValues)
    {
        ArgumentNullException.ThrowIfNull(paramValues);
        _paramsValues.AddRange(paramValues);
        return this;
    }
    
    private static string Replacement(List<ParamValue> source, string name)
    {
        var pi = source.FirstOrDefault(x => name == $"{{#{x.Name}}}");
        return pi.Get();
    }

}