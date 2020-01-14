using Newtonsoft.Json;
using VTopeApiBot.Requests.Avaible_Methods;
using VTopeApiBot.Tests.Infrastructure;
using VTopeApiBot.Types.Enums;
using VTopeApiBot.Types.Params;
using Xunit;
using static Xunit.Assert;

namespace VTopeApiBot.Tests.Avaible_Methods
{
    public class RequestParametersTests : UnitTestBase
    {
        protected override string Folder => "RequestParameters";
        
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
        
        [Fact]
        public void ChangeEarnStateRequest()
        {
            // Arrange
            const string methodName = "earnstate";
            const long id = 1;
            const bool state = true;
            
            // Act
            var request = new ChangeEarnStateRequest(id, state);
            
            // Assert
            Equal(methodName, request.MethodName);
            Equal(id, request.Id);
            Equal(state, request.State);
        }

        [Fact]
        public void AddAccountRequest_Without_Extended_Parameters()
        {
            // Arrange
            const string methodName = "bot/action";
            var json = ReadJsonFile(nameof(AddAccountRequest_Without_Extended_Parameters));
            
            // Act
            var args = JsonConvert.DeserializeObject<ActionParams>(json);
            var request = new AddAccountRequest(args);

            // Assert
            Equal(methodName, request.MethodName);
            Equal(AccountAction.Add, request.Action);
            Equal(1234567, request.Id);
            Equal(Service.Instagram, request.Service);
            Equal("login", request.Login);
            Equal("password", request.Password);
            Null(request.Mail);
            Null(request.Strategy);
            Null(request.ProxyMode);
            Null(request.Proxy);
        }
    }
}