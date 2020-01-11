using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///      This object represents a strategies information
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Strategy
    {
        /// <summary>
        ///     Id strategy
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Id { get; set; }
        
        /// <summary>
        ///     Name strategy
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }
    }
}