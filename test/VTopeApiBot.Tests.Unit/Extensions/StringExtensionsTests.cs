using Newtonsoft.Json.Linq;
using VTopeApiBot.Extensions;
using Xunit;

namespace VTopeApiBot.Tests.Unit.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ToJToken()
        {
            // Arrange
            const string json = @"{ ""test"": 123 }";
         
            // Act
            var jToken = json.ToJToken();

            Assert.IsType<JObject>(jToken);
            Assert.Equal(expected: 123, actual: jToken[key: "test"]);
        }
    }
}