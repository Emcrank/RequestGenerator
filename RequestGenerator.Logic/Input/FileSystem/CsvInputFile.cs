using RequestGenerator.Logic.Data;

namespace RequestGenerator.Logic.Input.FileSystem;

internal class CsvInputFile : IInputData
{
    private readonly string filePath;
    private readonly Action<string>? logger;

    private CsvInputFile(string filePath, Action<string>? logger = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

        this.filePath = filePath;
        this.logger = logger;
    }

    public IDictionary<string, DataColumn> DataByHeader { get; } = new Dictionary<string, DataColumn>();

    public int DataCount { get; private set; }

    public int HeaderCount { get; private set; }

    internal static CsvInputFile LoadFrom(string filePath, Action<string>? logger = null)
    {
        var inputFile = new CsvInputFile(filePath, logger);
        inputFile.Load();
        return inputFile;
    }

    private void Load()
    {
        string[] lines = File.ReadAllLines(filePath);

        switch (lines.Length)
        {
            case 0: throw new InvalidOperationException("Unable to read input file with no content.");
            case 1: throw new InvalidOperationException("Unable to read input file with no data.");
            default:
                HeaderCount = ParseHeaders(lines);
                DataCount = ParseData(lines);
                break;
        }
    }

    private int ParseData(IEnumerable<string> lines)
    {
        var dataLines = lines
            .Skip(1)
            .Select(x => new CsvLine(x))
            .ToList();

        var headerKeys = DataByHeader.Keys.ToList();

        foreach (var dataLine in dataLines)
        {
            for (int i = 0; i < dataLine.Columns; i++)
            {
                if (dataLine.Columns > DataByHeader.Keys.Count)
                    throw new InvalidOperationException(
                        $"Input file is incorrect, line '{dataLine.RawLineData}' has {dataLine.Columns} data columns but there is only {DataByHeader.Count} headers.");

                string headerName = headerKeys[i];

                DataByHeader[headerName].Add(dataLine.Data[i]);
            }
        }

        logger?.Invoke($"Total of {dataLines.Count} data lines parsed successfully.");

        foreach (string headerKey in headerKeys)
            logger?.Invoke($"Header '{headerKey}' contains {DataByHeader[headerKey].Count} items.");

        return dataLines.Count;
    }

    private int ParseHeaders(IEnumerable<string> lines)
    {
        string firstLine = lines.First();
        var headerLine = new CsvLine(firstLine);

        if (headerLine.Columns == 0)
            throw new InvalidOperationException("First line of input file must contain the headers and these must match the variable names in the template.");

        foreach (string token in headerLine.Data)
        {
            DataByHeader.Add(token, new DataColumn(token));
            logger?.Invoke($"Parsed header '{token}'");
        }

        logger?.Invoke($"Total of {DataByHeader.Count} headers parsed successfully.");

        return DataByHeader.Count;
    }
}