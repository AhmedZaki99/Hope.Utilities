using FluentResults;

namespace Hope.Results;

/// <summary>
/// Represents an error that occurs during an API request.
/// </summary>
/// <param name="message">The error message.</param>
/// <param name="requestException">The HTTP request exception that caused the error, if any.</param>
public class ApiRequestError(string message, HttpRequestException? requestException = null) : Error(message), INamedError
{
    /// <inheritdoc/>
    public string Name { get; } = "ApiRequestError";

    /// <summary>
    /// Gets or sets the HTTP request exception that caused the error, if any.
    /// </summary>
    public HttpRequestException? RequestException { get; set; } = requestException;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiRequestError"/> class with the specified HTTP request exception.
    /// </summary>
    /// <param name="requestException">The HTTP request exception that caused the error.</param>
    public ApiRequestError(HttpRequestException? requestException)
        : this(requestException?.Message ?? requestException?.StatusCode?.ToString() ?? "Unknown error", requestException)
    {
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return new ReasonStringBuilder()
            .WithReasonType(GetType())
            .WithInfo(nameof(Message), Message)
            .WithInfo(nameof(RequestException), RequestException?.ToString())
            .WithInfo(nameof(Metadata), string.Join("; ", Metadata))
            .WithInfo(nameof(Reasons), string.Join("; ", Reasons))
            .Build();
    }
}
