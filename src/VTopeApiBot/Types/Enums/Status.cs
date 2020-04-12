using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// ReSharper disable UnusedMember.Global

namespace VTopeApiBot.Types.Enums
{
    /// <summary>
    ///     Bot status.
    /// </summary>
    [JsonConverter(converterType: typeof(StringEnumConverter), true)]
    public enum Status
    {
        /// <summary>
        ///     The bot is working, everything is fine.
        /// </summary>
        Success,

        /// <summary>
        ///     The bot works, but there are problems.
        /// </summary>
        Warning,

        /// <summary>
        ///     Bot does not earn points.
        /// </summary>
        Danger
    }
}