using FluentResults;

namespace Hope.Results;

/// <summary>
/// Represents an internal error with an optional exception.
/// </summary>
/// <param name="message">The error message.</param>
/// <param name="exception">The optional exception associated with the error.</param>
public class InternalError(string message, Exception? exception = null) : Error(message), INamedError
{
    /// <inheritdoc/>
    public string Name { get; } = "InternalError";

    /// <summary>
    /// Gets or sets the exception associated with the error.
    /// </summary>
    public Exception? Exception { get; set; } = exception;

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalError"/> class with the specified exception.
    /// </summary>
    /// <param name="exception">The exception associated with the error.</param>
    public InternalError(Exception exception) : this(exception.Message, exception)
    {
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return new ReasonStringBuilder()
            .WithReasonType(GetType())
            .WithInfo(nameof(Message), Message)
            .WithInfo(nameof(Exception), Exception?.ToString())
            .WithInfo(nameof(Metadata), string.Join("; ", Metadata))
            .WithInfo(nameof(Reasons), string.Join("; ", Reasons))
            .Build();
    }
}
