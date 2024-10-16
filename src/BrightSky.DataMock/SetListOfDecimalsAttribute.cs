namespace BrightSky.DataMock;

public class SetListOfDecimalsAttribute : SetTypeAttribute<List<decimal>>
{
    private readonly IMockType<List<decimal>> _mt;

    public SetListOfDecimalsAttribute(string fix)
        => _mt = new MockTypeListOfDecimal().Min(fix.ParseAsDecimal()).Max(fix.ParseAsDecimal());

    public SetListOfDecimalsAttribute(string min, string max)
        => _mt = new MockTypeListOfDecimal().Range(min.ParseAsDecimal(), max.ParseAsDecimal());

    public override IMockType<List<decimal>> GetMockType() => _mt;
}