using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     This object represents a earnings
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Earned
    {
        /// <summary>
        ///     Earned in a week
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Week { get; set; }

        // TODO: not found information about this property in docs. Need to write in support
        /// <summary>
        ///     Earned all the time
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Total { get; set; }
        
        // TODO: not found information about this property in docs. Need to write in support
        /// <summary>
        ///     Earned today
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Today { get; set; }
        
        /// <summary>
        ///     Earned per day
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Day { get; set; }

        /// <summary>
        ///     Earned per month
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Month { get; set; }
    }
}