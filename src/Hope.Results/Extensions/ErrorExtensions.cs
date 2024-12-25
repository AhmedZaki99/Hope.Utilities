using FluentResults;

namespace Hope.Results;

/// <summary>
/// Provides extension methods for <see cref="IError"/> models.
/// </summary>
public static class ErrorExtensions
{
    /// <summary>
    /// Resolves a human-readable name for the <see cref="IError"/> object.
    /// </summary>
    /// <remarks>
    /// This method returns the <see cref="INamedError.Name"/> property if the error implements the <see cref="INamedError"/> interface.
    /// </remarks>
    /// <param name="error">The error object.</param>
    /// <returns>The human-readable name of the error.</returns>
    public static string GetName(this IError error)
    {
        return error switch
        {
            INamedError namedError => namedError.Name,
            _ => error.GetType().Name
        };
    }
}
