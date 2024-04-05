namespace RequestGenerator.Logic.Input.FileSystem;

internal abstract class DelimitedLine
{
    private string[]? data;

    protected DelimitedLine(string line)
    {
        ArgumentNullException.ThrowIfNull(line);

        RawLineData = line;
    }

    protected abstract string Delimiter { get; }

    internal virtual string[] Data => data ??= RawLineData.Split(Delimiter);

    internal string RawLineData { get; }

    internal int Columns => Data.Length;
}