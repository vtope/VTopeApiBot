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
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        [Fact]
        public async Task GetBots()
        {
            // Arrange
            await ReadJsonAsync(nameof(GetBots));

            // Act
            var bots = await _httpClient.Bot.GetBotsAsync();

            // Assert
            Assert.NotNull(bots.Earned);
            Assert.NotEmpty(bots.Bots);

            var bot = bots.Bots.First();
            Assert.Equal(Status.Danger, bot.Status);
            Assert.Equal("botname", bot.Name);
            Assert.Equal(Access.On, bot.Access);
            Assert.Equal(1234567, bot.Id);
            Assert.Null(bot.AppName);
        }
        
        private Task ReadJsonAsync(string path)
        {
            return _httpClient.ReadJsonAsync(Path.Combine("GetBotsRequest", path));
        }
    }
}