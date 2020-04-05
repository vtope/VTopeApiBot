using System;

namespace VTopeApiBot.Credentials
{
    /// <inheritdoc />
    [Serializable]
    public class BotCredentials : IBotCredentials
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VTopeApiBot.Credentials.BotCredentials"/> class.
        /// </summary>
        /// <param name="user">Unique value for authorization.</param>
        /// <param name="key">Unique value for authorization.</param>
        /// <exception cref="ArgumentException">
        ///    Thrown if user is null or whitespace.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///    Thrown if key is null or whitespace.
        /// </exception>
        public BotCredentials(string user, string key)
        {
            if (string.IsNullOrWhiteSpace(value: user))
                throw new ArgumentException(message: "Value cannot be null or whitespace.", paramName: nameof(user));
            if (string.IsNullOrWhiteSpace(value: key))
                throw new ArgumentException(message: "Value cannot be null or whitespace.", paramName: nameof(key));
            
            User = user;
            Key = key;
        }

        /// <inheritdoc />
        public string User { get; set; }

        /// <inheritdoc />
        public string Key { get; set; }
    }
}