using System;
using VTopeApiBot.Credentials;
using Xunit;

namespace VTopeApiBot.Tests.Unit.Credentials
{
    public class BotCredentialsTests
    {
        [Fact]
        public void CorrectParams_CreateInstance()
        {
            // Arrange
            const string user = "user";
            const string key = "key";

            // Act
            var instance = new BotCredentials(user: user, key: key);

            // Assert
            Assert.NotNull(@object: instance);
            Assert.Equal(expected: user, actual: instance.User);
            Assert.Equal(expected: key, actual: instance.Key);
        }

        [Theory]
        [InlineData(null, "key")]
        [InlineData("user", null)]
        public void IncorrectParams_ThrownArgumentException(string user, string key)
        {
            // Act
            Func<BotCredentials> func = () => new BotCredentials(user: user, key: key);

            // Assert
            Assert.NotNull(@object: func);
            Assert.Throws<ArgumentException>(testCode: func);
        }
    }
}