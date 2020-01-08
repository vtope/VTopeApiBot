using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Types.Enums;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     This object represents a bot information
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Bot
    {
        /// <summary>
        ///     Bot access
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Access Access { get; set; }

        /// <summary>
        ///     Bot status
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Account Accounts { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public object AppName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Earned Earned { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Proxies Proxies { get; set; }

        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
    }
}