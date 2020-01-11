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
            // Arrange
            const string methodName = "list";
            
            // Act
            var request = new GetBotsRequest();
            
            // Assert
            Equal(methodName, request.MethodName);
        }

        [Fact]
        public void GetBotByIdRequest()
        {
            // Arrange
            const string methodName = "bot";
            const long id = 1;
            
            // Act
            var request = new GetBotByIdRequest(id);
            
            // Assert
            Equal(methodName, request.MethodName);
            Equal(id, request.Id);
        }

        [Fact]
        public void DeleteBotRequest()
        {
            // Arrange
            const string methodName = "deletebot";
            const long id = 1;
            
            // Act
            var request = new DeleteBotRequest(id);
            
            // Assert
            Equal(methodName, request.MethodName);
            Equal(id, request.Id);
        }

        [Fact]
        public void RenameBotRequest()
        {
            // Arrange
            const string methodName = "renamebot";
            const long id = 1;
            const string name = "name";
            
            // Act
            var request = new RenameBotRequest(id, name);
            
            // Assert
            Equal(methodName, request.MethodName);
            Equal(id, request.Id);
            Equal(name, request.Name);
        }
    }
}