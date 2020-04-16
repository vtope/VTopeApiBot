using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VTopeApiBot.Types.Enums
{
    /// <summary>
    ///     Code response.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum Code
    {
        /// <summary>
        ///     Ok.
        /// </summary>
        Ok,
        
        /// <summary>
        ///     Bot not found.
        /// </summary>
        NotFound,
        
        /// <summary>
        ///     Invalid parameter format.
        /// </summary>
        Invalid,
        
        /// <summary>
        ///     Account already exists.
        /// </summary>
        Exists
    }
}