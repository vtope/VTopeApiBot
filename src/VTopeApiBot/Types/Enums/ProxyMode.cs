using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// ReSharper disable UnusedMember.Global

namespace VTopeApiBot.Types.Enums
{
    /// <summary>
    ///     Proxy selection mode
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum ProxyMode
    {
        /// <summary>
        ///     Auto
        /// </summary>
        Auto,
        
        /// <summary>
        ///     Manual
        /// </summary>
        Manual
    }
}