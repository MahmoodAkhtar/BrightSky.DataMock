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
}