namespace BrightSky.DataMock;

public static class Dm
{
    public static MockTypeByte Bytes() => new();

    public static MockTypeNullableByte NullableBytes() => new();
    
    public static MockTypeShort Shorts() => new();
    
    public static MockTypeNullableShort NullableShorts() => new();
    
    public static MockTypeInt Ints() => new();
    
    public static MockTypeNullableInt NullableInts() => new();

    public static MockTypeLong Longs() => new();
    
    public static MockTypeNullableLong NullableLongs() => new();
    
    public static MockTypeBool Bools() => new();
    
    public static MockTypeNullableBool NullableBools() => new();
    
    public static MockTypeFloat Floats() => new();
    
    public static MockTypeNullableFloat NullableFloats() => new();
        
    public static MockTypeDouble Doubles() => new();
            
    public static MockTypeNullableDouble NullableDoubles() => new();

    public static MockTypeDecimal Decimals() => new();

    public static MockTypeNullableDecimal NullableDecimals() => new();
    
    public static MockTypeChar Chars() => new();
        
    public static MockTypeNullableChar NullableChars() => new();

    public static MockTypeString Strings() => new();
    
    public static MockTypeNullableString NullableStrings() => new();

    public static MockTypeIntSequence IntSequence() => new();
    
    public static MockTypeFormattedString FormattedStrings(string template) => new(template);

    public static MockTypeDateTime DateTimes() => new();
    
    public static MockTypeNullableDateTime NullableDateTimes() => new();

    public static MockTypeGuid Guids() => new();
    
    public static MockTypeNullableGuid NullableGuids() => new();
    
    public static MockTypeEmail Emails() => new();

    public static MockTypeFrom<T> From<T>(IEnumerable<T> values) => new(values);

    public static MockTypeCsv Csv() => new();
    
    public static MockTypeListOf<T> ListsOf<T>() => new();
    
    public static class Char
    {
        public static char[] BasicLatin => Enumerable.Range(32, 94).ToList().Select(x => (char)x).ToArray();
        public static char[] Digits => Enumerable.Range(48, 10).ToList().Select(x => (char)x).ToArray();
        public static char[] UppercaseLetters => Enumerable.Range(65, 25).ToList().Select(x => (char)x).ToArray();
        public static char[] LowercaseLetters => Enumerable.Range(97, 25).ToList().Select(x => (char)x).ToArray();
        public static char[] CaseInsensitiveLetters => UppercaseLetters.Concat(LowercaseLetters).ToArray();
        public static char[] AlphaNumeric => Digits.Concat(CaseInsensitiveLetters).ToArray();
        public static char[] SpecialSymbols => Enumerable.Range(32, 15).ToList().Select(x => (char)x)
            .Concat(Enumerable.Range(58, 6).ToList().Select(x => (char)x))
            .Concat(Enumerable.Range(91, 5).ToList().Select(x => (char)x))
            .Concat(Enumerable.Range(123, 3).ToList().Select(x => (char)x))
            .ToArray();
        public static char[] Space => [' '];
    }
}