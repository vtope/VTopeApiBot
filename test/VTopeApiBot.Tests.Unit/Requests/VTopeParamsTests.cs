using System.Collections.Generic;
using VTopeApiBot.Requests;
using Xunit;

namespace VTopeApiBot.Tests.Unit.Requests
{
    public class VTopeParamsTests
    {
        [Fact]
        public void Constructor_With_Parameters()
        {
            // Act
            var dictionary = new Dictionary<string, object>
            {
                {"param1", 123}
            };

            // Arrange
            var arg = new VTopeParams(dictionary: dictionary);

            // Assert
            Assert.NotNull(@object: arg);
            Assert.True(condition: arg.ContainsKey(key: "param1"));
            Assert.True(condition: arg.ContainsValue(value: 123));
        }

        [Fact]
        public void EmptyProperty_CreateVTopeParams()
        {
            // Act
            var arg = VTopeParams.Empty;

            // Assert
            Assert.NotNull(@object: arg);
            Assert.Empty(collection: arg);
            Assert.IsType<VTopeParams>(@object: arg);
        }
    }
}