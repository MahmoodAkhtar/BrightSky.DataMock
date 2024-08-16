namespace BrightSky.DataMock;

public interface IMockTypeColumn<in T, out TMockType> where TMockType : IMockType<T>
{
    List<string> ColumnNames { get; }
    TMockType Column<TColumn>(string columnName, Func<IMockType<TColumn>> typeFactory);
}