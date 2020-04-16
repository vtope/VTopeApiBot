using Newtonsoft.Json;
using VTopeApiBot.Types.Responses;
using Xunit;

namespace VTopeApiBot.Tests.Integration.AvailableMethods
{
    public class DeleteBotRequestTests
    {
        [Theory]
        [InlineData("ok")]
        [InlineData("notfound")]
        [InlineData("invalid")]
        [InlineData("exists")]
        public void DeleteBot(string code)
        {
            // Act
            var json = $@"{{ ""code"": ""{code}"" }}";
            var codeResponse = JsonConvert.DeserializeObject<CodeResponse>(json);
            
            // Assert
            Assert.Equal(code, codeResponse.Code.ToString().ToLower());
        }
    }
}