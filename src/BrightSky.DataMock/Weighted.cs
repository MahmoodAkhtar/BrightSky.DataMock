namespace BrightSky.DataMock;

internal record WeightedValue<T>(T Value, int Weight);

internal record RangedValue<T>(T Value, int Start, int End);

internal record Weighted<T>(List<WeightedValue<T>> Values)
{
    internal List<WeightedValue<T>> Values { get; init; } = Values is null ? [] : Values;
    
    private readonly Random _random = new();
    private readonly List<RangedValue<T>> _rangedValues = RangeValues(Values!);
    private readonly int _totalWeight = Values!.Sum(x => x.Weight);
    
    public T Next()
    {
        var r = _random.Next(1, _totalWeight + 1);
        return _rangedValues.First(x => r >= x.Start && r <= x.End).Value;
    }
    
    public static List<RangedValue<T>> RangeValues(List<WeightedValue<T>> values)
    {
        var runningIndex = 0;
        var rangedValues = new List<RangedValue<T>>();
        values = values.Where(x => x.Weight > 0).ToList();
        foreach (var value in values)
        {
            var start = runningIndex +1;
            var end = runningIndex + value.Weight;
            rangedValues.Add(new RangedValue<T>(value.Value, start, end));
            runningIndex = end;
        }

        return rangedValues;
    }
}