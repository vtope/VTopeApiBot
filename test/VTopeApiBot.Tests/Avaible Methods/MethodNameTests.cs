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
    }
}