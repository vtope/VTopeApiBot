using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Types.Responses;

namespace VTopeApiBot.Requests.Avaible_Methods
{
    /// <summary>
    ///     Delete bot
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class DeleteBotRequest : Request<CodeResponse>
    {
        public DeleteBotRequest(long id)
            : base("deletebot")
        {
        }

        /// <summary>
        ///     Id bot
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Id { get; set; }

        public override VTopeParams Parameters() =>
            new VTopeParams
            {
                {"bot", Id}
            };
    }
}