using System;
using System.IO;
using System.Threading.Tasks;
using VTopeApiBot.Credentials;
using VTopeApiBot.Requests;
using VTopeApiBot.Tests.Integration.Fixtures;
using Xunit;

namespace VTopeApiBot.Tests.Integration
{
    public class VTopeBotTests : IClassFixture<HttpClientFixture>
    {
        private readonly HttpClientFixture _httpClient;
        private IVTopeBot Bot => _httpClient.Bot;

        public VTopeBotTests(HttpClientFixture httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(paramName: nameof(httpClient));
        }

        [Fact]
        public async Task MakeRequest_EmptyRequest_Should_Authorized()
        {
            // Arrange
            const string user = "user";
            const string key = "key";
        
            await ReadJsonAsync(path: nameof(MakeRequest_EmptyRequest_Should_Authorized));
        
            // Act
            var response = await Bot.MakeRequestAsync<BotCredentials>(methodName: "methodName", args: VTopeParams.Empty);
        
            // Assert
            Assert.Equal(expected: user, actual: response.User);
            Assert.Equal(expected: key, actual: response.Key);
        }
        
        private Task ReadJsonAsync(string path)
        {
            return _httpClient.ReadJsonAsync(path: Path.Combine(path1: "VTopeBot", path2: path));
        }
    }
}