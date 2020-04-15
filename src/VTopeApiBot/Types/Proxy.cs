using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     This object represents a proxies information.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Proxy
    {
        /// <summary>
        ///     Number of proxies with problems.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Warning { get; set; }

        /// <summary>
        ///     Number of proxies in operation.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Success { get; set; }

        /// <summary>
        ///     Number of inactive proxies.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Danger { get; set; }
    }
}