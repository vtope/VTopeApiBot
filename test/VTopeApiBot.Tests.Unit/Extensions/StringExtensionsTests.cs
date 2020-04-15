using Newtonsoft.Json.Linq;
using VTopeApiBot.Extensions;
using Xunit;

namespace VTopeApiBot.Tests.Unit.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ToJObject()
        {
            // Arrange
            const string json = @"{ ""key"": { ""value"": 123 } }";

            // Act
            var jObject = json.ToJObject();

            Assert.IsType<JObject>(jObject);
            Assert.Equal(123, jObject["key"]["value"]);
        }
    }
}