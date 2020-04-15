using System.Threading.Tasks;
using VTopeApiBot.Tests.Integration.Helpers;
using VTopeApiBot.Types;
using Xunit;

namespace VTopeApiBot.Tests.Integration.Serialization
{
    public class AccountSerializationTests : SerializationReaderHelper
    {
        [Fact]
        public async Task Account_Mapping_All_Properties()
        {
            // Arrange
            await ReadJsonAsync(nameof(Account_Mapping_All_Properties));

            // Act
            var earned = DeserializeObject<Account>();

            // Assert
            Assert.Equal(1, earned.Warning);
            Assert.Equal(2, earned.Primary);
            Assert.Equal(3, earned.Success);
            Assert.Equal(4, earned.Danger);
        }
    }
}