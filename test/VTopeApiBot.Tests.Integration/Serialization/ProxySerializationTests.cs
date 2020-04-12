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
            await ReadJsonAsync(path: nameof(Proxy_Mapping_All_Properties));

            // Act
            var earned = DeserializeObject<Proxy>();

            // Assert
            Assert.Equal(expected: 1, actual: earned.Warning);
            Assert.Equal(expected: 3, actual: earned.Success);
            Assert.Equal(expected: 4, actual: earned.Danger);
        }
    }
}