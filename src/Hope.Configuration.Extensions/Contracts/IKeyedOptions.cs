namespace Hope.Configuration;

/// <summary>
/// Represents an options model with a configuration section key.
/// </summary>
public interface IKeyedOptions
{
    /// <summary>
    /// Gets the configuration section key.
    /// </summary>
    string Key { get; }
}