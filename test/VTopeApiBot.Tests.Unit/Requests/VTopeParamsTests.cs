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
            var arg = new VTopeParams(dictionary);

            // Assert
            Assert.NotNull(arg);
            Assert.True(arg.ContainsKey("param1"));
            Assert.True(arg.ContainsValue(123));
        }

        [Fact]
        public void EmptyProperty_CreateVTopeParams()
        {
            // Act
            var arg = VTopeParams.Empty;

            // Assert
            Assert.NotNull(arg);
            Assert.Empty(arg);
            Assert.IsType<VTopeParams>(arg);
        }
    }
}