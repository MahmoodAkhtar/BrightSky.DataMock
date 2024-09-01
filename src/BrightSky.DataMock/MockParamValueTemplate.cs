using System.Text.RegularExpressions;

namespace BrightSky.DataMock;

internal record MockParamValueTemplate(string Template)
{
    private readonly List<MockParamValue> _paramsValues = [];
    internal string Template { get; } = !string.IsNullOrWhiteSpace(Template) ? Template : throw new ArgumentException($"{nameof(Template)} is required.", nameof(Template));

    private void Add(MockParamValue paramValue)
    {
        if (!_paramsValues.Contains(paramValue))
            _paramsValues.Add(paramValue);
    }
    
    internal void AddRange(IEnumerable<MockParamValue> paramValues)
    {
        foreach (var paramValue in paramValues)
            Add(paramValue);
    }
    
    internal List<string> ToList(int size = 100)
    {
        var formatted = Enumerable.Repeat(Template, size).ToList();
        var generatedValues = GenerateAllParamValues(_paramsValues, size);

        for (var i = 0; i < size; i++)
        {
            var matches = Regex.Matches(Template, MockParamValue.Pattern);
            foreach (Match match in matches)
            {
                var t = generatedValues[match.Value].GetType();
                var gta = t.GenericTypeArguments[0].ToString();
                formatted[i] = Format(gta, t, formatted[i], match.Value, generatedValues, i);
            }
        }

        return formatted;
    }
    
    private static Dictionary<string, object> GenerateAllParamValues(List<MockParamValue> paramValues, int size)
    {
        var generatedValues = new Dictionary<string, object>();
        foreach (var paramValue in paramValues)
        {
            var obj = paramValue.TypeFactory();
            dynamic mt = Convert.ChangeType(obj, obj.GetType());
            var list = MockTypeExtensions.ToList(mt, size);
            generatedValues.Add(paramValue.Paramify(), list);
        }

        return generatedValues;
    }
    
    private static string Format(string gta, Type t, string formatted, string paramName, Dictionary<string, object> generatedValues, int i)
    {
        var dict = new Dictionary<Func<bool>, Func<string>>
        {
            { () => gta == "System.Boolean", () => WhenListOf(t, formatted, paramName, ((List<bool>)generatedValues[paramName])[i]) }, 
            { () => gta == "System.Byte", () => WhenListOf(t, formatted, paramName, ((List<byte>)generatedValues[paramName])[i]) },
            { () => gta == "System.Int16", () => WhenListOf(t, formatted, paramName, ((List<short>)generatedValues[paramName])[i]) },
            { () => gta == "System.Int32", () => WhenListOf(t, formatted, paramName, ((List<int>)generatedValues[paramName])[i]) },
            { () => gta == "System.Int64", () => WhenListOf(t, formatted, paramName, ((List<long>)generatedValues[paramName])[i]) },
            { () => gta == "System.Single", () => WhenListOf(t, formatted, paramName, ((List<float>)generatedValues[paramName])[i]) },
            { () => gta == "System.Double", () => WhenListOf(t, formatted, paramName, ((List<double>)generatedValues[paramName])[i]) },
            { () => gta == "System.Decimal", () => WhenListOf(t, formatted, paramName, ((List<decimal>)generatedValues[paramName])[i]) },
            { () => gta == "System.Char", () => WhenListOf(t, formatted, paramName, ((List<char>)generatedValues[paramName])[i]) },
            { () => gta == "System.String", () => WhenListOf(t, formatted, paramName, ((List<string>)generatedValues[paramName])[i]) },
            { () => gta == "System.DateTime", () => WhenListOf(t, formatted, paramName, ((List<DateTime>)generatedValues[paramName])[i]) },
            { () => gta == "System.Nullable`1[System.Boolean]", () => WhenListOf(t, formatted, paramName, ((List<bool?>)generatedValues[paramName])[i]) },
            { () => gta == "System.Nullable`1[System.Byte]", () => WhenListOf(t, formatted, paramName, ((List<byte?>)generatedValues[paramName])[i]) },
            { () => gta == "System.Nullable`1[System.Int16]", () => WhenListOf(t, formatted, paramName, ((List<short?>)generatedValues[paramName])[i]) },
            { () => gta == "System.Nullable`1[System.Int32]", () => WhenListOf(t, formatted, paramName, ((List<int?>)generatedValues[paramName])[i]) },
            { () => gta == "System.Nullable`1[System.Int64]", () => WhenListOf(t, formatted, paramName, ((List<long?>)generatedValues[paramName])[i]) },
            { () => gta == "System.Nullable`1[System.Single]", () => WhenListOf(t, formatted, paramName, ((List<float?>)generatedValues[paramName])[i]) },
            { () => gta == "System.Nullable`1[System.Double]", () => WhenListOf(t, formatted, paramName, ((List<double?>)generatedValues[paramName])[i]) },
            { () => gta == "System.Nullable`1[System.Decimal]", () => WhenListOf(t, formatted, paramName, ((List<decimal?>)generatedValues[paramName])[i]) },
            { () => gta == "System.Nullable`1[System.Char]", () => WhenListOf(t, formatted, paramName, ((List<char?>)generatedValues[paramName])[i]) },
            { () => gta == "System.Nullable`1[System.DateTime]", () => WhenListOf(t, formatted, paramName, ((List<DateTime?>)generatedValues[paramName])[i]) },
        };
        
        var matched = dict
            .Where(kvp => kvp.Key())
            .Select(kvp => kvp.Value())
            .FirstOrDefault();
        
        return matched ?? formatted;
    }
    
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