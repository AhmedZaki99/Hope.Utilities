using FluentResults;

namespace Hope.Results;

/// <summary>
/// Represents a validation error with an optional property name and message.
/// </summary>
public class ValidationError : Error, INamedError
{
    /// <inheritdoc/>
    public string Name { get; } = "ValidationError";

    /// <summary>
    /// Gets the name of the property that caused the validation error.
    /// </summary>
    public string? PropertyName { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationError"/> class with an optional message and property name.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="propertyName">The name of the property that caused the validation error.</param>
    public ValidationError(string? message = null, string? propertyName = null)
    {
        PropertyName = propertyName;
        Message = message;

        Message ??= propertyName is null
            ? "Validation failed"
            : $"Validation failed for {propertyName}";
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return new ReasonStringBuilder()
            .WithReasonType(GetType())
            .WithInfo(nameof(Message), Message)
            .WithInfo(nameof(PropertyName), PropertyName)
            .WithInfo(nameof(Metadata), string.Join("; ", Metadata))
            .WithInfo(nameof(Reasons), string.Join("; ", Reasons))
            .Build();
    }
}
