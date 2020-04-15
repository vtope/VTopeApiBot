using System.Threading.Tasks;
using VTopeApiBot.Tests.Integration.Helpers;
using VTopeApiBot.Types;
using Xunit;

namespace VTopeApiBot.Tests.Integration.Serialization
{
    public class ProxySerializationTests : SerializationReaderHelper
    {
        [Fact]
        public async Task Proxy_Mapping_All_Properties()
        {
            // Arrange
            await ReadJsonAsync(nameof(Proxy_Mapping_All_Properties));

            // Act
            var earned = DeserializeObject<Proxy>();

            // Assert
            Assert.Equal(1, earned.Warning);
            Assert.Equal(3, earned.Success);
            Assert.Equal(4, earned.Danger);
        }
    }
}