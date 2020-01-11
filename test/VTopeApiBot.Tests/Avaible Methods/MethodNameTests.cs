using VTopeApiBot.Requests.Avaible_Methods;
using Xunit;
using static Xunit.Assert;

namespace VTopeApiBot.Tests.Avaible_Methods
{
    public class MethodNameTests
    {
        [Fact]
        public void Should_List_In_MethodName()
        {
            // Arrange
            var getBotsRequest = new GetBotsRequest();
            
            // Assert
            Equal("list", getBotsRequest.MethodName);
        }

        [Fact]
        public void Should_Bot_In_MethodName()
        {
            // Arrange
            const long id = 1;
            var getBotByIdRequest = new GetBotByIdRequest(id);
            
            // Assert
            Equal("bot", getBotByIdRequest.MethodName);
        }
    }
}