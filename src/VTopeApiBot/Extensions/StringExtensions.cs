using Newtonsoft.Json.Linq;

namespace VTopeApiBot.Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="System.String"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <inheritdoc cref="Newtonsoft.Json.Linq.JToken.Parse(string)"/>
        public static JToken ToJToken(this string s)
        {
            return JToken.Parse(json: s);
        }
    }
}