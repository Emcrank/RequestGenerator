using RequestGenerator.Logic.GenerationStrategies;
using RequestGenerator.Logic.Requests;

namespace RequestGenerator.Logic;

public class RequestGenerationOrchestrator
{
    public Task GenerateRequestsAsync(IList<Request> requests, RequestGenerationOrchestratorOptions options, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(requests);
        ArgumentNullException.ThrowIfNull(options);

        return GenerateRequestsInternalAsync(requests, options.Destination, options.RequestsPerMinute, cancellationToken);
    }

    public event EventHandler<string>? LogMessageProduced;

    protected virtual void RaiseLogMessageProduced(string e)
    {
        LogMessageProduced?.Invoke(this, e);
    }

    private Task GenerateRequestsInternalAsync(IList<Request> requests, string destination, int? requestsPerMinute, CancellationToken cancellationToken = default)
    {
        int totalRequestCount = requests.Sum(r => r.Count);
        if (totalRequestCount == 0)
            throw new InvalidOperationException("0 requests to generate. Check Count's");

        var options = new GenerationStrategyOptions
        {
            Destination = destination,
            Delay = GetDelay(requestsPerMinute)
        };

        RaiseLogMessageProduced("----------------------------------------");
        RaiseLogMessageProduced("Starting generation...");
        RaiseLogMessageProduced("----------------------------------------");
        RaiseLogMessageProduced($"{"Total Requests:",-17} {totalRequestCount}");
        RaiseLogMessageProduced($"{"Delay:",-17} {options.Delay:g}");
        RaiseLogMessageProduced($"{"Destination:",-17} {destination}");
        RaiseLogMessageProduced("----------------------------------------");

        var strategy = new ParallelGenerationStrategy(RaiseLogMessageProduced);

        return strategy.ExecuteStrategyAsync(requests, options, cancellationToken);
    }

    private static TimeSpan GetDelay(int? requestsPerMinute) =>
        requestsPerMinute == null
            ? TimeSpan.Zero
            : TimeSpan.FromSeconds(60.0 / requestsPerMinute.Value);
}