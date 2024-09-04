namespace BrightSky.DataMock;

internal static class ListExtensions
{
    internal static List<T> Shuffle<T>(this List<T> list)
    {
        var random = new Random();
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = random.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }

        return list;
    }
    
    internal static List<RangedValue<T>> ToRangeValues<T>(this List<WeightedValue<T>> values)
    {
        var index = 0;
        var list = new List<RangedValue<T>>();
        var filtered = values.Where(x => x.Weight > 0);
        foreach (var value in filtered)
        {
            list.Add(new RangedValue<T>(value.Value, index +1, index + value.Weight));
            index += value.Weight;
        }

        return list;
    }

    internal static T Next<T>(this List<WeightedValue<T>> values)
    {
        var r = new Random().Next(1, values.Sum(x => x.Weight) + 1);
        return values.ToRangeValues().First(x => r >= x.Start && r <= x.End).Value;
    }
    
    //TODO: YAGNI ??? - Still need to consider how to do automated combinations ... 
    internal static List<List<T>> Combination<T>(this List<T> values) =>
        values.Aggregate(
            seed: new List<List<T>>(),
            func: (acc, t) =>
            {
                var acc2 = acc.SelectMany(item =>
                {
                    var prepended = new List<T> { t };
                    prepended.AddRange(item);
                    var appended = new List<T>(item) { t };
                    return new List<List<T>> { item, prepended, appended };
                }).ToList();

                acc2.Add([t]);
                return acc2;
            });
}