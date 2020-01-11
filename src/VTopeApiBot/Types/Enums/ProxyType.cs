using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// ReSharper disable UnusedMember.Global

namespace VTopeApiBot.Types.Enums
{
    /// <summary>
    ///     Proxy types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum ProxyType
    {
        /// <summary>
        ///     Http
        /// </summary>
        Http,
        
        /// <summary>
        ///     Https
        /// </summary>
        Https,
        
        /// <summary>
        ///     Socks5
        /// </summary>
        Socks5,
    }
}