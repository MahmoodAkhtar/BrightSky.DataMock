namespace BrightSky.DataMock;

public static class Dm
{
    public static MockTypeByte Bytes()
    {
        return new MockTypeByte();
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
}

