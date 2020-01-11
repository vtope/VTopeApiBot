using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     This object represents a mail information
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Mail
    {
        /// <summary>
        ///     Email address
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Email { get; set; }
        
        /// <summary>
        ///     Password from the mail, String.Empty - if not changed
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Password { get; set; }
    }
}