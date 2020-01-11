using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Types.Enums;

namespace VTopeApiBot.Types.Responses
{
    /// <summary>
    ///     Response concrete bot
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class BotResponse
    {
        /// <summary>
        ///     Bot status
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
        
        // TODO: not found information about this property in docs. Need to write in support
        /// <summary>
        ///     Application name
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        public object AppName { get; set; }

        /// <summary>
        ///     Whether remote bot control is allowed
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public bool AllowControl { get; set; }
        
        /// <summary>
        ///     Accounts information
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public IEnumerable<Accounts> Accounts { get; set; }
        
        /// <summary>
        ///     Proxies information
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public IEnumerable<Proxies> Proxies { get; set; }
        
        /// <summary>
        ///     Bot earnings enabled
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public bool Earning { get; set; }
        
        /// <summary>
        ///     Bot name
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }
        
        // TODO: not found object in docs. Need to write in support
        /// <summary>
        ///     Earned information
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Earned Earned { get; set; }
        
        /// <summary>
        ///     Id bot
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Id { get; set; }
        
        /// <summary>
        ///      Bot access
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Access Access { get; set; }
        
        /// <summary>
        ///     List of available strategies on your VTope account
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Strategies Strategies { get; set; }
    }
}