using System.Text.RegularExpressions;

namespace RequestGenerator.Logic.Template;

internal partial class ReplacementVariable
{
    internal const string Pattern = @"#\{([\w\d]+)\}";

    internal const string Syntax = "#{variableName}";

    internal ReplacementVariable(Match match)
    {
        ArgumentNullException.ThrowIfNull(match);

        Name = match.Result("$1");
    }

    internal string Name { get; }

    internal static int Count(string? value) => string.IsNullOrWhiteSpace(value) ? 0 : Regex().Count(value);

    internal static string ReplaceAll(string value, MatchEvaluator matchEvaluator) => Regex().Replace(value, matchEvaluator);

    internal static IEnumerable<ReplacementVariable> Select(string value) => Regex()
        .Matches(value)
        .Select(x => new ReplacementVariable(x));

    [GeneratedRegex(Pattern)]
    private static partial Regex Regex();
}