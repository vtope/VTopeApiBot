using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Types.Enums;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     This object represents a full bot information.
    /// </summary>
    [JsonObject(memberSerialization: MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Bot
    {
        /// <summary>
        ///     Bot status.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(converterType: typeof(StringEnumConverter))]
        public Status Status { get; set; }

        /// <summary>
        ///     Proxies information.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Proxy Proxies { get; set; }

        /// <summary>
        ///     Name bot.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        ///     Earned information.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Earned Earned { get; set; }

        /// <summary>
        ///     Bot access.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(converterType: typeof(StringEnumConverter))]
        public Access Access { get; set; }

        /// <summary>
        ///     Accounts.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Account Accounts { get; set; }

        // TODO: update summary and property type.
        /// <summary>
        ///     No information.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public object? AccountStatuses { get; set; }
        
        // TODO: update summary and property type.
        /// <summary>
        ///     No information.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public object? ProxyStatuses { get; set; }
        
        /// <summary>
        ///     Id bot.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Id { get; set; }

        /// <summary>
        ///     Application name.
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        public object? AppName { get; set; }
    }
}