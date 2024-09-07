namespace BrightSky.DataMock;

public record struct Percentage
{
    private readonly int _value = 0;

    public Percentage(int value)
    {        
        if (value is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(value), 
                $"{nameof(value)} {value} must be a value between 0 to 100.");
        
        _value = value;
    }
    
    public static implicit operator int(Percentage value) => value._value;
    public static implicit operator Percentage(int value) => new(value);
}