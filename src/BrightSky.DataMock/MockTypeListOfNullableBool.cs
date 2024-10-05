namespace BrightSky.DataMock;

public class MockTypeListOfNullableBool : IMockType<List<bool?>>, IMockTypeTrueAndFalseProbability<MockTypeListOfNullableBool>
{
    private bool _nullableState;
    private bool _trueState;
    private bool _falseState;
    
    public Percentage NullablePercentage { get; private set; } = (Percentage)34;
    public Percentage TruePercentage { get; private set; } = (Percentage)50;
    public Percentage FalsePercentage { get; private set; } = (Percentage)50;
    
    public List<bool?> Get()
        => Dm.NullableBools()
            .NullableProbability(NullablePercentage)
            .TrueProbability(TruePercentage)
            .FalseProbability(FalsePercentage)
            .ToList(100);

    public MockTypeListOfNullableBool NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        _nullableState = true;
        AdjustPercentages();
        
        return this;
    }
    
    public MockTypeListOfNullableBool TrueProbability(Percentage truePercentage)
    {
        TruePercentage = truePercentage;
        _trueState = true;
        AdjustPercentages();
        
        return this;
    }

    public MockTypeListOfNullableBool FalseProbability(Percentage falsePercentage)
    {
        FalsePercentage = falsePercentage;
        _falseState = true;
        AdjustPercentages();
        
        return this;
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
        var dict = new Dictionary<Func<bool>, Func<(Percentage, Percentage, Percentage)>>
        {
            { () => !_nullableState && !_trueState && !_falseState, Adjustment.Case1 },
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
        // Case 1: Default, none of the percentages have been set explicitly.
        public static (Percentage NullablePercentage, Percentage TruePercentage, Percentage FalsePercentage) Case1() 
            => ((Percentage)34, (Percentage)33, (Percentage)33);
        
        // Case 2: Only NullablePercentage has been set explicitly.
        // Therefore, distribute the remaining from 100 evenly between TruePercentage and FalsePercentage
        // with a bias to TruePercentage if uneven.
        public static (Percentage NullablePercentage, Percentage TruePercentage, Percentage FalsePercentage) Case2(Percentage nullablePercentage)
        {
            var remaining = Percentage.MaxValue - nullablePercentage;

            var dict = new Dictionary<Func<int, bool>, Func<(Percentage, Percentage, Percentage)>>
            {
                { x => x is 0,     () => (nullablePercentage, Percentage.MinValue, Percentage.MinValue) },
                { x => x is 1,     () => (nullablePercentage, (Percentage)1, Percentage.MinValue) },
                { x => x % 2 is 0, () => (nullablePercentage, (Percentage)(remaining / 2), (Percentage)(remaining / 2)) },
                { x => x % 2 is 1, () => (nullablePercentage, (Percentage)(int)Math.Ceiling(remaining / 2d), (Percentage)(int)Math.Floor(remaining / 2d)) },
            };
            
            return dict.FirstOrDefault(kvp => kvp.Key(remaining)).Value();
        }
        
        // Case 3: Only TruePercentage has been set explicitly.
        // Therefore, distribute the remaining from 100 evenly between NullablePercentage and FalsePercentage
        // with a bias to NullablePercentage if uneven.
        public static (Percentage NullablePercentage, Percentage TruePercentage, Percentage FalsePercentage) Case3(Percentage truePercentage)
        {
            var remaining = Percentage.MaxValue - truePercentage;

            var dict = new Dictionary<Func<int, bool>, Func<(Percentage, Percentage, Percentage)>>
            {
                { x => x is 0,     () => (Percentage.MinValue, truePercentage, Percentage.MinValue) },
                { x => x is 1,     () => ((Percentage)1, truePercentage, Percentage.MinValue) },
                { x => x % 2 is 0, () => ((Percentage)(remaining / 2), truePercentage,  (Percentage)(remaining / 2)) },
                { x => x % 2 is 1, () => ((Percentage)Math.Ceiling(remaining / 2d), truePercentage, (Percentage)Math.Floor(remaining / 2d)) },
            };
            
            return dict.FirstOrDefault(kvp => kvp.Key(remaining)).Value();
        }
        
        // Case 4: Only FalsePercentage has been set explicitly.
        // Therefore, distribute the remaining from 100 evenly between NullablePercentage and TruePercentage
        // with a bias to NullablePercentage if uneven.
        public static (Percentage NullablePercentage, Percentage TruePercentage, Percentage FalsePercentage) Case4(Percentage falsePercentage)
        {
            var remaining = Percentage.MaxValue - falsePercentage;
            
            var dict = new Dictionary<Func<int, bool>, Func<(Percentage, Percentage, Percentage)>>
            {
                { x => x is 0,     () => (Percentage.MinValue, Percentage.MinValue, falsePercentage) },
                { x => x is 1,     () => ((Percentage)1, Percentage.MinValue, falsePercentage) },
                { x => x % 2 is 0, () => ((Percentage)(remaining / 2), (Percentage)(remaining / 2), falsePercentage) },
                { x => x % 2 is 1, () => ((Percentage)Math.Ceiling(remaining / 2d), (Percentage)Math.Floor(remaining / 2d), falsePercentage) },
            };
            
            return dict.FirstOrDefault(kvp => kvp.Key(remaining)).Value();
        }
        
        // Case 5: Both NullablePercentage and TruePercentage have been set explicitly.
        // Therefore, distribute the remaining from 100 with FalsePercentage.
        public static (Percentage NullablePercentage, Percentage TruePercentage, Percentage FalsePercentage) Case5(Percentage nullablePercentage, Percentage truePercentage)
        {
            var falsePercentage = (Percentage)(Percentage.MaxValue - (Percentage)(nullablePercentage + truePercentage));
            return (nullablePercentage, truePercentage, falsePercentage);
        }
        
        // Case 6: Both NullablePercentage and FalsePercentage have been set explicitly.
        // Therefore, distribute the remaining from 100 with TruePercentage.
        public static (Percentage NullablePercentage, Percentage TruePercentage, Percentage FalsePercentage) Case6(Percentage nullablePercentage, Percentage falsePercentage)
        {
            var truePercentage = (Percentage)(Percentage.MaxValue - (Percentage)(nullablePercentage + falsePercentage));
            return (nullablePercentage, truePercentage, falsePercentage);
        }
                
        // Case 7: Both TruePercentage and FalsePercentage have been set explicitly.
        // Therefore, distribute the remaining from 100 with NullablePercentage.
        public static (Percentage NullablePercentage, Percentage TruePercentage, Percentage FalsePercentage) Case7(Percentage truePercentage, Percentage falsePercentage)
        {
            var nullablePercentage = (Percentage)(Percentage.MaxValue - (Percentage)(truePercentage + falsePercentage));
            return (nullablePercentage, truePercentage, falsePercentage);
        }
        
        // Case 8: All three, NullablePercentage, TruePercentage and FalsePercentage have been set explicitly.
        // Therefore, should be 0 remaining percentage.
        public static (Percentage NullablePercentage, Percentage TruePercentage, Percentage FalsePercentage) Case8(Percentage nullablePercentage, Percentage truePercentage, Percentage falsePercentage)
        {
            _ = (Percentage)(Percentage.MaxValue - (Percentage)(nullablePercentage + truePercentage + falsePercentage));
            return (nullablePercentage, truePercentage, falsePercentage);
        }
    }
}