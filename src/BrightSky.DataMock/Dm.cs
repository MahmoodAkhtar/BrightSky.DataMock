namespace BrightSky.DataMock;

public static class Dm
{
    public static MockTypeByte Bytes()
    {
        return new MockTypeByte();
    }

    public static MockTypeNullableByte NullableBytes()
    {
        return new MockTypeNullableByte();
    }
    
    public static MockTypeShort Shorts()
    {
        return new MockTypeShort();
    }
    
    public static MockTypeNullableShort NullableShorts()
    {
        return new MockTypeNullableShort();
    }
    
    public static MockTypeInt Ints()
    {
        return new MockTypeInt();
    }
    
    public static MockTypeNullableInt NullableInts()
    {
        return new MockTypeNullableInt();
    }

    public static MockTypeLong Longs()
    {
        return new MockTypeLong();
    }
    
    public static MockTypeNullableLong NullableLongs()
    {
        return new MockTypeNullableLong();
    }
    
    public static MockTypeBool Bools()
    {
        return new MockTypeBool();
    }
    
    public static MockTypeNullableBool NullableBools()
    {
        return new MockTypeNullableBool();
    }
    
    public static MockTypeFloat Floats()
    {
        return new MockTypeFloat();
    }
    
    public static MockTypeNullableFloat NullableFloats()
    {
        return new MockTypeNullableFloat();
    }
        
    public static MockTypeDouble Doubles()
    {
        return new MockTypeDouble();
    }
            
    public static MockTypeNullableDouble NullableDoubles()
    {
        return new MockTypeNullableDouble();
    }

    public static MockTypeDecimal Decimals()
    {
        return new MockTypeDecimal();
    }
    
    public static MockTypeChar Chars()
    {
        return new MockTypeChar();
    }
        
    public static MockTypeNullableChar NullableChars()
    {
        return new MockTypeNullableChar();
    }

    public static MockTypeString Strings()
    {
        return new MockTypeString();
    }
    
    public static MockTypeNullableString NullableStrings()
    {
        return new MockTypeNullableString();
    }
    
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

