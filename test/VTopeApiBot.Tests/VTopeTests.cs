using System;
using Xunit;

namespace VTopeApiBot.Tests
{
    public class VTopeTests
    {
        [Theory]
        [InlineData("", "key")]
        [InlineData(null, "key")]
        [InlineData("user", "")]
        [InlineData("user", null)]
        public void ShouldThrowOnNullUserAndKey(string user, string key)
        {
            Assert.Throws<ArgumentException>(
                () => new VTope(user, key)
            );
        }
    }
}
