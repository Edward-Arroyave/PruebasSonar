using Xunit;

namespace PruebasSonar.Tests;

public class GreetingServiceTests
{
    [Fact]
    public void GetGreetingMessage_ShouldReturnExpectedMessage()
    {
        // Arrange
        var service = new GreetingService();
        var expectedMessage = "Hola desde PruebasSonar API";

        // Act
        var result = service.GetGreetingMessage();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedMessage, result);
    }

    [Fact]
    public void GetGreetingMessage_ShouldNotReturnEmptyString()
    {
        // Arrange
        var service = new GreetingService();

        // Act
        var result = service.GetGreetingMessage();

        // Assert
        Assert.False(string.IsNullOrEmpty(result));
    }

    [Fact]
    public void GetGreetingMessage_ShouldReturnConsistentValue()
    {
        // Arrange
        var service = new GreetingService();

        // Act
        var result1 = service.GetGreetingMessage();
        var result2 = service.GetGreetingMessage();

        // Assert
        Assert.Equal(result1, result2);
    }

    [Fact]
    public void GetGreetingMessage_ShouldContainExpectedKeyword()
    {
        // Arrange
        var service = new GreetingService();
        var keyword = "PruebasSonar";

        // Act
        var result = service.GetGreetingMessage();

        // Assert
        Assert.Contains(keyword, result);
    }
}
