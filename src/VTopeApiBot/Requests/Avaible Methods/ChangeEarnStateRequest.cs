using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Types.Responses;

namespace VTopeApiBot.Requests.Avaible_Methods
{
    /// <summary>
    ///     Change the status of bot earnings
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ChangeEarnStateRequest: Request<CodeResponse>
    {
        public ChangeEarnStateRequest(long id, bool state)
            : base("earnstate")
        {
            Id = id;
            State = state;
        }

        /// <summary>
        ///     Id bot
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Id { get; }
        
        /// <summary>
        ///     Bot earning status
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public bool State { get; }

        public override VTopeParams Parameters() =>
            new VTopeParams
            {
                {"bot", Id},
                {"state", State}
            };
    }
}