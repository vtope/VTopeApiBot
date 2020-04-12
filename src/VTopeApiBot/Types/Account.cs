﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     This object represents accounts information.
    /// </summary>
    [JsonObject(memberSerialization: MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Account
    {
        /// <summary>
        ///     Number of accounts with problems.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Warning { get; set; }

        /// <summary>
        ///     Number of accounts in work.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Primary { get; set; }

        /// <summary>
        ///     Number of non-working accounts.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Success { get; set; }

        /// <summary>
        ///     Number of accounts requiring intervention.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Danger { get; set; }
    }
}