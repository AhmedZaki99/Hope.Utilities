using Microsoft.Extensions.Configuration;

namespace Hope.Configuration.Extensions;

/// <summary>
/// Extension methods for <see cref="IConfiguration"/>.
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Gets a required value from the application configuration.
    /// </summary>
    /// <remarks>
    /// This method throws an <see cref="InvalidOperationException"/> if the configuration value is not found.
    /// </remarks>
    /// <param name="configuration">The built application configuration.</param>
    /// <param name="key">The configuration section key.</param>
    /// <returns>The configuration value.</returns>
    public static string GetRequiredValue(this IConfiguration configuration, string key)
    {
        return configuration[key]
            ?? throw new InvalidOperationException($"The required '{key}' variable is not found in configuration.");
    }

    /// <summary>
    /// Gets a required section from the application configuration and binds it to the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <remarks>
    /// This method throws an <see cref="InvalidOperationException"/> if the configuration section is not found.
    /// </remarks>
    /// <typeparam name="T">The object type to bind to.</typeparam>
    /// <param name="configuration">The built application configuration.</param>
    /// <param name="key">The configuration section key.</param>
    /// <returns>The bound configuration object.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static T GetRequiredObject<T>(this IConfiguration configuration, string key)
    {
        return configuration.GetSection(key).Get<T>()
            ?? throw new InvalidOperationException($"The required '{key}' variable is not found in configuration.");
    }
}
