using System;

namespace VTopeApiBot.Options
{
    public class AuthorizeOptions
    {
        public AuthorizeOptions(string user, string key)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(user));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            User = user;
            Key = key;
        }
        
        /// <summary>
        ///     Unique value for authorization
        /// </summary>
        public string User { get; }
        
        /// <summary>
        ///     Unique value for authorization
        /// </summary>
        public string Key { get; }
    }
}