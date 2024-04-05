namespace RequestGenerator.Logic.Input.FileSystem;

internal class CsvLine : DelimitedLine
{
    internal CsvLine(string line) : base(line)
    {
        ArgumentNullException.ThrowIfNull(line);
    }

    protected override string Delimiter => ",";
}