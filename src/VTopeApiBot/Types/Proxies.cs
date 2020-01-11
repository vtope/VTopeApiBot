using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Helpers.JsonConverters;
using VTopeApiBot.Types.Enums;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     This object represents a proxies information
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Proxies
    {
        /// <summary>
        ///     Proxy status
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProxyStatus Status { get; set; }

        /// <summary>
        ///     Number of linked work accounts
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Accounts { get; set; }

        /// <summary>
        ///     Total number of linked accounts
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? AccountsTotal { get; set; }

        /// <summary>
        ///     Proxy version 4 or 6
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProxyVersion? IpVersion { get; set; }

        /// <summary>
        ///     Proxy ip
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(IPAddressConverter))]
        public IPAddress Ip { get; set; }

        /// <summary>
        ///     Proxy login
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        public string Login { get; set; }

        /// <summary>
        ///     Proxy type 
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProxyType Type { get; set; }

        /// <summary>
        ///     Proxy port
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Port { get; set; }

        /// <summary>
        ///     Id
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Id { get; set; }
    }
}