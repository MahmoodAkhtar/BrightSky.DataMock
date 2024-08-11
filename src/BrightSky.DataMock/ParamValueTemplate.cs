using System.Text.RegularExpressions;

namespace BrightSky.DataMock;

public readonly record struct ParamValue
{
    internal static string Pattern => @"{#[^}]*\w}";
    public string Name { get; }
    public Func<object> MockTypeFactory { get; }

    public ParamValue(string name, Func<object> mockTypeFactory) => (Name, MockTypeFactory) = (name, mockTypeFactory);

    public string Get()
    {
        if (MockTypeFactory is null) return string.Empty;
        var obj = MockTypeFactory();
        dynamic mockType = Convert.ChangeType(obj, obj.GetType());
        var result = mockType.Get();
    
        return result is null ? string.Empty : result.ToString();
    }

    internal static string ToParam(string name) => $"{{#{name}}}";
}

internal readonly record struct ParamValueTemplate
{
    private readonly List<ParamValue> _paramsValues = [];
    private readonly string _template;
    
    internal ParamValueTemplate(string template)
    {
        if (string.IsNullOrWhiteSpace(template))
            throw new ArgumentException($"{nameof(template)} is required.", nameof(template));
        
        _template = template;
    }

    private void Add(ParamValue paramValue)
    {
        if (!_paramsValues.Contains(paramValue))
            _paramsValues.Add(paramValue);
    }
    
    internal void AddRange(IEnumerable<ParamValue> paramValues)
    {
        foreach (var paramValue in paramValues)
            Add(paramValue);
    }
    
    internal List<string> ToList(int size = 100)
    {
        var formatted = Enumerable.Repeat(_template, size).ToList();
        var generatedValues = GenerateAllParamValues(_paramsValues, size);

        for (var i = 0; i < size; i++)
        {
            var matches = Regex.Matches(_template, ParamValue.Pattern);
            foreach (Match match in matches)
            {
                var t = generatedValues[match.Value].GetType();
                var gta = t.GenericTypeArguments[0].ToString();
                formatted[i] = Format(gta, t, formatted[i], match.Value, generatedValues, i);
            }
        }

        return formatted;
    }
    
    private static Dictionary<string, object> GenerateAllParamValues(List<ParamValue> paramValues, int size)
    {
        var generatedValues = new Dictionary<string, object>();
        foreach (var pi in paramValues)
        {
            var obj = pi.MockTypeFactory();
            dynamic mt = Convert.ChangeType(obj, obj.GetType());
            var list = MockTypeExtensions.ToList(mt, size);
            generatedValues.Add(ParamValue.ToParam(pi.Name), list);
        }

        return generatedValues;
    }
    private static string Format(string? gta, Type t, string formatted, string paramName, Dictionary<string, object> generatedValues, int i)
        => gta switch
        {
            "System.Boolean" => WhenListOf(t, formatted, paramName, ((List<bool>)generatedValues[paramName])[i]),
            "System.Byte" => WhenListOf(t, formatted, paramName, ((List<byte>)generatedValues[paramName])[i]),
            "System.Int16" => WhenListOf(t, formatted, paramName, ((List<short>)generatedValues[paramName])[i]),
            "System.Int32" => WhenListOf(t, formatted, paramName, ((List<int>)generatedValues[paramName])[i]),
            "System.Int64" => WhenListOf(t, formatted, paramName, ((List<long>)generatedValues[paramName])[i]),
            "System.Single" => WhenListOf(t, formatted, paramName, ((List<float>)generatedValues[paramName])[i]),
            "System.Double" => WhenListOf(t, formatted, paramName, ((List<double>)generatedValues[paramName])[i]),
            "System.Decimal" => WhenListOf(t, formatted, paramName, ((List<decimal>)generatedValues[paramName])[i]),
            "System.Char" => WhenListOf(t, formatted, paramName, ((List<char>)generatedValues[paramName])[i]),
            "System.String" => WhenListOf(t, formatted, paramName, ((List<string>)generatedValues[paramName])[i]),
            "System.DateTime" => WhenListOf(t, formatted, paramName, ((List<DateTime>)generatedValues[paramName])[i]),
            "System.Nullable`1[System.Boolean]" => WhenListOf(t, formatted, paramName, ((List<bool?>)generatedValues[paramName])[i]),
            "System.Nullable`1[System.Byte]" => WhenListOf(t, formatted, paramName, ((List<byte?>)generatedValues[paramName])[i]),
            "System.Nullable`1[System.Int16]" => WhenListOf(t, formatted, paramName, ((List<short?>)generatedValues[paramName])[i]),
            "System.Nullable`1[System.Int32]" => WhenListOf(t, formatted, paramName, ((List<int?>)generatedValues[paramName])[i]),
            "System.Nullable`1[System.Int64]" => WhenListOf(t, formatted, paramName, ((List<long?>)generatedValues[paramName])[i]),
            "System.Nullable`1[System.Single]" => WhenListOf(t, formatted, paramName, ((List<float?>)generatedValues[paramName])[i]),
            "System.Nullable`1[System.Double]" => WhenListOf(t, formatted, paramName, ((List<double?>)generatedValues[paramName])[i]),
            "System.Nullable`1[System.Decimal]" => WhenListOf(t, formatted, paramName, ((List<decimal?>)generatedValues[paramName])[i]),
            "System.Nullable`1[System.Char]" => WhenListOf(t, formatted, paramName, ((List<char?>)generatedValues[paramName])[i]),
            "System.Nullable`1[System.DateTime]" => WhenListOf(t, formatted, paramName, ((List<DateTime?>)generatedValues[paramName])[i]),
            _ => formatted,
        };
    
    private static string WhenListOf<T>(Type type, string formatted, string paramName, T value)
    {
        if (type == typeof(List<T>))
            formatted = ReplaceParamValue(formatted, paramName, value);

        return formatted;
    }
    
    private static string ReplaceParamValue<T>(string formatted, string paramName, T value)
    {
        var replacement = value is null ? string.Empty : value.ToString();
        return Regex.Replace(formatted, paramName, replacement!);
    }
}