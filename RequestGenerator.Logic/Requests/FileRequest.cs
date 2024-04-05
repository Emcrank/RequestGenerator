using RequestGenerator.Logic.Template;

namespace RequestGenerator.Logic.Requests;

public abstract class FileRequest : Request
{
    private string? fileNameTemplate;

    public string? FileNameTemplate
    {
        get => fileNameTemplate;
        set => SetField(ref fileNameTemplate, value);
    }

    protected string GetOutputFileName(Dictionary<string, string> substitutions)
    {
        if (string.IsNullOrWhiteSpace(fileNameTemplate))
            return Path.GetRandomFileName();

        return FileNameHasVariables()
            ? ReplacementVariable.ReplaceAll(fileNameTemplate, match => MatchReplacer(match, substitutions))
            : Path.GetRandomFileName();
    }

    private bool FileNameHasVariables() => ReplacementVariable.Count(fileNameTemplate) > 0;
}