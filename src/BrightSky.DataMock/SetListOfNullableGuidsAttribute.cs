namespace BrightSky.DataMock;

public class SetListOfNullableGuidsAttribute : SetTypeAttribute<List<Guid?>>
{
    private readonly IMockType<List<Guid?>> _mt;

    public SetListOfNullableGuidsAttribute(string fix) 
        => _mt = new MockTypeListOfNullableGuid(Guid.Parse(fix))
            .NonEmptyProbability(Percentage.MaxValue)
            .EmptyProbability(Percentage.MinValue)
            .NullableProbability(Percentage.MinValue);
    
    public SetListOfNullableGuidsAttribute(string fix, int nullablePercentage) 
        => _mt = new MockTypeListOfNullableGuid(Guid.Parse(fix))
            .NonEmptyProbability(Percentage.MinValue)
            .EmptyProbability(Percentage.MinValue)
            .NullableProbability((Percentage)nullablePercentage);
    
    public SetListOfNullableGuidsAttribute(string fix, int fixPercentage, int emptyPercentage) 
        => _mt = new MockTypeListOfNullableGuid(Guid.Parse(fix))
            .NonEmptyProbability((Percentage)fixPercentage)
            .EmptyProbability((Percentage)emptyPercentage)
            .NullableProbability(Percentage.MinValue);
    
    public SetListOfNullableGuidsAttribute(string fix, int fixPercentage, int emptyPercentage, int nullablePercentage) 
        => _mt = new MockTypeListOfNullableGuid(Guid.Parse(fix))
            .NonEmptyProbability((Percentage)fixPercentage)
            .EmptyProbability((Percentage)emptyPercentage)
            .NullableProbability((Percentage)nullablePercentage);
    
    public SetListOfNullableGuidsAttribute(object? only = null) 
        => _mt = new MockTypeListOfNullableGuid().NullableProbability(Percentage.MaxValue);
    
    public SetListOfNullableGuidsAttribute(int nonEmptyPercentage, int emptyPercentage, int nullablePercentage) 
        => _mt = new MockTypeListOfNullableGuid()
            .NonEmptyProbability((Percentage)nonEmptyPercentage)
            .EmptyProbability((Percentage)emptyPercentage)
            .NullableProbability((Percentage)nullablePercentage);    
   
    public override IMockType<List<Guid?>> GetMockType() => _mt;
}