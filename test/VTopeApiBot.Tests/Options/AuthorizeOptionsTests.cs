using System;
using System.Net.Http;
using VTopeApiBot.Options;
using Xunit;
using static Xunit.Assert;

namespace VTopeApiBot.Tests.Options
{
    public class AuthorizeOptionsTests
    {
        [Theory]
        [InlineData(null, "")]
        [InlineData("", null)]
        [InlineData(null, null)]
        [InlineData("", "")]
        public void Constructor_NullUserAndKey_ThrownException(string user, string key)
        {
            Throws<ArgumentException>(() => new AuthorizeOptions(user, key));
        }

        [Fact]
        public void Constructor_CorrectUserAndKey_ParametersEqualsProps()
        {
            // Arrange
            const string user = "user";
            const string key = "key";
            
            // Act
            var options = new AuthorizeOptions(user, key);
            
            // Assert
           True(options.User == user);
           True(options.Key == key);
        }
    }
}