using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Types.Responses;

namespace VTopeApiBot.Requests.Avaible_Methods
{
    /// <summary>
    ///     Rename bot
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class RenameBotRequest: Request<CodeResponse>
    {
        public RenameBotRequest(long id, string name)
            : base("renamebot")
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        ///     Id bot
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Id { get; }
        
        /// <summary>
        ///     New bot name
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Name { get; }

        public override VTopeParams Parameters() =>
            new VTopeParams
            {
                {"bot", Id},
                {"name", Name}
            };
    }
}