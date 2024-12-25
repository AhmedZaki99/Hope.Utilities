namespace Hope.Results;

/// <summary>
/// Represents an error indicating that the request was unauthorized.
/// </summary>
public class UnauthorizedRequestError : ApiRequestError, INamedError
{
    /// <inheritdoc/>
    public new string Name { get; } = "UnauthorizedRequest";

    /// <summary>
    /// Initializes a new instance of the <see cref="UnauthorizedRequestError"/> class.
    /// </summary>
    /// <param name="message">The error message that describes the unauthorized request.</param>
    /// <param name="requestException">The exception that occurred when making the request.</param>
    public UnauthorizedRequestError(string message, HttpRequestException? requestException = null)
        : base(message, requestException)
    {
        
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnauthorizedRequestError"/> class.
    /// </summary>
    /// <param name="requestException">The exception that occurred when making the request.</param
    public UnauthorizedRequestError(HttpRequestException? requestException)
        : base(requestException)
    {
    }
}
