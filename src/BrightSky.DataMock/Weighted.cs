namespace BrightSky.DataMock;

internal readonly record struct WeightedValue<T>(T Value, int Weight);
internal readonly record struct RangedValue<T>(T Value, int Start, int End);

internal readonly record struct Weighted<T>
{
    private readonly Random _random;
    private readonly List<RangedValue<T>> _rangedValues = [];
    private readonly int _totalWeight = 0;
    
    public Weighted(List<WeightedValue<T>> values, Random random)
    {
        _random = random;
        _totalWeight = values.Sum(x => x.Weight);
        _rangedValues = RangeValues(values);
    }

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