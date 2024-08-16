namespace BrightSky.DataMock;

public readonly record struct MockParamValue
{
    internal static string Pattern => @"{#[^}]*\w}";

    public string Name { get; }
    public Func<object> TypeFactory { get; }
    
    public MockParamValue(string name, Func<object> typeFactory)
    {
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
        TypeFactory = typeFactory ?? throw new ArgumentNullException(nameof(typeFactory));
    }
    
    public string Get()
    {
        if (TypeFactory is null) return string.Empty;
        var obj = TypeFactory();
        dynamic mockType = Convert.ChangeType(obj, obj.GetType());
        var result = mockType.Get();
    
        return result is null ? string.Empty : result.ToString();
    }
}