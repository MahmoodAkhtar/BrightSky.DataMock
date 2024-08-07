﻿namespace BrightSky.DataMock;

public record MockTypeNullableInt : 
    IMockType<int?>, 
    IMockTypeMinMax<int?, int, int, MockTypeNullableInt>, 
    IMockTypeRange<int?, int, int, MockTypeNullableInt>, 
    IMockTypeNullableProbability<int?, MockTypeNullableInt>
{
    private readonly Random _random = new();
    private int _maxValue = 1000;
    private int _minValue;
    private int _nullablePercentage = 50;

    public int? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(int minValue, int maxValue) if you require negative values.");
        
        var weightedValues = new List<WeightedValue<Func<int?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.Next(MinValue, MaxValue), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<int?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }

    public int MinValue => _minValue;
    public int MaxValue => _maxValue;

    public MockTypeNullableInt Min(int minValue)
    {
        _minValue = minValue;
        return this;
    }

    public MockTypeNullableInt Max(int maxValue)
    {
        _maxValue = maxValue;
        return this;
    }

    public int NullablePercentage => _nullablePercentage;

    public MockTypeNullableInt NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableInt Range(int minValue, int maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }
}