namespace BrightSky.DataMock;

public record MockTypeFrom<T> : IMockType<T>
{
    private readonly Random _random = new();
    private readonly List<T> _values = [];
    
    public MockTypeFrom(IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        _values = values.ToList();
        if (_values.Count is 0)
            throw new ArgumentOutOfRangeException(nameof(values));
    }

    public T Get() => _values[_random.Next(0, _values.Count)];
}