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
        [Theory]
        [MemberData(nameof(GetCustomSetters))]
        public void SetNullable_CustomSetters_ThrownArgumentException(
            IBotCredentials botCredentials,
            HttpClient httpClient,
            ILogger logger)
        {
            // Act
            Func<IVTopeBot> botBuilder = () => new VTopeBotBuilder()
                .SetBot(botCredentials)
                .UseHttpClient(httpClient)
                .UseLogger(logger)
                .Build();

            // Arrange
            Assert.NotNull(botBuilder);
            Assert.Throws<ArgumentNullException>(botBuilder);
        }

        public static IEnumerable<object[]> GetCustomSetters()
        {
            yield return new object[]
            {
                null,
                new HttpClient(),
                new Logger<VTopeBotBuilderTests>(new NullLoggerFactory())
            };
            yield return new object[]
            {
                new BotCredentials("user", "key"),
                null,
                new Logger<VTopeBotBuilderTests>(new NullLoggerFactory())
            };
            yield return new object[]
            {
                new BotCredentials("user", "key"),
                new HttpClient(),
                null
            };
        }

        [Fact]
        public void SetBot_CreateInstance_WithCredentials()
        {
            // Arrange
            const string user = "user";
            const string key = "key";

            var botCredentials = new BotCredentials(user, key);

            // Act
            var botBuilder = new VTopeBotBuilder()
                .SetBot(botCredentials)
                .Build();

            // Arrange
            Assert.NotNull(botBuilder);
            Assert.IsAssignableFrom<IVTopeBot>(botBuilder);
        }
    }
}