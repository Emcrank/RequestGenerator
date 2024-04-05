namespace RequestGenerator.Logic.GenerationStrategies;

internal class GenerationStrategyOptions
{
    internal TimeSpan Delay { get; set; } = TimeSpan.Zero;

    internal required string Destination { get; set; }

}