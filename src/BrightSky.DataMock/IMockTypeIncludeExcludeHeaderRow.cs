namespace BrightSky.DataMock;

public interface IMockTypeIncludeExcludeColumnsRow<T, out TMockType> where TMockType : IMockType<T>
{
    bool IncludingColumnsRow { get; }
    TMockType IncludeColumnsRow();
    TMockType ExcludeColumnsRow();
}