using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     List of available strategies on your VTope account
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Strategies
    {
        /// <summary>
        ///     Vkontakte
        /// </summary>
        [JsonProperty("v", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Strategy> Vkontakte { get; set; } 
        
        /// <summary>
        ///     Twitter
        /// </summary>
        [JsonProperty("t", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Strategy> Twitter { get; set; }
        
        /// <summary>
        ///     Instagram
        /// </summary>
        [JsonProperty("i", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Strategy> Instagram { get; set; }
        
        /// <summary>
        ///      Ask.fm   
        /// </summary>
        [JsonProperty("a", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Strategy> AskFm { get; set; }
        
        /// <summary>
        ///     Youtube
        /// </summary>
        [JsonProperty("y", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Strategy> Youtube { get; set; }
    }
}