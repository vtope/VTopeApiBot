using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VTopeApiBot.Types.Enums;

namespace VTopeApiBot.Types.Responses
{
    /// <summary>
    ///     Code response.
    /// </summary>
    [Serializable]
    public class CodeResponse
    {
        /// <summary>
        ///     Code response.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Code Code { get; set; }
    }
}