namespace BrightSky.DataMock;

public class SetNullableGuidsAttribute : SetTypeAttribute<Guid?>
{
    private readonly IMockType<Guid?>  _mt;

    public SetNullableGuidsAttribute(string fix) 
        => _mt = new MockTypeNullableGuidFixed(Guid.Parse(fix))
            .NonEmptyProbability(Percentage.MaxValue)
            .EmptyProbability(Percentage.MinValue)
            .NullableProbability(Percentage.MinValue);
    
    public SetNullableGuidsAttribute(string fix, int nullablePercentage) 
        => _mt = new MockTypeNullableGuidFixed(Guid.Parse(fix))
            .NonEmptyProbability(Percentage.MinValue)
            .EmptyProbability(Percentage.MinValue)
            .NullableProbability((Percentage)nullablePercentage);
    
    public SetNullableGuidsAttribute(string fix, int fixPercentage, int emptyPercentage) 
        => _mt = new MockTypeNullableGuidFixed(Guid.Parse(fix))
            .NonEmptyProbability((Percentage)fixPercentage)
            .EmptyProbability((Percentage)emptyPercentage)
            .NullableProbability(Percentage.MinValue);
    
    public SetNullableGuidsAttribute(string fix, int fixPercentage, int emptyPercentage, int nullablePercentage) 
        => _mt = new MockTypeNullableGuidFixed(Guid.Parse(fix))
            .NonEmptyProbability((Percentage)fixPercentage)
            .EmptyProbability((Percentage)emptyPercentage)
            .NullableProbability((Percentage)nullablePercentage);
    
    public SetNullableGuidsAttribute(object? only = null) 
        => _mt = new MockTypeNullableGuid().NullableProbability(Percentage.MaxValue);
    
    public SetNullableGuidsAttribute(int nonEmptyPercentage, int emptyPercentage, int nullablePercentage) 
        => _mt = new MockTypeNullableGuid()
            .NonEmptyProbability((Percentage)nonEmptyPercentage)
            .EmptyProbability((Percentage)emptyPercentage)
            .NullableProbability((Percentage)nullablePercentage);
    
    public override IMockType<Guid?> GetMockType() => _mt;
}