﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Types.Responses;

namespace VTopeApiBot.Requests.Avaible_Methods
{
    /// <summary>
    ///     Get list of all bots
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class GetBotsRequest : ParameterlessRequest<BotsResponse>
    {
        public GetBotsRequest() 
            : base("list") { }
    }
}