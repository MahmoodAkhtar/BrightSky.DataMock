﻿namespace BrightSky.DataMock;

public class MockTypeNullableGuid : 
    IMockType<Guid?>,
    IMockTypeNullableProbability<Guid?, MockTypeNullableGuid>
{
    private int _nullablePercentage = 50;
    
    public Guid? Get()
    {
        var weightedValues = new List<WeightedValue<Func<Guid?>>>
        {
            new(() => null, NullablePercentage),
            new(() => Guid.NewGuid(), 100 - NullablePercentage),
        };
        
        var weighted = new Weighted<Func<Guid?>>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen();
    }

    public int NullablePercentage => _nullablePercentage;
    
    public MockTypeNullableGuid NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        return this;
    }
}