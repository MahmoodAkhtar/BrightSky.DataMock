namespace BrightSky.DataMock;

public class MockTypeNullableGuid : 
    IMockType<Guid?>,
    IMockTypeNullableProbability<Guid?, MockTypeNullableGuid>,
    IMockTypeEmptyNonEmptyProbability<Guid?, MockTypeNullableGuid>
{
    private bool _nullableState;
    private bool _nonEmptyState;
    private bool _emptyState;
    
    public Guid? Get()
    {
        AdjustPercentages();
        var chosen = new List<WeightedValue<Func<Guid?>>>
        {
            new(() => null, NullablePercentage),
            new(() => Guid.NewGuid(), NonEmptyPercentage),
            new(() => Guid.Empty, EmptyPercentage),
        }.Next();
        
        return chosen();
    }

    public Percentage NullablePercentage { get; private set; } = (Percentage)50;

    public MockTypeNullableGuid NullableProbability(Percentage nullablePercentage)
    {
        NullablePercentage = nullablePercentage;
        _nullableState = true;
        AdjustPercentages();
        
        return this;
    }

    public Percentage NonEmptyPercentage { get; private set; } = (Percentage)50;
    public Percentage EmptyPercentage { get; private set; } = (Percentage)50;
    
    public MockTypeNullableGuid NonEmptyProbability(Percentage nonEmptyPercentage)
    {
        EmptyPercentage = nonEmptyPercentage;
        _nonEmptyState = true;
        AdjustPercentages();
        
        return this;       
    }

    public MockTypeNullableGuid EmptyProbability(Percentage emptyPercentage)
    {
        NonEmptyPercentage = emptyPercentage;
        _emptyState = true;
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
            { () => !_nullableState && !_nonEmptyState && !_emptyState, Adjustment.Case1 },
            { () => _nullableState  && !_nonEmptyState && !_emptyState, () => Adjustment.Case2(NullablePercentage) },
            { () => !_nullableState && _nonEmptyState  && !_emptyState, () => Adjustment.Case3(NonEmptyPercentage) },
            { () => !_nullableState && !_nonEmptyState && _emptyState,  () => Adjustment.Case4(EmptyPercentage) },
            { () => _nullableState  && _nonEmptyState  && !_emptyState, () => Adjustment.Case5(NullablePercentage, NonEmptyPercentage) },
            { () => _nullableState  && !_nonEmptyState && _emptyState,  () => Adjustment.Case6(NullablePercentage, EmptyPercentage) },
            { () => !_nullableState && _nonEmptyState  && _emptyState,  () => Adjustment.Case7(NonEmptyPercentage, EmptyPercentage) },
            { () => _nullableState  && _nonEmptyState  && _emptyState,  () => Adjustment.Case8(NullablePercentage, NonEmptyPercentage, EmptyPercentage) },
        };

        (NullablePercentage, NonEmptyPercentage, EmptyPercentage) = dict.FirstOrDefault(kvp => kvp.Key()).Value();
    }

    private static class Adjustment
    {
        // Case 1: Default, none of the percentages have been set explicitly.
        public static (Percentage NullablePercentage, Percentage NonEmptyPercentage, Percentage EmptyPercentage) Case1() 
            => ((Percentage)34, (Percentage)33, (Percentage)33);
        
        // Case 2: Only NullablePercentage has been set explicitly.
        // Therefore, distribute the remaining from 100 evenly between NonEmptyPercentage and EmptyPercentage
        // with a bias to NonEmptyPercentage if uneven.
        public static (Percentage NullablePercentage, Percentage NonEmptyPercentage, Percentage EmptyPercentage) Case2(Percentage nullablePercentage)
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
        
        // Case 3: Only NonEmptyPercentage has been set explicitly.
        // Therefore, distribute the remaining from 100 evenly between NullablePercentage and EmptyPercentage
        // with a bias to NullablePercentage if uneven.
        public static (Percentage NullablePercentage, Percentage NonEmptyPercentage, Percentage EmptyPercentage) Case3(Percentage nonEmptyPercentage)
        {
            var remaining = Percentage.MaxValue - nonEmptyPercentage;

            var dict = new Dictionary<Func<int, bool>, Func<(Percentage, Percentage, Percentage)>>
            {
                { x => x is 0,     () => (Percentage.MinValue, nonEmptyPercentage, Percentage.MinValue) },
                { x => x is 1,     () => ((Percentage)1, nonEmptyPercentage, Percentage.MinValue) },
                { x => x % 2 is 0, () => ((Percentage)(remaining / 2), nonEmptyPercentage,  (Percentage)(remaining / 2)) },
                { x => x % 2 is 1, () => ((Percentage)Math.Ceiling(remaining / 2d), nonEmptyPercentage, (Percentage)Math.Floor(remaining / 2d)) },
            };
            
            return dict.FirstOrDefault(kvp => kvp.Key(remaining)).Value();
        }
        
        // Case 4: Only EmptyPercentage has been set explicitly.
        // Therefore, distribute the remaining from 100 evenly between NullablePercentage and NonEmptyPercentage
        // with a bias to NullablePercentage if uneven.
        public static (Percentage NullablePercentage, Percentage NonEmptyPercentage, Percentage EmptyPercentage) Case4(Percentage emptyPercentage)
        {
            var remaining = Percentage.MaxValue - emptyPercentage;
            
            var dict = new Dictionary<Func<int, bool>, Func<(Percentage, Percentage, Percentage)>>
            {
                { x => x is 0,     () => (Percentage.MinValue, Percentage.MinValue, emptyPercentage) },
                { x => x is 1,     () => ((Percentage)1, Percentage.MinValue, emptyPercentage) },
                { x => x % 2 is 0, () => ((Percentage)(remaining / 2), (Percentage)(remaining / 2), emptyPercentage) },
                { x => x % 2 is 1, () => ((Percentage)Math.Ceiling(remaining / 2d), (Percentage)Math.Floor(remaining / 2d), emptyPercentage) },
            };
            
            return dict.FirstOrDefault(kvp => kvp.Key(remaining)).Value();
        }
        
        // Case 5: Both NullablePercentage and NonEmptyPercentage have been set explicitly.
        // Therefore, distribute the remaining from 100 with EmptyPercentage.
        public static (Percentage NullablePercentage, Percentage NonEmptyPercentage, Percentage EmptyPercentage) Case5(Percentage nullablePercentage, Percentage nonEmptyPercentage)
        {
            var emptyPercentage = (Percentage)(Percentage.MaxValue - (Percentage)(nullablePercentage + nonEmptyPercentage));
            return (nullablePercentage, nonEmptyPercentage, emptyPercentage);
        }
        
        // Case 6: Both NullablePercentage and EmptyPercentage have been set explicitly.
        // Therefore, distribute the remaining from 100 with NonEmptyPercentage.
        public static (Percentage NullablePercentage, Percentage NonEmptyPercentage, Percentage EmptyPercentage) Case6(Percentage nullablePercentage, Percentage emptyPercentage)
        {
            var nonEmptyPercentage = (Percentage)(Percentage.MaxValue - (Percentage)(nullablePercentage + emptyPercentage));
            return (nullablePercentage, nonEmptyPercentage, emptyPercentage);
        }
                
        // Case 7: Both NonEmptyPercentage and EmptyPercentage have been set explicitly.
        // Therefore, distribute the remaining from 100 with NullablePercentage.
        public static (Percentage NullablePercentage, Percentage NonEmptyPercentage, Percentage EmptyPercentage) Case7(Percentage nonEmptyPercentage, Percentage emptyPercentage)
        {
            var nullablePercentage = (Percentage)(Percentage.MaxValue - (Percentage)(nonEmptyPercentage + emptyPercentage));
            return (nullablePercentage, nonEmptyPercentage, emptyPercentage);
        }
        
        // Case 8: All three, NullablePercentage, NonEmptyPercentage and EmptyPercentage have been set explicitly.
        // Therefore, should be 0 remaining percentage.
        public static (Percentage NullablePercentage, Percentage NonEmptyPercentage, Percentage EmptyPercentage) Case8(Percentage nullablePercentage, Percentage nonEmptyPercentage, Percentage emptyPercentage)
        {
            _ = (Percentage)(Percentage.MaxValue - (Percentage)(nullablePercentage + nonEmptyPercentage + emptyPercentage));
            return (nullablePercentage, nonEmptyPercentage, emptyPercentage);
        }
    }

}