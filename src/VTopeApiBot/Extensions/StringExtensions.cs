using Newtonsoft.Json.Linq;

namespace VTopeApiBot.Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="System.String" />.
    /// </summary>
    public static class StringExtensions
    {
        /// <inheritdoc cref="Newtonsoft.Json.Linq.JObject.Parse(string)" />
        public static JObject ToJObject(this string s)
        {
            return JObject.Parse(s);
        }
    }
}