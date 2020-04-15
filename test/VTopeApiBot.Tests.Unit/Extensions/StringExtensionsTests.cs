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
            var jObject = json.ToJObject();

            Assert.IsType<JObject>(jObject);
            Assert.Equal(expected: 123, actual: jObject[key: "test"]);
        }
    }
}