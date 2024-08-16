namespace BrightSky.DataMock;

public readonly record struct MockParamValue(string Name, Func<object> TypeFactory)
{
    internal static string Pattern => @"{#[^}]*\w}";

    public string Get()
    {
        if (TypeFactory is null) return string.Empty;
        var obj = TypeFactory();
        dynamic mockType = Convert.ChangeType(obj, obj.GetType());
        var result = mockType.Get();
    
        return result is null ? string.Empty : result.ToString();
    }
}