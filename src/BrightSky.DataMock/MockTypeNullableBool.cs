namespace BrightSky.DataMock;

public record MockTypeNullableBool : IMockType<bool?>, IMockTypeTrueProbability<MockTypeNullableBool>, IMockTypeNullableProbability<bool, MockTypeNullableBool>
{
    private readonly Random _random = new();
    private int _nullablePercentage = 34;
    private int _truePercentage = 33;
    private int _falsePercentage = 33;

    private bool _nullableState = false;
    private bool _trueState = false;
    private bool _falseState = false;

    public int NullablePercentage => _nullablePercentage;
    public int TruePercentage => _truePercentage;
    public int FalsePercentage => _falsePercentage;
    
    public MockTypeNullableBool NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        _nullablePercentage = nullablePercentage;
        _nullableState = true;

        (_nullablePercentage, _truePercentage, _falsePercentage) = PercentageCalculator.Calculate(
            _nullableState, _trueState, _falseState, NullablePercentage, TruePercentage, FalsePercentage);
        
        return this;
    }
    
    public MockTypeNullableBool TrueProbability(int truePercentage)
    {
        if (truePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(truePercentage), $"{nameof(truePercentage)} {truePercentage} must be a value from 0 to 100.");

        _truePercentage = truePercentage;
        _trueState = true;
        
        (_nullablePercentage, _truePercentage, _falsePercentage) = PercentageCalculator.Calculate(
            _nullableState, _trueState, _falseState, NullablePercentage, TruePercentage, FalsePercentage);
        
        return this;
    }
    
    public MockTypeNullableBool FalseProbability(int falsePercentage)
    {
        if (falsePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(falsePercentage), $"{nameof(falsePercentage)} {falsePercentage} must be a value from 0 to 100.");

        _falsePercentage = falsePercentage;
        _falseState = true;
        
        (_nullablePercentage, _truePercentage, _falsePercentage) = PercentageCalculator.Calculate(
            _nullableState, _trueState, _falseState, NullablePercentage, TruePercentage, FalsePercentage);
        
        return this;
    }
    
    public bool? Get()
    {
        (_nullablePercentage, _truePercentage, _falsePercentage) = PercentageCalculator.Calculate(
            _nullableState, _trueState, _falseState, NullablePercentage, TruePercentage, FalsePercentage);

        var weightedValues = new List<WeightedValue<bool?>>
        {
            new(null, NullablePercentage),
            new(true, TruePercentage),
            new(false, FalsePercentage),
        };

        var weighted = new Weighted<bool?>(weightedValues, new Random());
        var chosen = weighted.Next();
        
        return chosen;
    }

    // TODO: Refactor this PercentageCalculator seems too much code for what it is doing ??? 
    /*
     Default for null  = 34%
     Default for true  = 33%
     Default for false = 33%
     
     Either all percentages are explicitly set,
     and they then must all add up to exactly 100.
     
     Or only one or two are set explicitly, in
     which case we need to then work out the
     implicit values accordingly. See below table.
     
    -----------------------------------------
    |    Null    |    True    |    False    |		
    |============|============|=============|		
    |    -       |    -       |    -        |    Case 1 ----> none set therefore use defaults	
    |    X       |    -       |    -        |    Case 2 ------
    |    -       |    X       |    -        |    Case 3      |
    |    -       |    -       |    X        |    Case 4      | -> need to work all these use
    |    X       |    X       |    -        |    Case 5      |    cases out to evenly
    |    X       |    -       |    X        |    Case 6      |    distribute percentages
    |    -       |    X       |    X        |    Case 7 ------
    |    X       |    X       |    X        |    Case 8 ----> all set explicitly, must = 100
    -----------------------------------------
    */
    private static class PercentageCalculator
    {
        public static (int NullablePercentage, int TruePercentage, int FalsePercentage) Calculate(
            bool nullableState,
            bool trueState, 
            bool falseState,
            int nullablePercentage,
            int truePercentage,
            int falsePercentage)
        {
            var dict = new Dictionary<Func<bool>, Func<(int, int, int)>>
            {
                { () => !nullableState && !trueState && !falseState, () => Case1() },
                { () => nullableState  && !trueState && !falseState, () => Case2(nullablePercentage) },
                { () => !nullableState && trueState  && !falseState, () => Case3(truePercentage) },
                { () => !nullableState && !trueState && falseState,  () => Case4(falsePercentage) },
                { () => nullableState  && trueState  && !falseState, () => Case5(nullablePercentage, truePercentage) },
                { () => nullableState  && !trueState && falseState,  () => Case6(nullablePercentage, falsePercentage) },
                { () => !nullableState && trueState  && falseState,  () => Case7(truePercentage, falsePercentage) },
                { () => nullableState  && trueState  && falseState,  () => Case8(nullablePercentage, truePercentage, falsePercentage) },
            };

            return dict.FirstOrDefault(kvp => kvp.Key()).Value();
        }

        private static int PreConditionReturnOrThrow(string paramName, int percentage)
        {
            var remaining = 100 - percentage;
            if (remaining is >= 0 and <= 100) return remaining;

            throw new InvalidOperationException(
                $"{paramName} must be greater than or equal to 0 and less than or equal to 100. " +
                $"However found {paramName} = {percentage}.");
        }
        
        private static (int NullablePercentage, int TruePercentage, int FalsePercentage) PostConditionReturnOrThrow(
            int nullablePercentage,
            int truePercentage,
            int falsePercentage)
        {
            var total = nullablePercentage + truePercentage + falsePercentage;
            if (total is 100) return (nullablePercentage, truePercentage, falsePercentage);

            throw new InvalidOperationException(
                $"{nameof(nullablePercentage)} + {nameof(truePercentage)} + {nameof(falsePercentage)} must = 100 exactly." +
                $"However found {nameof(nullablePercentage)} ({nullablePercentage}) " +
                $"+ {nameof(truePercentage)} ({truePercentage}) " +
                $"+ {nameof(falsePercentage)} ({falsePercentage}) = {total}");
        }
        
        // Case 1: Default, none of the percentages have been set explicitly.
        private static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case1()
            => (34, 33, 33);
        
        // Case 2: Only NullablePercentage has been set explicitly.
        // Therefore, distribute the remaining from 100 evenly between TruePercentage and FalsePercentage
        // with a bias to TruePercentage if uneven.
        private static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case2(int nullablePercentage)
        {
            var remaining = PreConditionReturnOrThrow(nameof(nullablePercentage), nullablePercentage);

            var dict = new Dictionary<Func<int, bool>, Func<(int, int, int)>>
            {
                { x => x is 0,     () => (nullablePercentage, 0, 0) },
                { x => x is 1,     () => (nullablePercentage, 1, 0) },
                { x => x % 2 is 0, () => (nullablePercentage, remaining / 2, remaining / 2) },
                { x => x % 2 is 1, () => (nullablePercentage, (int)Math.Ceiling(remaining / 2d), (int)Math.Floor(remaining / 2d)) },
            };
            
            var (np, tp, fp) = dict.FirstOrDefault(kvp => kvp.Key(remaining)).Value();
            
            return PostConditionReturnOrThrow(np, tp, fp);
        }
        
        // Case 3: Only TruePercentage has been set explicitly.
        // Therefore, distribute the remaining from 100 evenly between NullablePercentage and FalsePercentage
        // with a bias to NullablePercentage if uneven.
        private static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case3(int truePercentage)
        {
            var remaining = PreConditionReturnOrThrow(nameof(truePercentage), truePercentage);

            var dict = new Dictionary<Func<int, bool>, Func<(int, int, int)>>
            {
                { x => x is 0,     () => (0, truePercentage, 0) },
                { x => x is 1,     () => (1, truePercentage, 0) },
                { x => x % 2 is 0, () => (remaining / 2, truePercentage,  remaining / 2) },
                { x => x % 2 is 1, () => ((int)Math.Ceiling(remaining / 2d), truePercentage, (int)Math.Floor(remaining / 2d)) },
            };
            
            var (np, tp, fp) = dict.FirstOrDefault(kvp => kvp.Key(remaining)).Value();
            
            return PostConditionReturnOrThrow(np, tp, fp);
        }
        
        // Case 4: Only FalsePercentage has been set explicitly.
        // Therefore, distribute the remaining from 100 evenly between NullablePercentage and TruePercentage
        // with a bias to NullablePercentage if uneven.
        private static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case4(int falsePercentage)
        {
            var remaining = PreConditionReturnOrThrow(nameof(falsePercentage), falsePercentage);
            
            var dict = new Dictionary<Func<int, bool>, Func<(int, int, int)>>
            {
                { x => x is 0,     () => (0, 0, falsePercentage) },
                { x => x is 1,     () => (1, 0, falsePercentage) },
                { x => x % 2 is 0, () => (remaining / 2, remaining / 2, falsePercentage) },
                { x => x % 2 is 1, () => ((int)Math.Ceiling(remaining / 2d), (int)Math.Floor(remaining / 2d), falsePercentage) },
            };
            
            var (np, tp, fp) = dict.FirstOrDefault(kvp => kvp.Key(remaining)).Value();
            
            return PostConditionReturnOrThrow(np, tp, fp);
        }
        
        // Case 5: Both NullablePercentage and TruePercentage have been set explicitly.
        // Therefore, distribute the remaining from 100 with FalsePercentage.
        private static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case5(int nullablePercentage, int truePercentage)
        {
            var remaining = PreConditionReturnOrThrow($"{nameof(nullablePercentage)} + {nameof(truePercentage)}", nullablePercentage + truePercentage);
            return PostConditionReturnOrThrow(nullablePercentage, truePercentage, remaining);
        }
        
        // Case 6: Both NullablePercentage and FalsePercentage have been set explicitly.
        // Therefore, distribute the remaining from 100 with TruePercentage.
        private static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case6(int nullablePercentage, int falsePercentage)
        {
            var remaining = PreConditionReturnOrThrow($"{nameof(nullablePercentage)} + {nameof(falsePercentage)}", nullablePercentage + falsePercentage);
            return PostConditionReturnOrThrow(nullablePercentage, remaining, falsePercentage);
        }
                
        // Case 7: Both TruePercentage and FalsePercentage have been set explicitly.
        // Therefore, distribute the remaining from 100 with NullablePercentage.
        private static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case7(int truePercentage, int falsePercentage)
        {
            var remaining = PreConditionReturnOrThrow($"{nameof(truePercentage)} + {nameof(falsePercentage)}", truePercentage + falsePercentage);
            return PostConditionReturnOrThrow(remaining, truePercentage, falsePercentage);
        }
        
        // Case 8: All three, NullablePercentage, TruePercentage and FalsePercentage have been set explicitly.
        // Therefore, should be 0 remaining percentage.
        private static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case8(int nullablePercentage, int truePercentage, int falsePercentage)
        {
            _ = PreConditionReturnOrThrow($"{nameof(nullablePercentage)} + {nameof(truePercentage)} + {nameof(falsePercentage)}", nullablePercentage + truePercentage + falsePercentage);
            return PostConditionReturnOrThrow(nullablePercentage, truePercentage, falsePercentage);
        }
    }
}