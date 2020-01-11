using VTopeApiBot.Requests.Avaible_Methods;
using Xunit;
using static Xunit.Assert;

namespace VTopeApiBot.Tests.Avaible_Methods
{
    public class RequestParametersTests
    {
        [Fact]
        public void GetBotsRequest()
        {
            // Act
            var getBotsRequest = new GetBotsRequest();
            
            // Assert
            Equal("list", getBotsRequest.MethodName);
        }

        [Fact]
        public void GetBotByIdRequest()
        {
            // Arrange
            const long id = 1;
            
            // Act
            var getBotByIdRequest = new GetBotByIdRequest(id);
            
            // Assert
            Equal("bot", getBotByIdRequest.MethodName);
            Equal(1, getBotByIdRequest.Id);
        }

        [Fact]
        public void DeleteBotRequest()
        {
            // Arrange
            const long id = 1;
            
            // Act
            var deleteBotRequest = new DeleteBotRequest(id);
            
            // Assert
            Equal("deletebot", deleteBotRequest.MethodName);
            Equal(1, deleteBotRequest.Id);
        }
    }
}