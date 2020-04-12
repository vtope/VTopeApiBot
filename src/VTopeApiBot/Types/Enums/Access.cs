using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// ReSharper disable UnusedMember.Global
namespace VTopeApiBot.Types.Enums
{
    /// <summary>
    ///     Bot access.
    /// </summary>
    [JsonConverter(converterType: typeof(StringEnumConverter), true)]
    public enum Access
    {
        /// <summary>
        ///     Available.
        /// </summary>
        On,
        
        /// <summary>
        ///     Offline.
        /// </summary>
        Off,
        
        /// <summary>
        ///     No connection.
        /// </summary>
        NoConnection
    }
}