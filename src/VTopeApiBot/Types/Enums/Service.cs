using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// ReSharper disable UnusedMember.Global

namespace VTopeApiBot.Types.Enums
{
    /// <summary>
    ///     Service type
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum Service
    {
        /// <summary>
        ///     v - Vkontakte
        /// </summary>
        [EnumMember(Value = "v")]
        Vkontakte, 
        
        /// <summary>
        ///     t - Twitter
        /// </summary>
        [EnumMember(Value = "t")]
        Twitter, 
        
        /// <summary>
        ///     i - Instagram
        /// </summary>
        [EnumMember(Value = "i")]
        Instagram,
        
        /// <summary>
        ///      a - Ask.fm   
        /// </summary>
        [EnumMember(Value = "a")]
        AskFm,
        
        /// <summary>
        ///     y - Youtube
        /// </summary>
        [EnumMember(Value = "y")]
        Youtube,
        
        /// <summary>
        ///     o - Ok.ru
        /// </summary>
        [EnumMember(Value = "o")]
        OkRu,
        
        /// <summary>
        ///     m - Telegram
        /// </summary>
        [EnumMember(Value = "m")]
        Telegram
    }
}