﻿namespace BrightSky.DataMock;

public record MockTypeNullableChar : IMockType<char?>, IMockTypeRange<char?, int, int, MockTypeNullableChar>, IMockTypeNullableProbability<char, MockTypeNullableChar>
{
    private readonly Random _random = new();
    private int _minValue;
    private int _maxValue = char.MaxValue;
    private int _nullablePercentage = 50;

    public int NullablePercentage => _nullablePercentage;
    
    public MockTypeNullableChar NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }

    public char? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(int minValue, int maxValue) if you require negative values.");
        
        var weightedValues = new List<WeightedValue<Func<char?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextChar(MinValue, MaxValue), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<char?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }

    public int MinValue => _minValue;
    public int MaxValue => _maxValue;

    public MockTypeNullableChar Min(int minValue)
    {
        if (minValue < char.MinValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than char.MinValue {char.MinValue}.");
        
        _minValue = minValue;
        return this;
    }
    
    public MockTypeNullableChar Max(int maxValue)
    {
        if (maxValue > char.MaxValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be greater than char.MaxValue {char.MaxValue}.");

        _maxValue = maxValue;
        return this;
    }

    public MockTypeNullableChar Range(int minValue, int maxValue)
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