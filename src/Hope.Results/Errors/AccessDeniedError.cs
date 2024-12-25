using FluentResults;

namespace Hope.Results;

/// <summary>
/// Represents an error that occurs when access is denied to a resource.
/// </summary>
/// <param name="message">The error message that describes the access denial.</param>
public class AccessDeniedError(string message) : Error(message), INamedError
{
    /// <inheritdoc/>
    public string Name { get; } = "AccessDenied";
}
