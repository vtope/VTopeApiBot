using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// ReSharper disable UnusedMember.Global

namespace VTopeApiBot.Types.Enums
{
    /// <summary>
    ///     Account actions
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum AccountAction
    {
        /// <summary>
        ///     Add accounts
        /// </summary>
        [EnumMember(Value = "accounts_add")] 
        Add,

        /// <summary>
        ///     Edit account
        /// </summary>
        [EnumMember(Value = "accounts_edit")]
        Edit,

        /// <summary>
        ///     Delete account
        /// </summary>
        [EnumMember(Value = "accounts_delete")] 
        Delete,

        /// <summary>
        ///     Authorize account
        /// </summary>
        [EnumMember(Value = "accounts_authorize")] 
        Authorize,

        /// <summary>
        ///     Multiple add accounts
        /// </summary>
        [EnumMember(Value = "accounts_add_multiple")] 
        AddMultiple,
    }
}