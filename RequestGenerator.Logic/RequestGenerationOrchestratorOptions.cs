namespace RequestGenerator.Logic;

public class RequestGenerationOrchestratorOptions
{
    public int? RequestsPerMinute { get; set; } = null;

    public required string Destination { get; init; }
}