using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// ReSharper disable UnusedMember.Global

namespace VTopeApiBot.Types.Enums
{
    /// <summary>
    ///     Proxy status
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum ProxyStatus
    {
        /// <summary>
        ///     Proxy too slow
        /// </summary>
        TooSlow,
        
        /// <summary>
        ///     Proxy not working
        /// </summary>
        BadState,
        
        /// <summary>
        ///     Proxy waits until the desired account starts working
        /// </summary>
        QueuedProxy,
        
        /// <summary>
        ///     Auto check
        /// </summary>
        ToValidate,
        
        /// <summary>
        ///     Auto check
        /// </summary>
        Validating,
        
        /// <summary>
        ///     Proxies in work
        /// </summary>
        Working
    }
}