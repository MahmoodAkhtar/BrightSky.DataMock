namespace BrightSky.DataMock;

public class MockTypeCsv : 
    IMockType<string>, 
    IMockTypeColumn<string, MockTypeCsv>,
    IMockTypeWithSeparator<string, MockTypeCsv>,
    IMockTypeWithNewLine<string, MockTypeCsv>,
    IMockTypeIncludeExcludeColumnsRow<string, MockTypeCsv>
{
    private readonly List<ParamValue> _paramValues = [];
    
    public string Get()
    {
        var columnsRow = IncludingColumnsRow ? _paramValues.GenerateColumnsRow(Separator, NewLine) : string.Empty;
        var formattedStringDateRow = Dm.FormattedStrings(_paramValues.GenerateDataRowTemplate(Separator, NewLine)).AddParamValueRange(_paramValues);
        
        return $"{columnsRow}{formattedStringDateRow.Get()}";
    }

    public List<string> ColumnNames => _paramValues.Select(pv => pv.Name).ToList();

    public MockTypeCsv Column<TColumn>(string columnName, Func<IMockType<TColumn>> func)
    {
        _paramValues.Add(new ParamValue(columnName, func));
        return this;
    }

    public string Separator { get; private set; } = ",";

    public MockTypeCsv WithSeparator(string separator)
    {
        Separator = !string.IsNullOrEmpty(separator) ? separator : throw new ArgumentNullException(nameof(separator));
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