using System.Text.RegularExpressions;

namespace BrightSky.DataMock;

public record MockTypeFormattedString : IMockType<string>, IMockTypeParam<string, MockTypeFormattedString>, IMockTypeTemplate
{
    public List<MockParamValue> ParamValues { get; } = [];
    public string Template { get; }

    public MockTypeFormattedString(string template)
    {
        if (string.IsNullOrWhiteSpace(template))
            throw new ArgumentException($"{nameof(template)} is required.", nameof(template));
        
        Template = template;
    }
    
    public string Get()
    {
        if (ParamValues.Count is 0) return Template;
        var formatted = Template;
        var matches = Regex.Matches(Template, MockParamValue.Pattern);
        foreach (Match match in matches)
            formatted = Regex.Replace(formatted, match.Value, Replacement(ParamValues, match.Value));
        
        return formatted;
    }
    
    public MockTypeFormattedString Param<TParam>(string paramName, Func<IMockType<TParam>> mockTypeFactory)
    {
        if (string.IsNullOrWhiteSpace(paramName))
            throw new ArgumentException($"{nameof(paramName)} is required", nameof(paramName));
        ArgumentNullException.ThrowIfNull(mockTypeFactory);

        ParamValues.Add(new MockParamValue(paramName, mockTypeFactory));

        return this;
    }

    internal MockTypeFormattedString AddParamValueRange(IEnumerable<MockParamValue> paramValues)
    {
        ArgumentNullException.ThrowIfNull(paramValues);
        ParamValues.AddRange(paramValues);
        return this;
    }
    
    private static string Replacement(List<MockParamValue> source, string name)
    {
        var pi = source.FirstOrDefault(x => name == $"{{#{x.Name}}}");
        return pi.Get();
    }

}