using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VTopeApiBot.Types.Responses
{
    /// <summary>
    ///     Response list of all bots
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class BotsResponse
    {
        [JsonProperty(Required = Required.Always)]
        public IEnumerable<Bot> Bots { get; set; }
        
        [JsonProperty(Required = Required.Always)]
        public Earned Earned { get; set; }
    }
}