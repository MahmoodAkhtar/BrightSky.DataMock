using System.Text.RegularExpressions;

namespace BrightSky.DataMock;

public record MockTypeFormattedString : IMockType<string>, IMockTypeParam<string, MockTypeFormattedString>
{
    private record ParamInfo(string Name, Func<object> MockTypeFactory)
    {
        internal string InvokeGet()
        {
            var obj = MockTypeFactory();
            dynamic mockType = Convert.ChangeType(obj, obj.GetType());
            var result = mockType.Get();
        
            return result is null ? string.Empty : result.ToString();
        }
    }
    
    private List<ParamInfo> _params = [];
    private readonly string _template;
    private readonly string _pattern = @"{#[^}]*\w}";
    
    public MockTypeFormattedString(string template)
    {
        if (string.IsNullOrWhiteSpace(template))
            throw new ArgumentException($"{nameof(template)} is required.", nameof(template));
        
        _template = template;
    }
    
    public string Get()
    {
        if (_params.Count is 0) return _template;
        var formatted = _template;
        var matches = Regex.Matches(_template, _pattern);
        foreach (Match match in matches)
            formatted = Regex.Replace(formatted, match.Value, Replacement(_params, match.Value));
        
        return formatted;
    }

    public MockTypeFormattedString Param<TParam>(string paramName, Func<IMockType<TParam>> mockTypeFactory)
    {
        if (string.IsNullOrWhiteSpace(paramName))
            throw new ArgumentException($"{nameof(paramName)} is required", nameof(paramName));
        if (mockTypeFactory is null)
            throw new ArgumentNullException(nameof(mockTypeFactory));
        
        _params.Add(new ParamInfo(paramName, mockTypeFactory));

        return this;
    }
    
    private static string Replacement(List<ParamInfo> source, string name)
    {
        var pi = source.FirstOrDefault(x => name == $"{{#{x.Name}}}");
        return pi is null ? string.Empty : pi.InvokeGet();
    }
}