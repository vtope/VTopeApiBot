using System.Collections.Generic;

namespace VTopeApiBot.Requests
{
    /// <summary>
    ///     Requests params.
    /// </summary>
    public class VTopeParams : Dictionary<string, object>
    {
        /// <inheritdoc />
        public VTopeParams()
        {
        }

        /// <inheritdoc />
        public VTopeParams(IDictionary<string, object> dictionary) : base(dictionary: dictionary)
        {
        }

        /// <summary>
        ///     Params for request without params. 
        /// </summary>
        public static VTopeParams Empty => new VTopeParams();
    }
}