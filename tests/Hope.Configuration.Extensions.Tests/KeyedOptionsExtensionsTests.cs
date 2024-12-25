using FluentAssertions;
using NSubstitute;

namespace Hope.Configuration.Extensions.Tests;

public class KeyedOptionsExtensionsTests
{
    [Fact]
    public void RequireProperty_ShouldReturnOptions_WhenStringPropertyIsSet()
    {
        // Arrange
        var options = Substitute.For<IKeyedOptions>();
        options.Key.Returns("TestKey");
        var testOptions = new TestOptions { StringProperty = "Value" };

        // Act
        var result = testOptions.RequireProperty(o => o.StringProperty);

        // Assert
        result.Should().Be(testOptions);
    }

    [Fact]
    public void RequireProperty_ShouldThrowInvalidOperationException_WhenStringPropertyIsNotSet()
    {
        // Arrange
        var options = Substitute.For<IKeyedOptions>();
        options.Key.Returns("TestKey");
        var testOptions = new TestOptions { StringProperty = null };

        // Act
        Action act = () => testOptions.RequireProperty(o => o.StringProperty);

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("TestKey configuration property 'StringProperty' is required.");
    }

    [Fact]
    public void RequireProperty_ShouldReturnOptions_WhenStructPropertyIsSet()
    {
        // Arrange
        var options = Substitute.For<IKeyedOptions>();
        options.Key.Returns("TestKey");
        var testOptions = new TestOptions { StructProperty = 1 };

        // Act
        var result = testOptions.RequireProperty(o => o.StructProperty);

        // Assert
        result.Should().Be(testOptions);
    }

    [Fact]
    public void RequireProperty_ShouldThrowInvalidOperationException_WhenStructPropertyIsNotSet()
    {
        // Arrange
        var options = Substitute.For<IKeyedOptions>();
        options.Key.Returns("TestKey");
        var testOptions = new TestOptions { StructProperty = default };

        // Act
        Action act = () => testOptions.RequireProperty(o => o.StructProperty);

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("TestKey configuration property 'StructProperty' is required.");
    }

    private class TestOptions : IKeyedOptions
    {
        public string Key { get; set; } = "TestKey";
        public string? StringProperty { get; set; }
        public int StructProperty { get; set; }
    }
}

