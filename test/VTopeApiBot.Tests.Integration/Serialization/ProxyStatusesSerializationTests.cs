using System;
using System.Threading.Tasks;
using VTopeApiBot.Tests.Integration.Helpers;
using VTopeApiBot.Types;
using Xunit;

namespace VTopeApiBot.Tests.Integration.Serialization
{
    public class ProxyStatusesSerializationTests : SerializationReaderHelper
    {
        [Fact]
        public async Task ProxyStatuses_Mappings_All_Properties()
        {
            // Arrange
            await ReadJsonAsync(nameof(ProxyStatuses_Mappings_All_Properties));

            // Act
            var statuses = DeserializeObject<ProxyStatuses>();

            // Assert
            Assert.Equal(1, statuses.Http.Used);
            Assert.Equal(2, statuses.Http.BadState);
            Assert.Equal(3, statuses.Http.TooSlow);
            Assert.Equal(4, statuses.Http.QueuedProxy);
            Assert.Equal(5, statuses.Http.ToValidate);
            Assert.Equal(6, statuses.Http.Validating);
            Assert.Equal(7, statuses.Http.Working);
            
            Assert.Null(statuses.Https);
            Assert.Null(statuses.Socks5);
        }
    }
}