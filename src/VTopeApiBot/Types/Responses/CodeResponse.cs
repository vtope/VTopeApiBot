using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Types.Enums;

namespace VTopeApiBot.Types.Responses
{
    /// <summary>
    ///     Code response
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CodeResponse
    {
        /// <summary>
        ///     Code response
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Code Code { get; set; }
    }
}