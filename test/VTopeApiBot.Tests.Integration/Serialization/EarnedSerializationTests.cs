using System.Threading.Tasks;
using VTopeApiBot.Tests.Integration.Helpers;
using VTopeApiBot.Types;
using Xunit;

namespace VTopeApiBot.Tests.Integration.Serialization
{
    public class EarnedSerializationTests : SerializationReaderHelper
    {
        [Fact]
        public async Task Earned_Mapping_All_Properties()
        {
            // Arrange
            await ReadJsonAsync(nameof(Earned_Mapping_All_Properties));

            // Act
            var earned = DeserializeObject<Earned>();

            // Assert
            Assert.Equal(1, earned.Week);
            Assert.Equal(2, earned.Total);
            Assert.Equal(3, earned.Today);
            Assert.Equal(4, earned.Month);
            Assert.Equal(5, earned.Day);
        }

        [Fact]
        public async Task Earned_Mapping_Required_Properties()
        {
            // Arrange
            await ReadJsonAsync(nameof(Earned_Mapping_Required_Properties));

            // Act
            var earned = DeserializeObject<Earned>();

            // Assert
            Assert.Null(earned.Day);
            Assert.Null(earned.Today);
            Assert.Equal(1, earned.Week);
            Assert.Equal(2, earned.Total);
            Assert.Equal(3, earned.Month);
        }
    }
}