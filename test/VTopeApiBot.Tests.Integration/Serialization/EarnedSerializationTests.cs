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
            await ReadJsonAsync(path: nameof(Earned_Mapping_All_Properties));

            // Act
            var earned = DeserializeObject<Earned>();

            // Assert
            Assert.Equal(expected: 1, actual: earned.Week);
            Assert.Equal(expected: 2, actual: earned.Total);
            Assert.Equal(expected: 3, actual: earned.Today);
            Assert.Equal(expected: 4, actual: earned.Month);
            Assert.Equal(expected: 5, actual: earned.Day);
        }

        [Fact]
        public async Task Earned_Mapping_Required_Properties()
        {
            // Arrange
            await ReadJsonAsync(path: nameof(Earned_Mapping_Required_Properties));

            // Act
            var earned = DeserializeObject<Earned>();

            // Assert
            Assert.Null(@object: earned.Day);
            Assert.Null(@object: earned.Today);
            Assert.Equal(expected: 1, actual: earned.Week);
            Assert.Equal(expected: 2, actual: earned.Total);
            Assert.Equal(expected: 3, actual: earned.Month);
        }
    }
}