using FluentResults;

namespace Hope.Results;

/// <summary>
/// Represents an error indicating that access to a resource was unauthorized.
/// </summary>
public class UnauthorizedAccessError(string message) : Error(message), INamedError
{
    /// <inheritdoc/>
    public string Name { get; } = "UnauthorizedAccess";
}

