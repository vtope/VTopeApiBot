using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Types.Responses;

namespace VTopeApiBot.Requests.Avaible_Methods
{
    /// <summary>
    ///     Get concrete bot
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class GetBotByIdRequest : Request<BotResponse>
    {
        public GetBotByIdRequest(long id)
            : base("bot")
        {
            Id = id;
        }

        /// <summary>
        ///     Id bot
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Id { get; set; }

        public override VTopeParams Parameters() =>
            new VTopeParams
            {
                {"id", Id}
            };
    }
}