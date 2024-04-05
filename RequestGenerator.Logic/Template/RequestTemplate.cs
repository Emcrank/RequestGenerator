namespace RequestGenerator.Logic.Template;

internal class RequestTemplate
{
    private readonly string filePath;

    private RequestTemplate(string filePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

        this.filePath = filePath;
    }

    internal string Content { get; private set; } = null!;

    internal IList<ReplacementVariable> Variables { get; private set; } = null!;

    internal bool HasVariables => Variables.Any();

    internal static RequestTemplate LoadFrom(string filePath)
    {
        var template = new RequestTemplate(filePath);
        template.Load();
        return template;
    }

    private void Load()
    {
        Content = File.ReadAllText(filePath);
        Variables = ParseVariables(Content);
    }

    private static List<ReplacementVariable> ParseVariables(string content) => ReplacementVariable.Select(content).ToList();
}