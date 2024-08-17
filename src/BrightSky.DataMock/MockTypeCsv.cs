namespace BrightSky.DataMock;

public class MockTypeCsv : 
    IMockType<string>, 
    IMockTypeColumn<string, MockTypeCsv>,
    IMockTypeWithSeparator<string, MockTypeCsv>,
    IMockTypeWithNewLine<string, MockTypeCsv>,
    IMockTypeIncludeExcludeColumnsRow<string, MockTypeCsv>
{
    internal List<MockParamValue> ParamValues { get; } = [];

    public string Get()
    {
        if (ParamValues.Count is 0) return string.Empty;
        var columnsRow = IncludingColumnsRow ? ParamValues.Select(pv => pv.Name).GenerateColumnsRow(Separator, NewLine) : string.Empty;
        var formattedStringDateRow = Dm.FormattedStrings(ParamValues.GenerateDataRowTemplate(Separator, NewLine)).AddParamValueRange(ParamValues);
        
        return $"{columnsRow}{formattedStringDateRow.Get()}";
    }
 
    public List<string> ColumnNames => ParamValues.Select(pv => pv.Name).ToList();

    public MockTypeCsv Column<TColumn>(string columnName, Func<IMockType<TColumn>> typeFactory)
    {
        if (string.IsNullOrWhiteSpace(columnName))
            throw new ArgumentException($"{nameof(columnName)} is required", nameof(columnName));
        ArgumentNullException.ThrowIfNull(typeFactory);
        
        ParamValues.Add(new MockParamValue(columnName, typeFactory));
        return this;
    }

    public string Separator { get; private set; } = ",";

    public MockTypeCsv WithSeparator(string separator)
    {
        Separator = string.IsNullOrEmpty(separator) ? string.Empty : separator;
        return this;
    }

    public bool IncludingColumnsRow { get; private set; }

    public MockTypeCsv IncludeColumnsRow()
    {
        IncludingColumnsRow = true;
        return this;
    }

    public MockTypeCsv ExcludeColumnsRow()
    {
        IncludingColumnsRow = false;
        return this;
    }

    public string NewLine { get; private set; } = Environment.NewLine;

    public MockTypeCsv WithNewLine(string newLine)
    {
        NewLine = !string.IsNullOrEmpty(newLine) ? newLine : throw new ArgumentNullException(nameof(newLine));
        return this;
    }
}