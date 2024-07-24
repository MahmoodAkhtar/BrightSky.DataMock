namespace BrightSky.DataMock;

public record MockTypeChar : IMockType<char>, IMockTypeRange<char, int, int, MockTypeChar>
{
    private readonly Random _random = new();
    private int _minValue;
    private int _maxValue = char.MaxValue;

    public char Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue}.");
        
        return _random.NextChar(MinValue, MaxValue);
    }

    public int MinValue => _minValue;
    public int MaxValue => _maxValue;

    public MockTypeChar Min(int minValue)
    {
        if (minValue < char.MinValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than char.MinValue {char.MinValue}.");
        if (minValue > char.MaxValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be greater than char.MaxValue {char.MaxValue}.");
        
        _minValue = minValue;
        return this;
    }
    
    public MockTypeChar Max(int maxValue)
    {
        if (maxValue < char.MinValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than than char.MinValue {char.MinValue}.");
        if (maxValue > char.MaxValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be greater than char.MaxValue {char.MaxValue}.");

        _maxValue = maxValue;
        return this;
    }

    public MockTypeChar Range(int minValue, int maxValue)
    {
        if (minValue < char.MinValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than char.MinValue {char.MinValue}.");
        if (maxValue > char.MaxValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be greater than char.MaxValue {char.MaxValue}.");
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}