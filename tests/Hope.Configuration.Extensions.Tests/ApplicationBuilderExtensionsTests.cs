using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Hope.Configuration.Extensions.Tests;

public class ApplicationBuilderExtensionsTests
{
    [Fact]
    public void ConfigureOptions_ShouldConfigureOptions_WhenSectionExists()
    {
        // Arrange
        var key = "ExistingSection";
        var expectedObject = new TestConfig { Property = "Value" };

        var innerSection = Substitute.For<IConfigurationSection>();
        innerSection.Value.Returns(expectedObject.Property);

        var outerSection = Substitute.For<IConfigurationSection>();
        outerSection.GetSection(nameof(expectedObject.Property)).Returns(innerSection);
        outerSection.GetChildren().Returns([innerSection]);

        var configuration = Substitute.For<IConfigurationManager>();
        configuration.GetSection(key).Returns(outerSection);
        configuration.GetChildren().Returns([outerSection]);

        var services = new ServiceCollection();
        var builder = Substitute.For<IHostApplicationBuilder>();
        builder.Configuration.Returns(configuration);
        builder.Services.Returns(services);


        // Act
        builder.ConfigureOptions<TestConfig>(key);


        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var options = serviceProvider.GetService<IOptions<TestConfig>>();

        options.Should().NotBeNull();
        options!.Value.Should().BeEquivalentTo(expectedObject);
    }

    [Fact]
    public void ConfigureOptions_ShouldThrowInvalidOperationException_WhenSectionDoesNotExistAndOutParameterProvided()
    {
        // Arrange
        var key = "NonExistingSection";

        var outerSection = Substitute.For<IConfigurationSection>();
        outerSection.GetSection(Arg.Any<string>()).ReturnsNull();
        outerSection.GetChildren().Returns([]);

        var configuration = Substitute.For<IConfigurationManager>();
        configuration.GetSection(key).Returns(outerSection);
        configuration.GetChildren().Returns([outerSection]);

        var services = new ServiceCollection();
        var builder = Substitute.For<IHostApplicationBuilder>();
        builder.Configuration.Returns(configuration);
        builder.Services.Returns(services);


        // Act
        Action act = () => builder.ConfigureOptions<TestConfig>(key, out _);

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage($"{key} configuration is missing.");
    }

    [Fact]
    public void ConfigureOptions_ShouldConfigureOptionsAndAssignOutParameter_WhenSectionExistsAndOutParameterProvided()
    {
        // Arrange
        var key = "ExistingSection";
        var expectedObject = new TestConfig { Property = "Value" };

        var innerSection = Substitute.For<IConfigurationSection>();
        innerSection.Value.Returns(expectedObject.Property);

        var outerSection = Substitute.For<IConfigurationSection>();
        outerSection.GetSection(nameof(expectedObject.Property)).Returns(innerSection);
        outerSection.GetChildren().Returns([innerSection]);

        var configuration = Substitute.For<IConfigurationManager>();
        configuration.GetSection(key).Returns(outerSection);
        configuration.GetChildren().Returns([outerSection]);

        var services = new ServiceCollection();
        var builder = Substitute.For<IHostApplicationBuilder>();
        builder.Configuration.Returns(configuration);
        builder.Services.Returns(services);


        // Act
        builder.ConfigureOptions<TestConfig>(key, out var options);


        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var configuredOptions = serviceProvider.GetService<IOptions<TestConfig>>();

        options.Should().BeEquivalentTo(expectedObject);
        configuredOptions.Should().NotBeNull();
        configuredOptions!.Value.Should().BeEquivalentTo(expectedObject);
    }

    private class TestConfig
    {
        public string? Property { get; set; }
    }
}
