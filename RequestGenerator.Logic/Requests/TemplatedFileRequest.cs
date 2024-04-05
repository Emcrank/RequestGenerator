using RequestGenerator.Logic.Template;

namespace RequestGenerator.Logic.Requests;

public class TemplatedFileRequest : FileRequest
{
    private string? templateFilePath;

    private RequestTemplate? template;

    public override string Name => "Templated File Request";

    public override string Description => "Generates a file using a template.";

    public string? TemplateFilePath
    {
        get => templateFilePath;
        set => SetField(ref templateFilePath, value);
    }

    public override string Generate(string destination, int index)
    {
        var substitutions = GetRequestSubstitutions(index);

        string outputFileName = GetOutputFileName(substitutions);
        string content = GetContent(substitutions);

        string outputFilePath = Path.Combine(destination, outputFileName);

        File.WriteAllText(outputFilePath, content);

        return outputFileName;
    }

    public override void PreGeneration()
    {
        LoadTemplate();
        base.PreGeneration();
    }

    private string GetContent(Dictionary<string, string> substitutions)
    {
        if (template == null)
            throw new InvalidOperationException("Cannot get content, no template is loaded.");

        return ReplacementVariable.ReplaceAll(template.Content, match => MatchReplacer(match, substitutions));
    }

    private void LoadTemplate()
    {
        if (string.IsNullOrWhiteSpace(templateFilePath))
            throw new InvalidOperationException("Cannot load template. No template file path specified.");

        template = RequestTemplate.LoadFrom(templateFilePath);
    }
}