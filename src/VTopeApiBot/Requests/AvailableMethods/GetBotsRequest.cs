using VTopeApiBot.Types.Responses;

namespace VTopeApiBot.Requests.AvailableMethods
{
    /// <summary>
    ///     Gets a list of all bots.
    /// </summary>
    public class GetBotsRequest : ParameterlessRequest<BotsResponse>
    {
        /// <summary>
        ///     Initializes a new request without parameters.
        /// </summary>
        public GetBotsRequest() : base(methodName: "list")
        {
        }
    }
}