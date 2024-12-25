namespace Hope.Results;

/// <summary>
/// Represents an error that occurs when a resource usage limit is crossed.
/// </summary>
public class LimitCrossedError : ValidationError
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LimitCrossedError"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="propertyName">The name of the property that caused the error.</param>
    public LimitCrossedError(string? message = null, string? propertyName = null)
    {
        PropertyName = propertyName;
        Message = message;

        Message ??= propertyName is null
            ? "Allowed limit was crossed"
            : $"Allowed Limit was crossed for {propertyName}";
    }
}
