using RequestGenerator.Logic.Requests;

namespace RequestGenerator.Logic.GenerationStrategies;

internal class ParallelGenerationStrategy : IGenerationStrategy
{
    private readonly Action<string> logCallback;

    internal ParallelGenerationStrategy(Action<string> logCallback)
    {
        ArgumentNullException.ThrowIfNull(logCallback);

        this.logCallback = logCallback;
    }

    public Task ExecuteStrategyAsync(IList<Request> requests, GenerationStrategyOptions options, CancellationToken cancellationToken = default)
    {
        var generationTasks = requests.Select(
            (request, requestIndex) => Task.Run(
                async () =>
                {
                    int requestId = requestIndex + 1;
                    int currentRequestNumber = 0;

                    for (int i = 0; i < request.Count; i++)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            logCallback($"RequestId {requestId}| Cancelled");
                            return;
                        }

                        currentRequestNumber = i + 1;

                        string outputFileName = request.Generate(options.Destination, i);
                        logCallback($"RequestId {requestId}| {currentRequestNumber,6}/{request.Count,-6} | Generated {outputFileName}");

                        await Task.Delay(options.Delay, cancellationToken);
                    }

                    logCallback($"RequestId {requestId}| Finished - {currentRequestNumber} requests generated.");
                },
                cancellationToken));

        return Task.WhenAll(generationTasks);
    }
}