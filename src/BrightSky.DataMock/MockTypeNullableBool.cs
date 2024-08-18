namespace BrightSky.DataMock;

public record MockTypeNullableBool : IMockType<bool?>, IMockTypeTrueAndFalseProbability<MockTypeNullableBool>, IMockTypeNullableProbability<bool?, MockTypeNullableBool>
{
    private readonly Random _random = new();

    private bool _nullableState = false;
    private bool _trueState = false;
    private bool _falseState = false;

    public int NullablePercentage { get; private set; } = 34;
    public int TruePercentage { get; private set; } = 33;
    public int FalsePercentage { get; private set; } = 33;

    public MockTypeNullableBool NullableProbability(int nullablePercentage)
    {
        if (nullablePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(nullablePercentage), $"{nameof(nullablePercentage)} {nullablePercentage} must be a value from 0 to 100.");
        
        NullablePercentage = nullablePercentage;
        _nullableState = true;
        AdjustPercentages();
        
        return this;
    }
    
    public MockTypeNullableBool TrueProbability(int truePercentage)
    {
        if (truePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(truePercentage), $"{nameof(truePercentage)} {truePercentage} must be a value from 0 to 100.");

        TruePercentage = truePercentage;
        _trueState = true;
        AdjustPercentages();
        
        return this;
    }
    
    public MockTypeNullableBool FalseProbability(int falsePercentage)
    {
        if (falsePercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(falsePercentage), $"{nameof(falsePercentage)} {falsePercentage} must be a value from 0 to 100.");

        FalsePercentage = falsePercentage;
        _falseState = true;
        AdjustPercentages();
        
        return this;
    }
    
    public bool? Get()
    {
        AdjustPercentages();
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

    private void AdjustPercentages()
    {
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
        var dict = new Dictionary<Func<bool>, Func<(int, int, int)>>
        {
            { () => !_nullableState && !_trueState && !_falseState, () => Adjustment.Case1() },
            { () => _nullableState  && !_trueState && !_falseState, () => Adjustment.Case2(NullablePercentage) },
            { () => !_nullableState && _trueState  && !_falseState, () => Adjustment.Case3(TruePercentage) },
            { () => !_nullableState && !_trueState && _falseState,  () => Adjustment.Case4(FalsePercentage) },
            { () => _nullableState  && _trueState  && !_falseState, () => Adjustment.Case5(NullablePercentage, TruePercentage) },
            { () => _nullableState  && !_trueState && _falseState,  () => Adjustment.Case6(NullablePercentage, FalsePercentage) },
            { () => !_nullableState && _trueState  && _falseState,  () => Adjustment.Case7(TruePercentage, FalsePercentage) },
            { () => _nullableState  && _trueState  && _falseState,  () => Adjustment.Case8(NullablePercentage, TruePercentage, FalsePercentage) },
        };

        (NullablePercentage, TruePercentage, FalsePercentage) = dict.FirstOrDefault(kvp => kvp.Key()).Value();
    }

    private static class Adjustment
    {
        private static int PreConditionReturnOrThrow(string paramName, int percentage)
        {
            var remaining = 100 - percentage;
            if (remaining is >= 0 and <= 100) return remaining;

            throw new ArgumentOutOfRangeException(
                paramName,
                $"{paramName} must be greater than or equal to 0 and less than or equal to 100. " +
                $"However found {paramName} = {percentage}.");
        }
        
        private static (int NullablePercentage, int TruePercentage, int FalsePercentage) PostConditionReturnOrThrow(
            int nullablePercentage,
            int truePercentage,
            int falsePercentage)
        {
            var total = nullablePercentage + truePercentage + falsePercentage;
            return total is 100
                ? (nullablePercentage, truePercentage, falsePercentage)
                : throw new ArgumentOutOfRangeException(
                    nameof(nullablePercentage), 
                    BuildExceptionMessage(nullablePercentage, truePercentage, falsePercentage, total));
        }

        private static string BuildExceptionMessage(
            int nullablePercentage, 
            int truePercentage, 
            int falsePercentage,
            int total)
        {
            return $"{nameof(nullablePercentage)} + {nameof(truePercentage)} + {nameof(falsePercentage)} must = 100 exactly." +
                   $"However found {nameof(nullablePercentage)} ({nullablePercentage}) " +
                   $"+ {nameof(truePercentage)} ({truePercentage}) " +
                   $"+ {nameof(falsePercentage)} ({falsePercentage}) = {total}";
        }

        // Case 1: Default, none of the percentages have been set explicitly.
        public static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case1() => (34, 33, 33);
        
        // Case 2: Only NullablePercentage has been set explicitly.
        // Therefore, distribute the remaining from 100 evenly between TruePercentage and FalsePercentage
        // with a bias to TruePercentage if uneven.
        public static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case2(int nullablePercentage)
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
        public static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case3(int truePercentage)
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
        public static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case4(int falsePercentage)
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
        public static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case5(int nullablePercentage, int truePercentage)
        {
            var remaining = PreConditionReturnOrThrow($"{nameof(nullablePercentage)} + {nameof(truePercentage)}", nullablePercentage + truePercentage);
            return PostConditionReturnOrThrow(nullablePercentage, truePercentage, remaining);
        }
        
        // Case 6: Both NullablePercentage and FalsePercentage have been set explicitly.
        // Therefore, distribute the remaining from 100 with TruePercentage.
        public static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case6(int nullablePercentage, int falsePercentage)
        {
            var remaining = PreConditionReturnOrThrow($"{nameof(nullablePercentage)} + {nameof(falsePercentage)}", nullablePercentage + falsePercentage);
            return PostConditionReturnOrThrow(nullablePercentage, remaining, falsePercentage);
        }
                
        // Case 7: Both TruePercentage and FalsePercentage have been set explicitly.
        // Therefore, distribute the remaining from 100 with NullablePercentage.
        public static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case7(int truePercentage, int falsePercentage)
        {
            var remaining = PreConditionReturnOrThrow($"{nameof(truePercentage)} + {nameof(falsePercentage)}", truePercentage + falsePercentage);
            return PostConditionReturnOrThrow(remaining, truePercentage, falsePercentage);
        }
        
        // Case 8: All three, NullablePercentage, TruePercentage and FalsePercentage have been set explicitly.
        // Therefore, should be 0 remaining percentage.
        public static (int NullablePercentage, int TruePercentage, int FalsePercentage) Case8(int nullablePercentage, int truePercentage, int falsePercentage)
        {
            _ = PreConditionReturnOrThrow($"{nameof(nullablePercentage)} + {nameof(truePercentage)} + {nameof(falsePercentage)}", nullablePercentage + truePercentage + falsePercentage);
            return PostConditionReturnOrThrow(nullablePercentage, truePercentage, falsePercentage);
        }
    }
}