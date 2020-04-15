using System;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///      Proxy statuses.
    /// </summary>
    [Serializable]
    public class ProxyStatuses
    {
        /// <summary>
        ///     Socks5 proxy type.
        /// </summary>
        public ProxyStatus Socks5 { get; set; }
        
        /// <summary>
        ///     Http proxy type.
        /// </summary>
        public ProxyStatus Http { get; set; }
        
        /// <summary>
        ///     Https proxy type.
        /// </summary>
        public ProxyStatus Https { get; set; }
    }
}