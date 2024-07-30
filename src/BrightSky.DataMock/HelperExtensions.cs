namespace BrightSky.DataMock;

// TODO: Refactor this eventually ... feels like 2 separate concerns ???
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
    
    public static float NextFloat(this Random random, float minValue, float maxValue)
    {
        if (random is null)
            throw new ArgumentNullException(nameof(random));
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue} try using Range(float minValue, float maxValue) if you require negative values.");
        
        double range = (double)maxValue - (double)minValue;
        double r = random.NextDouble();
        double scaled = (r * range) + minValue;
        
        return (float)scaled;;
    }
        
    public static double NextDouble(this Random random, double minValue, double maxValue)
    {
        if (random is null)
            throw new ArgumentNullException(nameof(random));
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue} try using Range(double minValue, double maxValue) if you require negative values.");
        
        double range = maxValue - minValue;
        double r = random.NextDouble();
        double scaled = (r * range) + minValue;
        
        return scaled;
    }
    
    public static decimal NextDecimal(this Random random, decimal minValue, decimal maxValue)
    {
        if (random is null)
            throw new ArgumentNullException(nameof(random));
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue} try using Range(decimal minValue, decimal maxValue) if you require negative values.");
        
        var result = (maxValue - minValue) * random.NextDecimal() + minValue;
        
        return result;
    }
    
    private static decimal NextDecimal(this Random random)
    {
        if (random is null)
            throw new ArgumentNullException(nameof(random));
        
        var rightHandSide = Enumerable.Range(0, 29).Select(x => random.Next(10).ToString());
        var result = decimal.Parse($"0.{string.Join(string.Empty, rightHandSide)}");
        
        return result / 1.000000000000000000000000000000000m;
    }
    
    public static char NextChar(this Random random, int minValue, int maxValue)
    {
        if (random is null)
            throw new ArgumentNullException(nameof(random));
        if (minValue < char.MinValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than char.MinValue {char.MinValue}.");
        if (maxValue > char.MaxValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be greater than char.MaxValue {char.MaxValue}.");
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");
        
        return (char)random.Next(minValue, maxValue);
    }
}