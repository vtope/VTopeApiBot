using System;
using Newtonsoft.Json;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     Account statues.
    /// </summary>
    [Serializable]
    public class AccountStatuses
    {
        /// <summary>
        ///     i - Instagram.
        /// </summary>
        [JsonProperty("i")]
        public AccountStatus Instagram { get; set; }
        
        /// <summary>
        ///     v - Vkontakte.
        /// </summary>
        [JsonProperty("v")]
        public AccountStatus Vkontakte { get; set; } 
        
        /// <summary>
        ///     y - Youtube.
        /// </summary>
        [JsonProperty("y")]
        public AccountStatus Youtube { get; set; }
        
        /// <summary>
        ///     o - Ok.ru.
        /// </summary>
        [JsonProperty("o")]
        public AccountStatus OkRu { get; set; }
        
        /// <summary>
        ///     m - Telegram.
        /// </summary>
        [JsonProperty("m")]
        public AccountStatus Telegram { get; set; }    
    }
}