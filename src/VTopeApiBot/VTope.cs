using System;

namespace VTopeApiBot
{
    /// <summary>
    ///     Main entry class to use VTope API 
    /// </summary>
    public class VTope : IVTope
    {
        /// <summary>
        ///     Unique 'user' value for authorization
        /// </summary>
        private readonly string _user;

        /// <summary>
        ///     Unique 'key' value for authorization
        /// </summary>
        private readonly string _key;

        /// <summary>
        ///     Create a new <see cref="VTope"/> instance 
        /// </summary>
        /// <param name="user">Unique 'user' value for authorization</param>
        /// <param name="key">Unique 'key' value for authorization</param>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="user"/> or <paramref name="key"/> is null or whitespace
        /// </exception>
        /// <remarks>
        ///     'user' and 'key' values can be taken
        ///     in the docs: https://vto.pe/docs/api/?tab=api-bot
        /// </remarks>
        public VTope(string user, string key)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(user));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));
            
            _user = user;
            _key = key;
        }
    }
}
