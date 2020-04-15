using System;
using VTopeApiBot.Credentials;
using Xunit;

namespace VTopeApiBot.Tests.Unit
{
    public class VTopeBotTests
    {
        [Fact]
        public void CorrectConstructor_CreateInstance()
        {
            // Arrange
            const string user = "user";
            const string key = "key";

            var botCredentials = new BotCredentials(user, key);

            // Act
            var instance = new VTopeBot(botCredentials, null, null);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void IncorrectCredentials_ThrownArgumentNullException()
        {
            // Act
            Func<VTopeBot> instance = () => new VTopeBot(null, null, null);

            // Assert
            Assert.NotNull(instance);
            Assert.Throws<ArgumentNullException>(instance);
        }
    }
}