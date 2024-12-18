﻿namespace BrightSky.DataMock;

public record MockTypeNullableDecimal : 
    IMockType<decimal?>, 
    IMockTypeMinMax<decimal?, decimal, decimal, MockTypeNullableDecimal>,
    IMockTypeRange<decimal?, decimal, decimal, MockTypeNullableDecimal>, 
    IMockTypeNullableProbability<decimal?, MockTypeNullableDecimal>
{
    private readonly Random _random = new();

    public decimal? Get()
    {
        if (MaxValue < MinValue) 
            throw new ArgumentOutOfRangeException(nameof(MaxValue), $"{nameof(MaxValue)} {MaxValue} cannot be less than {nameof(MinValue)} {MinValue} try using Range(decimal minValue, decimal maxValue) if you require negative values.");
        
        var chosen = new List<WeightedValue<Func<decimal?>>>
        {
            new(() => null, NullablePercentage),
            new(() => _random.NextDecimal(MinValue, MaxValue), 100 - NullablePercentage),
        }.Next();
        
        return chosen();
    }

    public decimal MinValue { get; private set; } = decimal.MinValue;
    public decimal MaxValue { get; private set; } = decimal.MaxValue;

    public MockTypeNullableDecimal Min(decimal minValue)
    {
        MinValue = minValue;
        return this;
    }

    public MockTypeNullableDecimal Max(decimal maxValue)
    {
        MaxValue = maxValue;
        return this;
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeNullableDecimal NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        return this;
    }

    public MockTypeNullableDecimal Range(decimal minValue, decimal maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} {maxValue} cannot be less than {nameof(minValue)} {minValue}.");

        MinValue = minValue;
        MaxValue = maxValue;
        return this;
    }
}