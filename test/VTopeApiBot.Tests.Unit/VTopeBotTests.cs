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
            
            var botCredentials = new BotCredentials(user: user, key: key);

            // Act
            var instance = new VTopeBot(botCredentials: botCredentials, httpClient: null, logger: null); 
            
            // Assert
            Assert.NotNull(@object: instance);
        }

        [Fact]
        public void IncorrectCredentials_ThrownArgumentNullException()
        {
            // Act
            Func<VTopeBot> instance = () => new VTopeBot(botCredentials: null, httpClient: null, logger: null);
            
            // Assert
            Assert.NotNull(@object: instance);
            Assert.Throws<ArgumentNullException>(testCode: instance);
        }
    }
}