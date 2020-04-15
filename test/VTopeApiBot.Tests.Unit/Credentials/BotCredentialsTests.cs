using System;
using VTopeApiBot.Credentials;
using Xunit;

namespace VTopeApiBot.Tests.Unit.Credentials
{
    public class BotCredentialsTests
    {
        [Theory]
        [InlineData(null, "key")]
        [InlineData("user", null)]
        public void IncorrectParams_ThrownArgumentException(string user, string key)
        {
            // Act
            Func<BotCredentials> func = () => new BotCredentials(user, key);

            // Assert
            Assert.NotNull(func);
            Assert.Throws<ArgumentException>(func);
        }

        [Fact]
        public void CorrectParams_CreateInstance()
        {
            // Arrange
            const string user = "user";
            const string key = "key";

            // Act
            var instance = new BotCredentials(user, key);

            // Assert
            Assert.NotNull(instance);
            Assert.Equal(user, instance.User);
            Assert.Equal(key, instance.Key);
        }
    }
}