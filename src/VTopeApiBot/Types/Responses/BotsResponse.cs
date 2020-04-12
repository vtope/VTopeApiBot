using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VTopeApiBot.Types.Responses
{
    /// <summary>
    ///     Response a list of all bots.
    /// </summary>
    [JsonObject(memberSerialization: MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class BotsResponse
    {
        /// <summary>
        ///     List of all bots.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public IEnumerable<Bot> Bots { get; set; }
        
        /// <summary>
        ///     Earned information.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Earned Earned { get; set; }
    }
}