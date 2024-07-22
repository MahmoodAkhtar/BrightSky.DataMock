namespace BrightSky.DataMock;

internal static class HelperExtensions
{
    public static List<T> Shuffle<T>(this List<T> list)
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
    
    public static short NextShort(this Random random, short minValue, short maxValue)
    {
        if (random is null)
            throw new ArgumentNullException(nameof(random));
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue} try using Range(short minValue, short maxValue) if you require negative values.");
        
        return (short)random.Next(minValue, maxValue);
    }
    
    public static byte NextByte(this Random random, byte minValue, byte maxValue)
    {
        if (random is null)
            throw new ArgumentNullException(nameof(random));
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue} try using Range(short minValue, short maxValue) if you require negative values.");
        
        return (byte)random.Next(minValue, maxValue);
    }
}