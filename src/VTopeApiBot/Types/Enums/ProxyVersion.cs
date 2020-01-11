using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// ReSharper disable UnusedMember.Global

namespace VTopeApiBot.Types.Enums
{
    /// <summary>
    ///     Proxy versions
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum ProxyVersion
    {
        /// <summary>
        ///     Social network support IPv4
        /// </summary>
        Ipv4Proxy = 4,
        
        /// <summary>
        ///     Social network support IPv4
        /// </summary>
        Ipv6Proxy = 6,
    }
}