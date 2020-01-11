using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// ReSharper disable UnusedMember.Global

namespace VTopeApiBot.Types.Enums
{
    /// <summary>
    ///     Account status
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum AccountStatus
    {
        /// <summary>
        ///     Manual authorization
        /// </summary>
        Manual,
        
        /// <summary>
        ///     Social network does not support IPv6
        /// </summary>
        Ipv6Proxy,
        
        /// <summary>
        ///     Special authorization
        /// </summary>
        LoadErrorMobileCode,
        
        /// <summary>
        ///     Duplicate Account
        /// </summary>
        Duplicate,
        
        /// <summary>
        ///     Banned
        /// </summary>
        Banned,
        
        /// <summary>
        ///     Invalid username / password
        /// </summary>
        BadAuth,
        
        /// <summary>
        ///     The bound proxy does not work
        /// </summary>
        BadProxy,
        
        /// <summary>
        ///     Level 0 Account
        /// </summary>
        LevelZeroAccount,
        
        /// <summary>
        ///     Pending Verification
        /// </summary>
        NonValidating,
        
        /// <summary>
        ///     Auto check
        /// </summary>
        Validating,
        
        /// <summary>
        ///     Auto check
        /// </summary>
        ToManual,
        
        /// <summary>
        ///     Auto check
        /// </summary>
        ToManualMobileCode,
        
        /// <summary>
        ///     Auto check
        /// </summary>
        PreValidating,
        
        /// <summary>
        ///     Auto check
        /// </summary>
        BadPreAuth,
        
        /// <summary>
        ///     Auto check
        /// </summary>
        OkPreAuth,
        
        /// <summary>
        ///     Account expects proxy
        /// </summary>
        WaitProxy,
        
        /// <summary>
        ///     In line for work
        /// </summary>
        Queued,
        
        /// <summary>
        ///    Awaiting work 
        /// </summary>
        NonWorking,
        
        /// <summary>
        ///     In work
        /// </summary>
        Working,
        
        /// <summary>
        ///     In work
        /// </summary>
        ToInfo,
        
        /// <summary>
        ///     Account rests before timestamp
        /// </summary>
        SleepingTimestamp,
        
        /// <summary>
        ///     Block on actions from the social network
        /// </summary>
        WorkingBlocked
    }
}