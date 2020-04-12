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
            await ReadJsonAsync(path: nameof(Account_Mapping_All_Properties));

            // Act
            var earned = DeserializeObject<Account>();

            // Assert
            Assert.Equal(expected: 1, actual: earned.Warning);
            Assert.Equal(expected: 2, actual: earned.Primary);
            Assert.Equal(expected: 3, actual: earned.Success);
            Assert.Equal(expected: 4, actual: earned.Danger);
        }
    }
}