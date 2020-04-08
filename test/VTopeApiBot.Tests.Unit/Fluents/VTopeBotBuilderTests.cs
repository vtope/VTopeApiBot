using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using VTopeApiBot.Credentials;
using VTopeApiBot.Fluents;
using Xunit;

namespace VTopeApiBot.Tests.Unit.Fluents
{
    public class VTopeBotBuilderTests
    {
        [Fact]
        public void SetBot_CreateInstance_WithCredentials()
        {
            // Arrange
            const string user = "user";
            const string key = "key";

            var botCredentials = new BotCredentials(user: user, key: key);

            // Act
            var botBuilder = new VTopeBotBuilder()
                .SetBot(botCredentials: botCredentials)
                .Build();

            // Arrange
            Assert.NotNull(@object: botBuilder);
            Assert.IsAssignableFrom<IVTopeBot>(@object: botBuilder);
        }

        [Theory]
        [MemberData(memberName: nameof(GetCustomSetters))]
        public void SetNullable_CustomSetters_ThrownArgumentException(
            IBotCredentials botCredentials,
            HttpClient httpClient,
            ILogger logger)
        {
            // Act
            Func<IVTopeBot> botBuilder = () => new VTopeBotBuilder()
                .SetBot(botCredentials: botCredentials)
                .UseHttpClient(httpClient: httpClient)
                .UseLogger(logger: logger)
                .Build();

            // Arrange
            Assert.NotNull(@object: botBuilder);
            Assert.Throws<ArgumentNullException>(testCode: botBuilder);
        }

        public static IEnumerable<object[]> GetCustomSetters()
        {
            yield return new object[]
            {
                null,
                new HttpClient(),
                new Logger<VTopeBotBuilderTests>(factory: new NullLoggerFactory()) 
            };
            yield return new object[]
            {
                new BotCredentials(user: "user", key: "key"),
                null,
                new Logger<VTopeBotBuilderTests>(factory: new NullLoggerFactory()) 
            };
            yield return new object[]
            {
                new BotCredentials(user: "user", key: "key"),
                new HttpClient(),
                null
            };
        }
    }
}