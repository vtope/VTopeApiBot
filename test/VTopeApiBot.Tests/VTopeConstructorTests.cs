using System;
using System.Net.Http;
using VTopeApiBot.Options;
using VTopeApiBot.Tests.Data;
using Xunit;
using static Xunit.Assert;

namespace VTopeApiBot.Tests
{
    public class VTopeConstructorTests
    {
        [Theory]
        [MemberData(nameof(VTopeConstructorData.Data), MemberType = typeof(VTopeConstructorData))]
        public void Constructor_NullAuthorizeOptionsAndHttpClient_ThrownException(
            AuthorizeOptions options,
            HttpClient httpClient)
        {
            Throws<ArgumentNullException>(
                () => new VTope(options, httpClient)
            );
        }

        [Fact]
        public void Constructor_CorrectParameters_CreateInstance()
        {
            // Arrange
            const string user = "user";
            const string key = "key";
            var options = new AuthorizeOptions(user, key);
            
            // Act
            _ = new VTope(options, new HttpClient());            
        }
    }
}