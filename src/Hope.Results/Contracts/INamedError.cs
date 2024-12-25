using FluentResults;

namespace Hope.Results;

/// <summary>
/// Represents an error with a human-readable name.
/// </summary>
public interface INamedError : IError
{
    /// <summary>
    /// Gets the human-readable name of the error.
    /// </summary>
    string Name { get; }
}
