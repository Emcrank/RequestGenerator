using RequestGenerator.Logic.Requests;

namespace RequestGenerator.Logic.GenerationStrategies;

internal interface IGenerationStrategy
{
    Task ExecuteStrategyAsync(IList<Request> requests, GenerationStrategyOptions options, CancellationToken cancellationToken = default);
}