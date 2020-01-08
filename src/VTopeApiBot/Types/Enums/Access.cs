using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VTopeApiBot.Types.Enums
{
    /// <summary>
    ///     Bot access
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum Access
    {
        /// <summary>
        ///     Available
        /// </summary>
        On,
        
        /// <summary>
        ///     Offline
        /// </summary>
        Off,
        
        /// <summary>
        ///     No connection
        /// </summary>
        NoConnection
    }
}