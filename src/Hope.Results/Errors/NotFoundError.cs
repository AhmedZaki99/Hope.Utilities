using FluentResults;

namespace Hope.Results;

/// <summary>
/// Represents an error indicating that a requested resource was not found.
/// </summary>
/// <param name="message">The error message describing the not found error.</param>
public class NotFoundError(string message) : Error(message), INamedError
{
    /// <inheritdoc/>
    public string Name { get; } = "NotFound";
}
