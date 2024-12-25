using FluentResults;

namespace Hope.Results;

/// <summary>
/// Represents an error indicating that a quota has been reached.
/// </summary>
/// <param name="message"></param>
public class QuotaReachedError(string message) : Error(message), INamedError
{
    /// <inheritdoc/>
    public string Name { get; } = "QuotaReached";
}
