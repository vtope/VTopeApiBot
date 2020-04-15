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
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        [Fact]
        public async Task MakeRequest_EmptyRequest_Should_Authorized()
        {
            // Arrange
            const string user = "user";
            const string key = "key";

            await ReadJsonAsync(nameof(MakeRequest_EmptyRequest_Should_Authorized));

            // Act
            var response = await Bot.MakeRequestAsync<BotCredentials>("methodName", VTopeParams.Empty);

            // Assert
            Assert.Equal(user, response.User);
            Assert.Equal(key, response.Key);
        }
        
        private Task ReadJsonAsync(string path)
        {
            return _httpClient.ReadJsonAsync(Path.Combine("VTopeBot", path));
        }
    }
}