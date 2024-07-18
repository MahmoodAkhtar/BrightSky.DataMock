namespace BrightSky.DataMock;

public record MockTypeNullableBool : IMockType<bool?>, IMockTypeTrueProbability<MockTypeNullableBool>, IMockTypeNullableProbability<bool, MockTypeNullableBool>
{
    private readonly Random _random = new();
    private int _nullablePercentage = 34;
    private int _truePercentage = 33;
    private int _falsePercentage = 33;

    private bool _nullablePercentageHasBeenSet = false;
    private bool _truePercentageHasBeenSet = false;
    private bool _falsePercentageHasBeenSet = false;

    public int NullablePercentage => _nullablePercentage;
    public int TruePercentage => _truePercentage;
    public int FalsePercentage => _falsePercentage;
    
    public MockTypeNullableBool NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        _nullablePercentageHasBeenSet = true;
        return this;
    }
    
    public MockTypeNullableBool TrueProbability(int truePercentage)
    {
        if (truePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(truePercentage), $"{nameof(truePercentage)} {truePercentage} must be a value from 0 to 100.");

        _truePercentage = truePercentage;
        _truePercentageHasBeenSet = true;
        return this;
    }
    
    public MockTypeNullableBool FalseProbability(int falsePercentage)
    {
        if (falsePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(falsePercentage), $"{nameof(falsePercentage)} {falsePercentage} must be a value from 0 to 100.");

        _falsePercentage = falsePercentage;
        _falsePercentageHasBeenSet = true;
        return this;
    }
    
    public bool? Get()
    {
        CalculatePercentages();
        
        var nullable = _random.NextDouble() <= NullablePercentage / 100.0;
        
        return nullable ? null : _random.NextDouble() <= TruePercentage / 100.0;
    }

    /*
     Default for null  = 34%
     Default for true  = 33%
     Default for false = 33%
     
     Either all percentages are explicitly set,
     and they then must all add up to exactly 100.
     
     Or only one or two are set explicitly, in
     which case we need to then work out the
     implicit values accordingly. See below table.
     
    -------------------------
    |	Null|   True| False	|		
    |=======|=======|=======|		
    |	-	|	-	|  	-	|	Case 1 -> none set therefore use defaults	
    |	X	|	-	|	-	|	Case 2 ---
    |	-	|	X	|	-	|	Case 3   |
    |	-	|	-	|	X	|	Case 4   | -> need to work all these use
    |	X	|	X	|	-	|	Case 5   |    cases out to evenly
    |	X	|	-	|	X	|	Case 6   |    distribute percentages
    |	-	|	X	|	X	|	Case 7 ---
    |	X	|	X	|	X	|	Case 8 -> all set explicitly, must = 100
    -------------------------
     */
    private void CalculatePercentages()
    {
        throw new NotImplementedException();
    }
}