using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Types.Enums;

namespace VTopeApiBot.Types.Params
{
    /// <summary>
    ///     Options for working with accounts
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ActionParams
    {
        /// <summary>
        ///     Id bot
        /// </summary>
        [JsonProperty("bot", Required = Required.Always)]
        public long Id { get; set; }
        
        /// <summary>
        ///     Service type
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Service Service { get; set; }
        
        /// <summary>
        ///     Account login
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Login { get; set; }
        
        /// <summary>
        ///     Account password
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Password { get; set; }
        
        /// <summary>
        ///     Id of the selected strategy, null - standard
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Strategy { get; set; }
        
        /// <summary>
        ///     Account-bound mail. Optional field
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        public Mail Mail { get; set; }
        
        /// <summary>
        ///      Proxy selection mode
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProxyMode? ProxyMode { get; set; }
        
        /// <summary>
        ///     Proxy
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        public Proxies Proxy { get; set; }
    }
}