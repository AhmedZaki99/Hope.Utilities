using FluentResults;

namespace Hope.Results;

/// <summary>
/// Represents an error that occurs when there is a conflict.
/// </summary>
/// <param name="message">The error message.</param>
public class ConflictError(string message) : Error(message), INamedError
{
    /// <inheritdoc/>
    public string Name { get; } = "Conflict";
}
