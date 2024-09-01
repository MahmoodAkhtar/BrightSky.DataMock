namespace BrightSky.DataMock;

public record MockParamValue(string Name, Func<object> TypeFactory)
{
    internal static string Pattern => @"{#[^}]*\w}";

    public string Name { get; } = !string.IsNullOrWhiteSpace(Name) ? Name : throw new ArgumentNullException(nameof(Name));
    public Func<object> TypeFactory { get; } = TypeFactory ?? throw new ArgumentNullException(nameof(TypeFactory));
    
    public string Get()
    {
        var obj = TypeFactory();
        dynamic mockType = Convert.ChangeType(obj, obj.GetType());
        var result = mockType.Get();
    
        return result is null ? string.Empty : result.ToString();
    }
}