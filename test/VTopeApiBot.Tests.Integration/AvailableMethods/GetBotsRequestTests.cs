using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VTopeApiBot.Tests.Integration.Fixtures;
using VTopeApiBot.Types.Enums;
using Xunit;

namespace VTopeApiBot.Tests.Integration.AvailableMethods
{
    public class GetBotsRequestTests : IClassFixture<HttpClientFixture>
    {
        private readonly HttpClientFixture _httpClient;
        
        public GetBotsRequestTests(HttpClientFixture httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(paramName: nameof(httpClient));
        }
        
        [Fact]
        public async Task GetBots()
        {
            // Arrange
            await ReadJsonAsync(path: nameof(GetBots));
            
            // Act
            var bots = await _httpClient.Bot.GetBotsAsync();

            // Assert
            Assert.NotNull(@object: bots.Earned);
            Assert.NotEmpty(collection: bots.Bots);

            var bot = bots.Bots.First();
            Assert.Equal(expected: Status.Danger, actual: bot.Status);
            Assert.Equal(expected: "botname", actual: bot.Name);
            Assert.Equal(expected: Access.On, actual: bot.Access);
            Assert.Equal(expected: 1234567, actual: bot.Id);
            Assert.Null(@object: bot.AppName);
        }

        private Task ReadJsonAsync(string path)
        {
            return _httpClient.ReadJsonAsync(path: Path.Combine(path1: "GetBotsRequest", path2: path));
        }
    }
}