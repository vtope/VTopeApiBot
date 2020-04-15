using System;
using Newtonsoft.Json;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     Account status.
    /// </summary>
    [Serializable]
    public class AccountStatus
    {
        /// <summary>
        ///     Manual authorization.
        /// </summary>
        public long? Manual { get; set; }

        /// <summary>
        ///     Social network does not support IPv6.
        /// </summary>
        public long? Ipv6Proxy { get; set; }

        /// <summary>
        ///     Special authorization.
        /// </summary>
        public long? LoadErrorMobileCode { get; set; }

        /// <summary>
        ///     Duplicate Account.
        /// </summary>
        public long? Duplicate { get; set; }

        /// <summary>
        ///     Banned.
        /// </summary>
        public long? Banned { get; set; }

        /// <summary>
        ///     Invalid username / password.
        /// </summary>
        public long? BadAuth { get; set; }

        /// <summary>
        ///     The bound proxy does not work.
        /// </summary>
        public long? BadProxy { get; set; }

        /// <summary>
        ///     Level 0 Account.
        /// </summary>
        public long? LevelZeroAccount { get; set; }

        /// <summary>
        ///     Pending Verification.
        /// </summary>
        public long? NonValidating { get; set; }

        /// <summary>
        ///     Auto check.
        /// </summary>
        public long? Validating { get; set; }

        /// <summary>
        ///     Auto check.
        /// </summary>
        public long? ToManual { get; set; }

        /// <summary>
        ///     Auto check.
        /// </summary>
        public long? ToManualMobileCode { get; set; }

        /// <summary>
        ///     Auto check.
        /// </summary>
        public long? PreValidating { get; set; }

        /// <summary>
        ///     Auto check.
        /// </summary>
        public long? BadPreAuth { get; set; }

        /// <summary>
        ///     Auto check.
        /// </summary>
        public long? OkPreAuth { get; set; }

        /// <summary>
        ///     Account expects proxy.
        /// </summary>
        public long? WaitProxy { get; set; }

        /// <summary>
        ///     In line for work.
        /// </summary>
        public long? Queued { get; set; }

        /// <summary>
        ///    Awaiting work.
        /// </summary>
        public long? NonWorking { get; set; }

        /// <summary>
        ///     In work.
        /// </summary>
        public long? Working { get; set; }

        /// <summary>
        ///     In work.
        /// </summary>
        public long? ToInfo { get; set; }

        /// <summary>
        ///     Account rests before timestamp.
        /// </summary>
        public long? SleepingTimestamp { get; set; }

        /// <summary>
        ///     Block on actions from the social network.
        /// </summary>
        public long? WorkingBlocked { get; set; }
    }
}