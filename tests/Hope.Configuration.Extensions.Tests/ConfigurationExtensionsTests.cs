using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Hope.Configuration.Extensions.Tests;

public class ConfigurationExtensionsTests
{
    [Fact]
    public void GetRequiredValue_ShouldReturnValue_WhenKeyExists()
    {
        // Arrange
        var key = "ExistingKey";
        var expectedValue = "ExpectedValue";
        var configuration = Substitute.For<IConfiguration>();
        configuration[key].Returns(expectedValue);

        // Act
        var result = configuration.GetRequiredValue(key);

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact]
    public void GetRequiredValue_ShouldThrowInvalidOperationException_WhenKeyDoesNotExist()
    {
        // Arrange
        var key = "NonExistingKey";
        var configuration = Substitute.For<IConfiguration>();
        configuration[key].ReturnsNull();

        // Act
        Action act = () => configuration.GetRequiredValue(key);

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage($"The required '{key}' variable is not found in configuration.");
    }

    [Fact]
    public void GetRequiredObject_ShouldReturnObject_WhenSectionExists()
    {
        // Arrange
        var key = "ExistingSection";
        var expectedObject = new TestConfig { Property = "Value" };

        var innerSection = Substitute.For<IConfigurationSection>();
        innerSection.Value.Returns(expectedObject.Property);

        var outerSection = Substitute.For<IConfigurationSection>();
        outerSection.GetSection(nameof(expectedObject.Property)).Returns(innerSection);
        outerSection.GetChildren().Returns([innerSection]);

        var configuration = Substitute.For<IConfiguration>();
        configuration.GetSection(key).Returns(outerSection);
        configuration.GetChildren().Returns([outerSection]);


        // Act
        var result = configuration.GetRequiredObject<TestConfig>(key);

        // Assert
        result.Should().BeEquivalentTo(expectedObject);
    }

    [Fact]
    public void GetRequiredObject_ShouldThrowInvalidOperationException_WhenSectionDoesNotExist()
    {
        // Arrange
        var key = "NonExistingSection";
        var configurationSection = Substitute.For<IConfigurationSection>();

        var outerSection = Substitute.For<IConfigurationSection>();
        outerSection.GetSection(Arg.Any<string>()).ReturnsNull();
        outerSection.GetChildren().Returns([]);

        var configuration = Substitute.For<IConfiguration>();
        configuration.GetSection(key).Returns(outerSection);
        configuration.GetChildren().Returns([outerSection]);


        // Act
        Action act = () => configuration.GetRequiredObject<TestConfig>(key);

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage($"The required '{key}' variable is not found in configuration.");
    }

    private class TestConfig
    {
        public string? Property { get; set; }
    }
}