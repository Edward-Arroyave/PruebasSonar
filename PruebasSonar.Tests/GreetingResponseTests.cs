using Xunit;

namespace PruebasSonar.Tests;

public class GreetingResponseTests
{
    [Fact]
    public void GreetingResponse_ShouldHaveMessageProperty()
    {
        // Arrange & Act
        var response = new GreetingResponse();

        // Assert
        Assert.NotNull(response);
        Assert.True(typeof(GreetingResponse).GetProperty("Message") != null);
    }

    [Fact]
    public void GreetingResponse_ShouldAllowSettingMessage()
    {
        // Arrange
        var response = new GreetingResponse();
        var testMessage = "Test Message";

        // Act
        response.Message = testMessage;

        // Assert
        Assert.Equal(testMessage, response.Message);
    }

    [Fact]
    public void GreetingResponse_MessagePropertyShouldInitializeAsEmptyString()
    {
        // Arrange & Act
        var response = new GreetingResponse();

        // Assert
        Assert.Equal(string.Empty, response.Message);
    }

    [Fact]
    public void GreetingResponse_ShouldBeSerializable()
    {
        // Arrange
        var response = new GreetingResponse { Message = "Test" };

        // Act
        var json = System.Text.Json.JsonSerializer.Serialize(response);

        // Assert
        Assert.Contains("Message", json);
        Assert.Contains("Test", json);
    }
}
