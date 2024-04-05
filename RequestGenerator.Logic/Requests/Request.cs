using System.Text.RegularExpressions;
using RequestGenerator.Logic.Input;
using RequestGenerator.Logic.Input.FileSystem;
using RequestGenerator.Logic.Template;

namespace RequestGenerator.Logic.Requests;

public abstract class Request : ObservableObject
{
    private int count;
    private string? inputFilePath;
    private bool useInputFileAsCount;

    public abstract string Name { get; }

    public abstract string Description { get; }

    public int Count
    {
        get => count;
        set => SetField(ref count, value);
    }

    public string? InputFilePath
    {
        get => inputFilePath;
        set => SetField(ref inputFilePath, value);
    }

    public bool UseInputFileAsCount
    {
        get => useInputFileAsCount;
        set => SetField(ref useInputFileAsCount, value);
    }

    protected IInputData? InputData { get; private set; }

    public abstract string Generate(string destination, int index);

    public void LoadInputDataIfRequired()
    {
        if (string.IsNullOrWhiteSpace(inputFilePath))
            return;

        InputData = CsvInputFile.LoadFrom(inputFilePath);
    }

    public virtual void PreGeneration()
    {
        LoadInputDataIfRequired();

        if (UseInputFileAsCount)
            Count = InputData?.DataCount ?? throw new InvalidOperationException("Input data not loaded.");
    }

    protected Dictionary<string, string> GetRequestSubstitutions(int index)
    {
        if (InputData == null)
            return new Dictionary<string, string>();

        int chosenIndex = UseInputFileAsCount
            ? index
            : Random.Shared.Next(0, InputData.DataByHeader.Values.First().MaxIndex);

        var substitutions = new Dictionary<string, string>();

        foreach (string header in InputData.DataByHeader.Keys)
        {
            if (chosenIndex > InputData.DataByHeader[header].MaxIndex)
                throw new InvalidOperationException(
                    $"Cannot select index '{chosenIndex}' for data column '{header}'. Ensure all columns in the input file have same amount of data lines.");

            substitutions.Add(header, InputData.DataByHeader[header][chosenIndex]);
        }

        return substitutions;
    }

    protected string MatchReplacer(Match match, Dictionary<string, string> substitutions)
    {
        var variable = new ReplacementVariable(match);

        if (!substitutions.TryGetValue(variable.Name, out string? value))
            throw new InvalidOperationException(
                $"Substitution variables did not contain a variable named '{variable.Name}' but it was found in the text given.");

        return value;
    }
}