using System;
using Newtonsoft.Json;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     Proxy status.
    /// </summary>
    [Serializable]
    public class ProxyStatus
    {
        /// <summary>
        ///     Proxy too slow.
        /// </summary>
        public long? TooSlow { get; set; }
        
        /// <summary>
        ///     Proxy not working.
        /// </summary>
        public long? BadState { get; set; }
        
        /// <summary>
        ///     Proxy waits until the desired account starts working.
        /// </summary>
        [JsonProperty("queued_proxy")]
        public long? QueuedProxy { get; set; }

        /// <summary>
        ///     Auto check.
        /// </summary>
        public long? ToValidate { get; set; }

        /// <summary>
        ///     Auto check.
        /// </summary>
       public long? Validating { get; set; }
        
        /// <summary>
        ///     Proxies in work.
        /// </summary>
        public long? Working { get; set; }

        /// <summary>
        ///     Proxies used all the time.
        /// </summary>
        public long Used { get; set; }
    }
}