using System.IO;
using System.Linq;
using Newtonsoft.Json;
using VTopeApiBot.Tests.Infrastructure;
using VTopeApiBot.Types;
using VTopeApiBot.Types.Enums;
using VTopeApiBot.Types.Responses;
using Xunit;
using static Xunit.Assert;

namespace VTopeApiBot.Tests.Avaible_Methods.Serialization
{
    public class GetBotsSerializationTests : UnitTestBase
    {
        protected override string Folder => "GetBots";
        
        [Fact]
        public void Deserialize_GetBots_ReturnBots()
        {
            // Arrange
            var json = ReadJsonFile(nameof(Deserialize_GetBots_ReturnBots));
            
            // Act
            var response = JsonConvert.DeserializeObject<BotsResponse>(json);
            
            // Assert
            // one bot in response
            Single(response.Bots);
            
            var bot = response.Bots.ToArray().First();
            Equal(Access.On, bot.Access);
            Equal(Status.Danger, bot.Status);
            
            Equal(53, bot.Accounts.Warning);
            Equal(26, bot.Accounts.Primary);
            Equal(14, bot.Accounts.Success);
            Equal(40, bot.Accounts.Danger);
            
            Null(bot.AppName);
            
            Equal(45, bot.Earned.Week);
            Equal(60, bot.Earned.Total);
            Equal(4, bot.Earned.Day);
            Equal(3, bot.Earned.Month);
            
            Equal(4, bot.Proxies.Warning);
            Equal(10, bot.Proxies.Success);
            Equal(2, bot.Proxies.Danger);
            
            Equal(1234567, bot.Id);
            Equal("nickname", bot.Name);

            var earned = response.Earned;
            Equal(5, earned.Week);
            Equal(45, earned.Total);
            Equal(23, earned.Today);
            Equal(4, earned.Month);
        }
    }
}