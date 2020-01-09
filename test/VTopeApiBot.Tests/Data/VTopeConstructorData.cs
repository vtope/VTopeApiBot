using System.Collections.Generic;
using System.Net.Http;
using VTopeApiBot.Options;

namespace VTopeApiBot.Tests.Data
{
    public class VTopeConstructorData
    {
        public static IEnumerable<object[]> Data =>
            new[]
            {
                new object[] {null, new HttpClient()},
                new object[] {new AuthorizeOptions("user", "key"), null},
                new object[] {null, null}
            };
    }
}