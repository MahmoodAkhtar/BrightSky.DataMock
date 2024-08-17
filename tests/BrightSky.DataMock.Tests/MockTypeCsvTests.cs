namespace BrightSky.DataMock.Tests;

public class MockTypeCsvTests
{
    [Fact]
    public void When_Csv_Returns_ImplOf_IMockTypeOfString()
    {
        var actual = Dm.Csv();

        Assert.IsAssignableFrom<IMockType<string>>(actual);
    }
    
    [Fact]
    public void When_Csv_Returns_MockTypeCsv()
    {
        var actual = Dm.Csv();

        Assert.IsType<MockTypeCsv>(actual);
    }
    
    [Fact]
    public void When_Csv_Returns_MockTypeCsv_IncludingColumnsRow_AsFalse()
    {
        var actual = Dm.Csv();

        Assert.False(actual.IncludingColumnsRow);
    }
    
    [Fact]
    public void When_Csv_Returns_MockTypeCsv_Separator_AsCommaString()
    {
        var actual = Dm.Csv();

        Assert.Equal(",", actual.Separator);
    }
        
    [Fact]
    public void When_CsvWithSeparator_Returns_MockTypeCsv_SeparatorSetToCommaString_AsExpected()
    {
        var actual = Dm.Csv().WithSeparator(",");

        Assert.Equal(",", actual.Separator);
    }
    
    [Theory]
    [InlineData((string)null!)]
    [InlineData("")]
    public void When_CsvWithSeparator_WhenNullOrEmpty_Returns_MockTypeCsv_Separator_AsExpected(string separator)
    {
        var actual = Dm.Csv().WithSeparator(separator);

        Assert.Equal(string.Empty, actual.Separator);
    }
    
    [Theory]
    [InlineData(".")]
    [InlineData("'")]
    [InlineData("@")]
    [InlineData("|")]
    [InlineData(" ")]
    [InlineData("/")]
    [InlineData("~")]
    [InlineData("+")]
    [InlineData("-")]
    [InlineData("_")]
    [InlineData("*")]
    [InlineData("&")]
    [InlineData("\",\"")]
    public void When_CsvWithSeparator_Returns_MockTypeCsv_Separator_AsExpected(string separator)
    {
        var actual = Dm.Csv().WithSeparator(separator);

        Assert.Equal(separator, actual.Separator);
    }
    
    [Fact]
    public void When_CsvGet_Returns_String()
    {
        var actual = Dm.Csv().Get();

        Assert.IsType<string>(actual);
    }
        
    [Fact]
    public void When_CsvGet_Returns_EmptyString()
    {
        var actual = Dm.Csv().Get();

        Assert.Empty(actual);
    }
    
    [Theory]
    [InlineData((string)null!)]
    [InlineData("")]
    [InlineData(" ")]
    public void When_CsvColumn_WithNullWhitespaceAsColumnName_Throws_ArgumentException(string coulmnName)
    {
        var action = () => Dm.Csv().Column(coulmnName, Dm.Ints);

        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void When_CsvColumn_WithNullAsTypeFactory_Throws_ArgumentNullException()
    {
        var action = () => Dm.Csv().Column<string>("some_column", null!);

        Assert.Throws<ArgumentNullException>(action);
    }
    
    [Fact]
    public void When_CsvColumn_Returns_MockTypeCsv()
    {
        var actual =  Dm.Csv().Column("some_column", Dm.Ints);

        Assert.IsType<MockTypeCsv>(actual);
    }
    
    [Fact]
    public void When_CsvSingleColumn_Returns_MockTypeCsv_ColumnNames_AsExpected()
    {
        var expected = new[] { "some_column" };
        var actual =  Dm.Csv().Column("some_column", Dm.Ints);

        Assert.Equal(expected, actual.ColumnNames);
    }
    
    [Fact]
    public void When_CsvTwoColumns_Returns_MockTypeCsv_ColumnNames_AsExpected()
    {
        var expected = new[] { "some_column1", "some_column2" };
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.Ints)
            .Column("some_column2", Dm.Ints);

        Assert.Equal(expected, actual.ColumnNames);
    }
        
    [Fact]
    public void When_CsvMultipleColumns_Returns_MockTypeCsv_ColumnNames_AsExpected()
    {
        var expected = new[] { "some_column1", "some_column2", "some_column3" };
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.Ints)
            .Column("some_column2", Dm.Ints)
            .Column("some_column3", Dm.Ints);

        Assert.Equal(expected, actual.ColumnNames);
    }
    
    [Fact]
    public void When_CsvSingleColumnGet_Returns_CsvString()
    {
        var expected = "0"+Environment.NewLine;
        var actual =  Dm.Csv().Column("some_column", Dm.IntSequence).Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvTwoColumnsGet_Returns_CsvString()
    {
        var expected = "0,A" + Environment.NewLine;
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvMultipleColumnsGet_Returns_CsvString()
    {
        var expected = "0,A,B" + Environment.NewLine;
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .Column("some_column3", () => Dm.Strings().From(['B']).WithLength(1))
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvSingleColumnWithSeparatorGet_Returns_CsvString()
    {
        var expected = "0"+Environment.NewLine;
        var actual =  Dm.Csv()
            .Column("some_column", Dm.IntSequence)
            .WithSeparator("|")
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvTwoColumnsWithSeparatorGet_Returns_CsvString()
    {
        var expected = "0|A" + Environment.NewLine;
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .WithSeparator("|")
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvMultipleColumnsWithSeparatorGet_Returns_CsvString()
    {
        var expected = "0|A|B" + Environment.NewLine;
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .Column("some_column3", () => Dm.Strings().From(['B']).WithLength(1))
            .WithSeparator("|")
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvSingleColumnWithNewLineGet_Returns_CsvString()
    {
        var expected = "0" + "\n";
        var actual =  Dm.Csv()
            .Column("some_column", Dm.IntSequence)
            .WithNewLine("\n")
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvTwoColumnsWithNewLineGet_Returns_CsvString()
    {
        var expected = "0,A" + "\n";
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .WithNewLine("\n")
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvMultipleColumnsWithNewLineGet_Returns_CsvString()
    {
        var expected = "0,A,B" + "\n";
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .Column("some_column3", () => Dm.Strings().From(['B']).WithLength(1))
            .WithNewLine("\n")
            .Get();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_CsvSingleColumnWithSeparatorAndWithNewLineGet_Returns_CsvString()
    {
        var expected = "0" + "\n";
        var actual =  Dm.Csv()
            .Column("some_column", Dm.IntSequence)
            .WithSeparator("|")
            .WithNewLine("\n")
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvTwoColumnsWithSeparatorAndWithNewLineGet_Returns_CsvString()
    {
        var expected = "0|A" + "\n";
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .WithSeparator("|")
            .WithNewLine("\n")
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvMultipleColumnsWithSeparatorAndWithNewLineGet_Returns_CsvString()
    {
        var expected = "0|A|B" + "\n";
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .Column("some_column3", () => Dm.Strings().From(['B']).WithLength(1))
            .WithSeparator("|")
            .WithNewLine("\n")
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvSingleColumnWithSeparatorAndWithNewLineAndExcludeColumnsRowGet_Returns_CsvString()
    {
        var expected = "0" + "\n";
        var actual =  Dm.Csv()
            .Column("some_column", Dm.IntSequence)
            .WithSeparator("|")
            .WithNewLine("\n")
            .ExcludeColumnsRow()
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvTwoColumnsWithSeparatorAndWithNewLineAndExcludeColumnsRowGet_Returns_CsvString()
    {
        var expected = "0|A" + "\n";
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .WithSeparator("|")
            .WithNewLine("\n")
            .ExcludeColumnsRow()
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvMultipleColumnsWithSeparatorAndWithNewLineAndExcludeColumnsRowGet_Returns_CsvString()
    {
        var expected = "0|A|B" + "\n";
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .Column("some_column3", () => Dm.Strings().From(['B']).WithLength(1))
            .WithSeparator("|")
            .WithNewLine("\n")
            .ExcludeColumnsRow()
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvSingleColumnWithSeparatorAndWithNewLineAndIncludeColumnsRowGet_Returns_CsvString()
    {
        var expected = "some_column" + "\n" + "0" + "\n";
        var actual =  Dm.Csv()
            .Column("some_column", Dm.IntSequence)
            .WithSeparator("|")
            .WithNewLine("\n")
            .IncludeColumnsRow()
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvTwoColumnsWithSeparatorAndWithNewLineAndIncludeColumnsRowGet_Returns_CsvString()
    {
        var expected = "some_column1|some_column2" + "\n" + "0|A" + "\n";
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .WithSeparator("|")
            .WithNewLine("\n")
            .IncludeColumnsRow()
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvMultipleColumnsWithSeparatorAndWithNewLineAndIncludeColumnsRowGet_Returns_CsvString()
    {
        var expected = "some_column1|some_column2|some_column3" + "\n" + "0|A|B" + "\n";
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .Column("some_column3", () => Dm.Strings().From(['B']).WithLength(1))
            .WithSeparator("|")
            .WithNewLine("\n")
            .IncludeColumnsRow()
            .Get();

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvWithSeparator_Returns_MockTypeCsv()
    {
        var actual = Dm.Csv().WithSeparator("|");

        Assert.IsType<MockTypeCsv>(actual);
    }
    
    [Fact]
    public void When_CsvWithSeparatorGet_Returns_EmptyString()
    {
        var actual = Dm.Csv().WithSeparator("|").Get();

        Assert.Equal(string.Empty, actual);
    }
    
    [Fact]
    public void When_CsvWithNewLine_Returns_MockTypeCsv()
    {
        var actual = Dm.Csv().WithNewLine("\n");

        Assert.IsType<MockTypeCsv>(actual);
    }
    
    [Fact]
    public void When_CsvWithNewLineGet_Returns_EmptyString()
    {
        var actual = Dm.Csv().WithNewLine("\n").Get();

        Assert.Equal(string.Empty, actual);
    }
    
    [Fact]
    public void When_CsvIncludeColumnsRow_Returns_MockTypeCsv()
    {
        var actual = Dm.Csv().IncludeColumnsRow();

        Assert.IsType<MockTypeCsv>(actual);
    }
    
    [Fact]
    public void When_CsvIncludeColumnsRow_Returns_MockTypeCsv_IncludingColumnsRow_AsTrue()
    {
        var actual = Dm.Csv().IncludeColumnsRow();

        Assert.True(actual.IncludingColumnsRow);
    }
    
    [Fact]
    public void When_CsvIncludeColumnsRowGet_Returns_EmptyString()
    {
        var actual = Dm.Csv().IncludeColumnsRow().Get();

        Assert.Equal(string.Empty, actual);
    }
    
    [Fact]
    public void When_CsvExcludeColumnsRow_Returns_MockTypeCsv()
    {
        var actual = Dm.Csv().ExcludeColumnsRow();

        Assert.IsType<MockTypeCsv>(actual);
    }
    
    [Fact]
    public void When_CsvExcludeColumnsRow_Returns_MockTypeCsv_IncludingColumnsRow_AsFalse()
    {
        var actual = Dm.Csv().ExcludeColumnsRow();

        Assert.False(actual.IncludingColumnsRow);
    }
        
    [Fact]
    public void When_CsvExcludeColumnsRowGet_Returns_EmptyString()
    {
        var actual = Dm.Csv().ExcludeColumnsRow().Get();

        Assert.Equal(string.Empty, actual);
    }
    
    [Fact]
    public void When_CsvSingleColumnToList_Returns_ListOfCsvStrings_AsExpected()
    {
        var expected = new []
        {
            "0" + Environment.NewLine, 
            "1" + Environment.NewLine, 
            "2" + Environment.NewLine
        };
        
        var actual =  Dm.Csv()
            .Column("some_column", Dm.IntSequence)
            .ToList(3);

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvTwoColumnsToList_Returns_MockTypeCsv_ListOfCsvStrings_AsExpected()
    {
        var expected = new []
        {
            "0,A" + Environment.NewLine, 
            "1,A" + Environment.NewLine, 
            "2,A" + Environment.NewLine
        };
        
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .ToList(3);

        Assert.Equal(expected, actual);
    }
        
    [Fact]
    public void When_CsvMultipleColumnsToList_Returns_MockTypeCsv_ListOfCsvStrings_AsExpected()
    {
        var expected = new []
        {
            "0,A,B" + Environment.NewLine, 
            "1,A,B" + Environment.NewLine, 
            "2,A,B" + Environment.NewLine
        };

        var actual = Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .Column("some_column3", () => Dm.Strings().From(['B']).WithLength(1))
            .ToList(3);

        Assert.Equal(expected, actual);
    }
        
    [Fact]
    public void When_CsvSingleColumnWithSeparatorToList_Returns_ListOfCsvStrings_AsExpected()
    {
        var expected = new []
        {
            "0" + Environment.NewLine, 
            "1" + Environment.NewLine, 
            "2" + Environment.NewLine
        };
        
        var actual =  Dm.Csv()
            .Column("some_column", Dm.IntSequence)
            .WithSeparator("|")
            .ToList(3);

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void When_CsvTwoColumnsWithSeparatorToList_Returns_MockTypeCsv_ListOfCsvStrings_AsExpected()
    {
        var expected = new []
        {
            "0|A" + Environment.NewLine, 
            "1|A" + Environment.NewLine, 
            "2|A" + Environment.NewLine
        };
        
        var actual =  Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .WithSeparator("|")
            .ToList(3);

        Assert.Equal(expected, actual);
    }
        
    [Fact]
    public void When_CsvMultipleColumnsWithSeparatorToList_Returns_MockTypeCsv_ListOfCsvStrings_AsExpected()
    {
        var expected = new []
        {
            "0|A|B" + Environment.NewLine, 
            "1|A|B" + Environment.NewLine, 
            "2|A|B" + Environment.NewLine
        };

        var actual = Dm.Csv()
            .Column("some_column1", Dm.IntSequence)
            .Column("some_column2", () => Dm.Strings().From(['A']).WithLength(1))
            .Column("some_column3", () => Dm.Strings().From(['B']).WithLength(1))
            .WithSeparator("|")
            .ToList(3);

        Assert.Equal(expected, actual);
    }
}