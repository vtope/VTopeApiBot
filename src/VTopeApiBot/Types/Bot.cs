﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VTopeApiBot.Types.Enums;

namespace VTopeApiBot.Types
{
    /// <summary>
    ///     This object represents a full bot information.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Bot
    {
        /// <summary>
        ///     Bot status.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }

        /// <summary>
        ///     Proxies information.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Proxy Proxies { get; set; }

        /// <summary>
        ///     Name bot.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        ///     Earned information.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Earned Earned { get; set; }

        /// <summary>
        ///     Bot access.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Access Access { get; set; }

        /// <summary>
        ///     Accounts.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Account Accounts { get; set; }
    
        /// <summary>
        ///     Account statuses.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public AccountStatuses AccountStatuses { get; set; }

        /// <summary>
        ///    Proxy statuses.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public ProxyStatuses ProxyStatuses { get; set; }

        /// <summary>
        ///     Id bot.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long Id { get; set; }

        /// <summary>
        ///     Application name.
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        public object? AppName { get; set; }
    }
}