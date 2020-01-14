#nullable enable
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Helpers.JsonConverters;
using VTopeApiBot.Types.Enums;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     This object represents a accounts information
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Accounts
    {
        /// <summary>
        ///     Account status
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountStatus Status { get; set; }

        /// <summary>
        ///     Bound proxy or null
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        public Proxies? Proxy { get; set; }

        /// <summary>
        ///     Id
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Id { get; set; }

        /// <summary>
        ///     Service type
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Service Service { get; set; }

        // TODO: bug. see CustomBase64Converter.cs
        /// <summary>
        ///     Avatar
        /// </summary>
        /// <remarks>Base64String</remarks>
        [JsonProperty(Required = Required.AllowNull)]
        // [JsonConverter(typeof(CustomBase64Converter))]
        public string Img { get; set; }

        /// <summary>
        ///     Account quality level
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        public Level? Level { get; set; }

        /// <summary>
        ///     Id of the selected strategy, null - standard
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Strategy { get; set; }

        /// <summary>
        ///      Proxy selection mode
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProxyMode? ProxyMode { get; set; }
        
        /// <summary>
        ///     Mail address
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        public Mail Mail { get; set; }
        
        // TODO: Additional verification of the response is required, perhaps the value is always a number.
        // If the judgment is correct, then you must hang the attribute [JsonConverter(typeof(ParseStringConverter))]
        /// <summary>
        ///    Account login
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Login { get; set; }
        
        /// <summary>
        ///     Earned today
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long EarnedToday { get; set; }
        
        /// <summary>
        ///     Earned all the time
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long EarnedTotal { get; set; }
    }
}