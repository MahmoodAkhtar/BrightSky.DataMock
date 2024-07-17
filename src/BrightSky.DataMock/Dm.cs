namespace BrightSky.DataMock;

public static class Dm
{
    public static MockTypeInt Ints()
    {
        return new MockTypeInt();
    }
    
    public static MockTypeNullableInt NullableInts()
    {
        return new MockTypeNullableInt();
    }
    
    public static MockTypeBool Bools()
    {
        return new MockTypeBool();
    }
}

