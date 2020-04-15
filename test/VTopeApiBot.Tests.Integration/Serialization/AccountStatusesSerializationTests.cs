using System.Threading.Tasks;
using VTopeApiBot.Tests.Integration.Helpers;
using VTopeApiBot.Types;
using Xunit;

namespace VTopeApiBot.Tests.Integration.Serialization
{
    public class AccountStatusesSerializationTests : SerializationReaderHelper
    {
        [Fact]
        public async Task AccountStatuses_Mappings_All_Properties()
        {
            // Arrange
            await ReadJsonAsync(nameof(AccountStatuses_Mappings_All_Properties));

            // Act
            var statuses = DeserializeObject<AccountStatuses>();

            // Assert
            Assert.Equal(1, statuses.Instagram.Manual);
            Assert.Equal(2, statuses.Instagram.Ipv6Proxy);
            Assert.Equal(3, statuses.Instagram.LoadErrorMobileCode);
            Assert.Equal(4, statuses.Instagram.Duplicate);
            Assert.Equal(5, statuses.Instagram.Banned);
            Assert.Equal(6, statuses.Instagram.BadAuth);
            Assert.Equal(7, statuses.Instagram.BadProxy);
            Assert.Equal(8, statuses.Instagram.LevelZeroAccount);
            Assert.Equal(9, statuses.Instagram.NonValidating);
            Assert.Equal(10, statuses.Instagram.Validating);
            Assert.Equal(11, statuses.Instagram.ToManual);
            Assert.Equal(12, statuses.Instagram.ToManualMobileCode);
            Assert.Equal(13, statuses.Instagram.PreValidating);
            Assert.Equal(14, statuses.Instagram.BadPreAuth);
            Assert.Equal(15, statuses.Instagram.OkPreAuth);
            Assert.Equal(16, statuses.Instagram.WaitProxy);
            Assert.Equal(17, statuses.Instagram.Queued);
            Assert.Equal(18, statuses.Instagram.NonWorking);
            Assert.Equal(19, statuses.Instagram.Working);
            Assert.Equal(20, statuses.Instagram.ToInfo);
            Assert.Equal(21, statuses.Instagram.SleepingTimestamp);
            Assert.Equal(22, statuses.Instagram.WorkingBlocked);
            
            Assert.Equal(1, statuses.Vkontakte.BadAuth);
            
            Assert.Equal(2, statuses.Youtube.Manual);
            
            Assert.Equal(1, statuses.OkRu.BadAuth);
            
            Assert.Equal(1, statuses.Telegram.BadAuth);
        }
    }
}