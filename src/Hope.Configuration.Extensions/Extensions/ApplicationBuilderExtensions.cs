using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hope.Configuration.Extensions;

/// <summary>
/// Extension methods for <see cref="IHostApplicationBuilder"/>.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Configures options from the configuration section to the specified <see cref="IHostApplicationBuilder"/>'s <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="T">The options model type.</typeparam>
    /// <param name="builder">The host application builder.</param>
    /// <param name="optionsKey">The configuration section key.</param>
    /// <returns>The host application builder to allow chaining.</returns>
    public static IHostApplicationBuilder ConfigureOptions<T>(this IHostApplicationBuilder builder, string optionsKey)
        where T : class
    {
        var configSection = builder.Configuration.GetSection(optionsKey);
        builder.Services.Configure<T>(configSection);

        return builder;
    }

    /// <summary>
    /// Configures options from the configuration section to the specified <see cref="IHostApplicationBuilder"/>'s <see cref="IServiceCollection"/>.
    /// </summary>
    /// <remarks>
    /// This method also assigns the bound options model instance to the specified out parameter.
    /// </remarks>
    /// <typeparam name="T">The options model type.</typeparam>
    /// <param name="builder">The host application builder.</param>
    /// <param name="optionsKey">The configuration section key.</param>
    /// <param name="options">The options model instance.</param>
    /// <returns>The host application builder to allow chaining.</returns>
    public static IHostApplicationBuilder ConfigureOptions<T>(this IHostApplicationBuilder builder, string optionsKey, out T options)
        where T : class
    {
        var configSection = builder.Configuration.GetSection(optionsKey);
        options = configSection.Get<T>()
            ?? throw new InvalidOperationException($"{optionsKey} configuration is missing.");

        builder.Services.Configure<T>(configSection);
        return builder;
    }
}
