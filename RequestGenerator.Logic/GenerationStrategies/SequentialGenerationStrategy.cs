using RequestGenerator.Logic.Requests;

namespace RequestGenerator.Logic.GenerationStrategies;

internal class SequentialGenerationStrategy : IGenerationStrategy
{
    private readonly Action<string> logCallback;

    internal SequentialGenerationStrategy(Action<string> logCallback)
    {
        ArgumentNullException.ThrowIfNull(logCallback);

        this.logCallback = logCallback;
    }

    public Task ExecuteStrategyAsync(IList<Request> requests, GenerationStrategyOptions options, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException();
}